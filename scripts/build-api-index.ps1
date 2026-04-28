<#
.SYNOPSIS
    Build a structured symbol index and per-symbol markdown sidecars from the
    decompiled Revit API docs. One-time preprocessing that turns 420 MB of noisy
    Sandcastle HTML into a tiny, grep-friendly JSONL index + clean .md files.

.DESCRIPTION
    For each .htm page under -DocsDir\html, parses the Sandcastle <meta> tags
    (Microsoft.Help.Id, ContentType, Description, container) to classify the
    page by symbol kind (class, method, property, field, event, enum, delegate,
    interface, struct).

    For method/property/field/event pages: extracts the C# signature, parameters,
    return value, remarks, and exceptions into a ~1 KB markdown sidecar.

    For enum pages: additionally parses each row of the members table and emits
    one symbol row per enum value (so looking up "OST_Walls" jumps straight to
    the description of that one value, not the whole 800 KB BuiltInCategory page).

    Writes:
        <DocsDir>\symbols.jsonl        - one JSON object per symbol (fast grep target)
        <DocsDir>\md\<HelpIdStem>.md  - markdown sidecars (stem from Microsoft.Help.Id; enum members use their `F:` member id)

    Typical reduction per lookup: ~10x fewer tokens and far better precision,
    because the index contains no navigation chrome.

.PARAMETER DocsDir
    Root of the decompiled docs. Default: .cursor\skills\revit-api-lookup\docs

.PARAMETER Force
    Rebuild from scratch even if outputs exist.

.NOTES
    Run once after scripts\decompile-chm.ps1. Reruns are idempotent.

.EXAMPLE
    powershell -ExecutionPolicy Bypass -File scripts\build-api-index.ps1
#>
[CmdletBinding()]
param(
    [string]$DocsDir = ".cursor\skills\revit-api-lookup\docs",
    [switch]$Force
)

$ErrorActionPreference = 'Stop'

$htmlDir = Join-Path $DocsDir 'html'
$mdDir   = Join-Path $DocsDir 'md'
$jsonl   = Join-Path $DocsDir 'symbols.jsonl'

if (-not (Test-Path $htmlDir)) {
    throw "HTML dir not found at $htmlDir. Run scripts\decompile-chm.ps1 first."
}

if ((Test-Path $jsonl) -and -not $Force) {
    Write-Host "symbols.jsonl already exists. Pass -Force to rebuild." -ForegroundColor Yellow
    exit 0
}

if (Test-Path $mdDir) { Remove-Item $mdDir -Recurse -Force }
New-Item -ItemType Directory -Force -Path $mdDir | Out-Null
if (Test-Path $jsonl) { Remove-Item $jsonl -Force }

# Shared sidecar naming — must match rename-api-md-sidecars.ps1
. (Join-Path $PSScriptRoot 'api-md-naming.ps1')

# ----------- helpers -----------

function Normalize-LangSpans {
    # Sandcastle wraps per-language separators like:
    #   <span class="languageSpecificText">
    #     <span class="cs">.</span><span class="vb">.</span><span class="cpp">::</span>
    #     <span class="nu">.</span><span class="fs">.</span>
    #   </span>
    # A lazy outer ".*?</span>" would stop at the first inner </span>, leaking the
    # rest as " . :: . . " after tag stripping. Match the fully-known 5-inner shape
    # and collapse it to just the C# variant.
    param([string]$Html)
    if (-not $Html) { return '' }
    $pattern = '(?is)<span class="languageSpecificText">\s*' +
               '<span class="cs">(.*?)</span>\s*' +
               '<span class="vb">.*?</span>\s*' +
               '<span class="cpp">.*?</span>\s*' +
               '<span class="nu">.*?</span>\s*' +
               '<span class="fs">.*?</span>\s*' +
               '</span>'
    $t = [regex]::Replace($Html, $pattern, '$1')
    # Fallback: any remaining languageSpecificText blocks with unknown shape get
    # their entire content dropped (safer than leaking raw separators).
    $t = [regex]::Replace($t, '(?is)<span class="languageSpecificText">.*?</span>', '')
    return $t
}

function Strip-Tags {
    param([string]$Html)
    if (-not $Html) { return '' }
    $t = Normalize-LangSpans $Html
    $t = [regex]::Replace($t, '(?is)<script.*?</script>', ' ')
    $t = [regex]::Replace($t, '(?is)<style.*?</style>',   ' ')
    $t = [regex]::Replace($t, '<[^>]+>', ' ')
    $t = [System.Net.WebUtility]::HtmlDecode($t)
    $t = [regex]::Replace($t, '[ \t]+', ' ')
    $t = [regex]::Replace($t, '(\r?\n\s*){2,}', "`n")
    return $t.Trim()
}

function Extract-Signature {
    param([string]$Html)
    # Grab only the C# <pre> block, preserve whitespace/newlines, strip inner tags.
    $m = [regex]::Match($Html, '(?is)<span codeLanguage="CSharp">\s*<table>.*?<pre[^>]*>(.*?)</pre>')
    if (-not $m.Success) { return '' }
    $inner = $m.Groups[1].Value
    # Drop inline <a>/<span> but keep text and whitespace.
    $inner = [regex]::Replace($inner, '<[^>]+>', '')
    $inner = [System.Net.WebUtility]::HtmlDecode($inner)
    return $inner.TrimEnd()
}

function Extract-Section {
    param([string]$Html, [string]$DivId)
    $pattern = '(?is)<div id="' + [regex]::Escape($DivId) + '"[^>]*>(.*?)</div>\s*(?=<h1|<div id=|</div>)'
    $m = [regex]::Match($Html, $pattern)
    if (-not $m.Success) { return '' }
    $raw = $m.Groups[1].Value
    # The remarks/exceptions inner div is itself the whole content; trim the "heading" clicky chrome.
    return (Strip-Tags $raw).Trim()
}

function Extract-Summary {
    param([string]$Html)
    $m = [regex]::Match($Html, '(?is)<div class="summary">(.*?)</div>')
    if (-not $m.Success) { return '' }
    return (Strip-Tags $m.Groups[1].Value).Trim()
}

function Extract-ReturnValue {
    param([string]$Html)
    # Sits between <h4 class="subHeading">Return Value</h4> and the next <h1/<h4/<div id=/</div>
    $m = [regex]::Match($Html, '(?is)<h4 class="subHeading">\s*Return Value\s*</h4>(.*?)(?=<h1|<h4|<div id=|</div>\s*<h1|$)')
    if (-not $m.Success) { return '' }
    return (Strip-Tags $m.Groups[1].Value).Trim()
}

function Extract-Parameters {
    param([string]$Html)
    $m = [regex]::Match($Html, '(?is)<div id="parameters">(.*?)</div>\s*(?:<h4|<h1|<div id=)')
    if (-not $m.Success) { return @() }
    $block = $m.Groups[1].Value
    $out = @()
    foreach ($pm in [regex]::Matches($block, '(?is)<dl paramName="([^"]+)"[^>]*>(.*?)</dl>')) {
        $name = $pm.Groups[1].Value
        $body = $pm.Groups[2].Value

        # Extract the full type expression between "Type:" and the next <br> (or </dd>).
        # This correctly captures generic types that span multiple <a> tags, e.g.
        # ICollection<ElementId> = <a>ICollection</a>(<a>ElementId</a>).
        $typeRaw = ''
        $typeBlock = [regex]::Match($body, '(?is)Type\s*:\s*(.*?)(?:<br\s*/?>|</dd>)')
        if ($typeBlock.Success) {
            $typeRaw = Strip-Tags $typeBlock.Groups[1].Value
        }
        # Sandcastle renders generics as "ICollection ( ElementId )" after tag stripping.
        # Convert "Foo ( Bar )" to "Foo<Bar>" for readability.
        $type = [regex]::Replace($typeRaw, '\s*\(\s*([^()]+?)\s*\)\s*', '<$1>')
        $type = $type.Trim()

        # Description: everything in <dd> AFTER the first <br /> (i.e. past the "Type:" line).
        $descMatch = [regex]::Match($body, '(?is)<dd>(.*?)</dd>')
        $desc = ''
        if ($descMatch.Success) {
            $ddInner = $descMatch.Groups[1].Value
            $after = [regex]::Match($ddInner, '(?is)<br\s*/?>(.*)$')
            if ($after.Success) {
                $desc = (Strip-Tags $after.Groups[1].Value).Trim()
            } else {
                $desc = (Strip-Tags $ddInner).Trim()
                $desc = [regex]::Replace($desc, '(?is)^\s*Type\s*:.*$', '').Trim()
            }
        }
        $out += [pscustomobject]@{ Name = $name; Type = $type; Desc = $desc }
    }
    return $out
}

function Extract-Exceptions {
    param([string]$Html)
    $m = [regex]::Match($Html, '(?is)<div id="exceptionsSection"[^>]*>(.*?)</div>\s*</div>')
    if (-not $m.Success) { return @() }
    $body = $m.Groups[1].Value
    $out = @()
    foreach ($ex in [regex]::Matches($body, '(?is)<tr>\s*<td>(.*?)</td>\s*<td>(.*?)</td>\s*</tr>')) {
        $t = (Strip-Tags $ex.Groups[1].Value)
        if ($t -eq 'Exception' -or $t -eq '') { continue }
        $c = (Strip-Tags $ex.Groups[2].Value)
        $out += [pscustomobject]@{ Type = $t; Condition = $c }
    }
    return $out
}

function Get-MetaTag {
    param([string]$Html, [string]$Name)
    $p = '(?is)<meta name="' + [regex]::Escape($Name) + '" content="([^"]*)"'
    $m = [regex]::Match($Html, $p)
    if ($m.Success) { return $m.Groups[1].Value } else { return '' }
}

function To-Json-Line {
    param([hashtable]$o)
    # Minimal JSON encoder that keeps the output compact and one-line-per-record.
    $parts = @()
    foreach ($k in $o.Keys) {
        $v = $o[$k]
        if ($null -eq $v) { continue }
        if ($v -is [string]) {
            $esc = $v -replace '\\','\\\\' -replace '"','\"' -replace "`r",'' -replace "`n",'\n' -replace "`t",'\t'
            $parts += ('"{0}":"{1}"' -f $k, $esc)
        } elseif ($v -is [int] -or $v -is [long] -or $v -is [bool]) {
            $parts += ('"{0}":{1}' -f $k, ($v.ToString().ToLower()))
        } else {
            $s = "$v" -replace '\\','\\\\' -replace '"','\"'
            $parts += ('"{0}":"{1}"' -f $k, $s)
        }
    }
    return '{' + ($parts -join ',') + '}'
}

function Classify-FromHelpId {
    param([string]$HelpId)
    if (-not $HelpId) { return $null }
    switch -Regex ($HelpId) {
        '^T:'      { return 'type' }
        '^M:'      { return 'method' }
        '^P:'      { return 'property' }
        '^F:'      { return 'field' }
        '^E:'      { return 'event' }
        '^N:'      { return 'namespace' }
        '^Overload:' { return 'overload' }
        default    { return 'other' }
    }
}

function Split-QualifiedName {
    # Parse an ECMA-style HelpId into (ns, parent, name).
    #   T:Autodesk.Revit.DB.BuiltInCategory              -> ns=Autodesk.Revit.DB, parent='',               name=BuiltInCategory
    #   M:Autodesk.Revit.DB.FilteredElementCollector.OfCategoryId(...) -> ns=Autodesk.Revit.DB, parent=FilteredElementCollector, name=OfCategoryId
    #   F:Autodesk.Revit.DB.BuiltInCategory.OST_Walls    -> ns=Autodesk.Revit.DB, parent=BuiltInCategory, name=OST_Walls
    #
    # Types have no "parent"; members do. Everything before the parent (for members)
    # or before the name (for types) is the namespace.
    param([string]$HelpId, [string]$Kind)
    $prefix = ''
    $body = $HelpId
    if ($HelpId -match '^([A-Za-z]+):(.*)$') {
        $prefix = $Matches[1]
        $body   = $Matches[2]
    }
    $body = $body -replace '\(.*$',''   # strip argument list
    $parts = $body -split '\.'
    if ($parts.Count -eq 0) {
        return [pscustomobject]@{ Ns = ''; Parent = ''; Name = $body }
    }
    $name = $parts[-1]

    $treatAsMember = ($Kind -eq 'method' -or $Kind -eq 'property' -or $Kind -eq 'field' -or $Kind -eq 'event')

    if ($treatAsMember -and $parts.Count -ge 3) {
        $parent = $parts[-2]
        $nsSegs = $parts[0..($parts.Count - 3)]
        $ns = ($nsSegs -join '.')
        return [pscustomobject]@{ Ns = $ns; Parent = $parent; Name = $name }
    }

    # Types (and anything else): no parent; namespace is everything before the name.
    if ($parts.Count -ge 2) {
        $nsSegs = $parts[0..($parts.Count - 2)]
        $ns = ($nsSegs -join '.')
    } else {
        $ns = ''
    }
    return [pscustomobject]@{ Ns = $ns; Parent = ''; Name = $name }
}

function Write-MdSidecar {
    param(
        [string]$Path,
        [string]$Kind,
        [string]$FullName,
        [string]$HelpId,
        [string]$Summary,
        [string]$Signature,
        [array]$Params,
        [string]$ReturnValue,
        [string]$Remarks,
        [array]$Exceptions,
        [string]$SourceHtml
    )
    $sb = [System.Text.StringBuilder]::new()
    $null = $sb.AppendLine('---')
    $null = $sb.AppendLine("kind: $Kind")
    $null = $sb.AppendLine("id: $HelpId")
    $null = $sb.AppendLine("source: $SourceHtml")
    $null = $sb.AppendLine('---')
    $null = $sb.AppendLine("# $FullName")
    if ($Summary) {
        $null = $sb.AppendLine()
        $null = $sb.AppendLine($Summary)
    }
    if ($Signature) {
        $null = $sb.AppendLine()
        $null = $sb.AppendLine('## Syntax (C#)')
        $null = $sb.AppendLine('```csharp')
        $null = $sb.AppendLine($Signature)
        $null = $sb.AppendLine('```')
    }
    if ($Params -and $Params.Count -gt 0) {
        $null = $sb.AppendLine()
        $null = $sb.AppendLine('## Parameters')
        foreach ($p in $Params) {
            # Build with explicit concatenation so backticks render literally (markdown code spans).
            $line = '- **' + $p.Name + '** (`' + $p.Type + '`)'
            if ($p.Desc) { $line += ' - ' + $p.Desc }
            $null = $sb.AppendLine($line)
        }
    }
    if ($ReturnValue) {
        $null = $sb.AppendLine()
        $null = $sb.AppendLine('## Returns')
        $null = $sb.AppendLine($ReturnValue)
    }
    if ($Remarks) {
        $null = $sb.AppendLine()
        $null = $sb.AppendLine('## Remarks')
        $null = $sb.AppendLine($Remarks)
    }
    if ($Exceptions -and $Exceptions.Count -gt 0) {
        $null = $sb.AppendLine()
        $null = $sb.AppendLine('## Exceptions')
        foreach ($e in $Exceptions) {
            $null = $sb.AppendLine("- **$($e.Type)** - $($e.Condition)")
        }
    }
    Set-Content -LiteralPath $Path -Value $sb.ToString() -Encoding UTF8
}

# ----------- main loop -----------

$files = Get-ChildItem $htmlDir -Filter '*.htm' -File
Write-Host "Scanning $($files.Count) HTML files..." -ForegroundColor Cyan

$writer = [System.IO.StreamWriter]::new($jsonl, $false, [System.Text.UTF8Encoding]::new($false))

$stats = [ordered]@{
    processed       = 0
    emitted         = 0
    skipped_nonref  = 0
    skipped_no_id   = 0
    skipped_overload = 0
    skipped_namespace = 0
    enum_pages      = 0
    enum_members    = 0
}

$start = Get-Date
try {
    foreach ($f in $files) {
        $stats.processed++
        if ($stats.processed % 2000 -eq 0) {
            $pct = [int](100 * $stats.processed / $files.Count)
            Write-Host ("  {0,5}/{1} ({2}%)  emitted={3}" -f $stats.processed, $files.Count, $pct, $stats.emitted) -ForegroundColor DarkGray
        }

        $html = Get-Content -LiteralPath $f.FullName -Raw

        $contentType = Get-MetaTag $html 'Microsoft.Help.ContentType'
        if ($contentType -and $contentType -ne 'Reference') { $stats.skipped_nonref++; continue }

        $helpId = Get-MetaTag $html 'Microsoft.Help.Id'
        if (-not $helpId) { $stats.skipped_no_id++; continue }

        $kind = Classify-FromHelpId $helpId
        if ($kind -eq 'overload')   { $stats.skipped_overload++; continue }
        if ($kind -eq 'namespace')  { $stats.skipped_namespace++; continue }

        $description = Get-MetaTag $html 'Description'
        $titleMatch  = [regex]::Match($html, '(?is)<title>(.*?)</title>')
        $title = if ($titleMatch.Success) { ($titleMatch.Groups[1].Value -replace '\s+', ' ').Trim() } else { $f.Name }

        $ids = Split-QualifiedName -HelpId $helpId -Kind $kind

        # Extract structured content
        $summary     = Extract-Summary $html
        $signature   = Extract-Signature $html
        $parameters  = Extract-Parameters $html
        $returnValue = Extract-ReturnValue $html
        $remarks     = Extract-Section $html 'remarksSection'
        $exceptions  = Extract-Exceptions $html

        if (-not $summary -and $description) { $summary = $description }

        # Decide full display name
        $fullName = switch ($kind) {
            'type'     { "$($ids.Ns).$($ids.Name)" }
            'method'   { "$($ids.Ns).$($ids.Parent).$($ids.Name) Method" }
            'property' { "$($ids.Ns).$($ids.Parent).$($ids.Name) Property" }
            'field'    { "$($ids.Ns).$($ids.Parent).$($ids.Name) Field" }
            'event'    { "$($ids.Ns).$($ids.Parent).$($ids.Name) Event" }
            default    { $title }
        }

        $stem = Get-ApiSidecarStemFromHelpId -HelpId $helpId
        $mdRel    = "md/$stem.md"
        $mdFull   = Join-Path $mdDir "$stem.md"
        $htmlRel  = "html/$($f.Name)"

        Write-MdSidecar `
            -Path $mdFull -Kind $kind -FullName $fullName -HelpId $helpId `
            -Summary $summary -Signature $signature -Params $parameters `
            -ReturnValue $returnValue -Remarks $remarks -Exceptions $exceptions `
            -SourceHtml $htmlRel

        $record = [ordered]@{
            kind   = $kind
            name   = $ids.Name
            parent = $ids.Parent
            ns     = $ids.Ns
            id     = $helpId
            desc   = $summary
            md     = $mdRel
            html   = $htmlRel
        }
        $writer.WriteLine((To-Json-Line $record))
        $stats.emitted++

        # Enum page: expand each member row into its own symbol + md sidecar.
        if ($kind -eq 'type' -and $html -match 'id="enumerationSection"') {
            $stats.enum_pages++
            $enumName = $ids.Name
            $enumNs   = $ids.Ns
            # Grab just the <table class="members"> section
            $memberTable = [regex]::Match($html, '(?is)<table class="members" id="memberList".*?</table>')
            if ($memberTable.Success) {
                $tbl = $memberTable.Value
                # Empty-description members use <td /> (self-closing) instead of
                # <td></td>, so allow both forms. The description capture group
                # may be absent when self-closed.
                $rowRx = '(?is)<tr[^>]*>\s*<td[^>]*target="F:([^"]+)"[^>]*>\s*' +
                         '<span class="selflink">([^<]+)</span>\s*</td>\s*' +
                         '(?:<td[^>]*/>|<td[^>]*>(.*?)</td>)\s*</tr>'
                $idx = 0
                foreach ($rm in [regex]::Matches($tbl, $rowRx)) {
                    $memberId = 'F:' + $rm.Groups[1].Value
                    $mName = $rm.Groups[2].Value.Trim()
                    $mDesc = ''
                    if ($rm.Groups[3].Success) {
                        $mDesc = (Strip-Tags $rm.Groups[3].Value).Trim()
                    }
                    if (-not $mName) { continue }
                    $idx++
                    $memberStem = Get-ApiSidecarStemFromHelpId -HelpId $memberId
                    $mdMemberRel  = "md/$memberStem.md"
                    $mdMemberFull = Join-Path $mdDir "$memberStem.md"

                    $sb = [System.Text.StringBuilder]::new()
                    $null = $sb.AppendLine('---')
                    $null = $sb.AppendLine("kind: enumMember")
                    $null = $sb.AppendLine("id: $memberId")
                    $null = $sb.AppendLine("enum: $enumNs.$enumName")
                    $null = $sb.AppendLine("source: $htmlRel")
                    $null = $sb.AppendLine('---')
                    $null = $sb.AppendLine("# $enumNs.$enumName.$mName")
                    if ($mDesc) {
                        $null = $sb.AppendLine()
                        $null = $sb.AppendLine($mDesc)
                    }
                    Set-Content -LiteralPath $mdMemberFull -Value $sb.ToString() -Encoding UTF8

                    $rec2 = [ordered]@{
                        kind   = 'enumMember'
                        name   = $mName
                        parent = $enumName
                        ns     = $enumNs
                        id     = $memberId
                        desc   = $mDesc
                        md     = $mdMemberRel
                        html   = $htmlRel
                    }
                    $writer.WriteLine((To-Json-Line $rec2))
                    $stats.enum_members++
                    $stats.emitted++
                }
            }
        }
    }
}
finally {
    $writer.Flush()
    $writer.Dispose()
}

$elapsed = (Get-Date) - $start
Write-Host ""
Write-Host "Done in $([int]$elapsed.TotalSeconds)s." -ForegroundColor Green
Write-Host "  Files processed:       $($stats.processed)" -ForegroundColor Gray
Write-Host "  Symbols emitted:       $($stats.emitted)" -ForegroundColor Gray
Write-Host "  Enum pages expanded:   $($stats.enum_pages)" -ForegroundColor Gray
Write-Host "  Enum members emitted:  $($stats.enum_members)" -ForegroundColor Gray
Write-Host "  Skipped non-Reference: $($stats.skipped_nonref)" -ForegroundColor Gray
Write-Host "  Skipped no HelpId:     $($stats.skipped_no_id)" -ForegroundColor Gray
Write-Host "  Skipped overload:      $($stats.skipped_overload)" -ForegroundColor Gray
Write-Host "  Skipped namespace:     $($stats.skipped_namespace)" -ForegroundColor Gray
$idxBytes = (Get-Item $jsonl).Length
$mdBytes  = (Get-ChildItem $mdDir -File | Measure-Object Length -Sum).Sum
Write-Host ("  symbols.jsonl:         {0:N1} MB" -f ($idxBytes / 1MB)) -ForegroundColor Gray
Write-Host ("  md sidecars:           {0:N1} MB ({1} files)" -f ($mdBytes / 1MB), (Get-ChildItem $mdDir -File).Count) -ForegroundColor Gray
