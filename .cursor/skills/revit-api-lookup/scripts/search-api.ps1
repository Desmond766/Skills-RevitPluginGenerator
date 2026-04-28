<#
.SYNOPSIS
    Search the packaged Revit 2024 API symbol index. Defaults to structured
    symbol lookup (fast, precise, ~10x fewer tokens); optionally falls back to
    raw HTML fulltext when a maintainer has generated local HTML docs.

.DESCRIPTION
    Two modes:

    1. Symbol mode (default): greps docs\symbols.jsonl by symbol name / parent
       type / kind, then prints the corresponding clean markdown sidecars.
       Use this for "what's the signature of X", "what does this enum value
       mean", "which methods live on this class".

    2. Fulltext mode (-Fulltext): greps raw decompiled HTML for arbitrary
       phrase matches if docs\html exists locally. This is maintainer-only and
       is not required for normal packaged-skill use.

    Symbol mode uses the packaged docs\symbols.jsonl and docs\md sidecars.

.PARAMETER Query
    Positional. Symbol name or phrase to look up.

.PARAMETER Symbol
    Force symbol-mode search (default when -Fulltext is not set).

.PARAMETER Fulltext
    Force fulltext mode over the raw HTML.

.PARAMETER Parent
    Symbol mode: restrict to members of this class/enum (e.g. BuiltInCategory).

.PARAMETER Kind
    Symbol mode: restrict to one kind: type, method, property, field, event, enumMember.

.PARAMETER Top
    Max sidecars / pages to display. Default 8.

.PARAMETER Context
    Fulltext mode: lines of context around each hit. Default 3.

.PARAMETER RgPath
    Explicit path to rg.exe. If omitted, uses PATH, then Cursor / VSCode locations.

.EXAMPLE
    # Look up a method signature
    powershell -File search-api.ps1 OfCategoryId

.EXAMPLE
    # Look up an enum value on a specific parent type
    powershell -File search-api.ps1 OST_Walls -Parent BuiltInCategory

.EXAMPLE
    # List all methods on FilteredElementCollector
    powershell -File search-api.ps1 -Parent FilteredElementCollector -Kind method -Top 50

.EXAMPLE
    # Fall back to fulltext when you have a prose phrase, not a symbol
    powershell -File search-api.ps1 "how to create ExternalEvent" -Fulltext
#>
[CmdletBinding()]
param(
    [Parameter(Position = 0)][string]$Query,
    [switch]$Symbol,
    [switch]$Fulltext,
    [string]$Parent,
    [ValidateSet('', 'type', 'method', 'property', 'field', 'event', 'enumMember')]
    [string]$Kind = '',
    [int]$Top = 8,
    [int]$Context = 3,
    [string]$RgPath,
    [string]$GlossaryPath,
    [switch]$NoTranslate
)

$ErrorActionPreference = 'Stop'

$skillDir = Split-Path -Parent $PSScriptRoot
$docsDir  = Join-Path $skillDir 'docs'
$htmlDir  = Join-Path $docsDir  'html'
$mdDir    = Join-Path $docsDir  'md'
$jsonl    = Join-Path $docsDir  'symbols.jsonl'

# Default glossary lives alongside the three skills (parent of this skill folder).
if (-not $GlossaryPath) {
    $skillsRoot = Split-Path -Parent $skillDir
    $GlossaryPath = Join-Path $skillsRoot 'glossary.zh-en.md'
}

if (-not (Test-Path $docsDir)) {
    Write-Error "Packaged API index not found at $docsDir. Restore docs\symbols.jsonl and docs\md, or rebuild them from RevitAPI.chm as a maintainer."
    exit 1
}

# ----------- bilingual query expansion -----------
function Load-ZhEnGlossary {
    param([string]$Path)
    if (-not $Path -or -not (Test-Path $Path)) { return @() }
    $text = [System.IO.File]::ReadAllText((Resolve-Path $Path).Path, [System.Text.UTF8Encoding]::new($false))
    $rows = New-Object System.Collections.Generic.List[object]
    foreach ($line in ($text -split "`r?`n")) {
        if ($line -notmatch '^\s*\|') { continue }
        $m = [regex]::Match($line, '^\s*\|\s*([^|]+?)\s*\|\s*([^|]+?)\s*\|\s*([^|]+?)\s*\|\s*$')
        if (-not $m.Success) { continue }
        $en  = $m.Groups[1].Value.Trim()
        $zh  = $m.Groups[2].Value.Trim()
        $api = $m.Groups[3].Value.Trim()
        if ($en -ieq 'en' -or $en -match '^:?-+:?$') { continue }
        # Split on , 、 ; but NOT '/' so "n/a" stays atomic (otherwise "n/a"
        # becomes ["n", "a"], which both match every English word).
        $split = {
            param($c)
            if (-not $c -or $c.Trim() -ieq 'n/a') { return @() }
            ($c -split '[,、;]') | ForEach-Object { $_.Trim() } |
                Where-Object { $_ -and $_ -ine 'n/a' }
        }
        $enArr  = @(& $split $en)
        $zhArr  = @(& $split $zh)
        $apiArr = @(& $split $api)
        # Defence in depth: drop single-char EN/API tokens; keep all CJK.
        $enArr  = @($enArr  | Where-Object { $_.Length -ge 2 })
        $apiArr = @($apiArr | Where-Object { $_.Length -ge 2 })
        $rows.Add([pscustomobject]@{
            En  = $enArr
            Zh  = $zhArr
            Api = $apiArr
        })
    }
    return $rows
}

# For a query containing CJK, return the set of English / API symbol alternatives
# to try. The original query is always included so we never lose a match.
function Expand-QueryAlternatives {
    param(
        [string]$Query,
        [array]$Glossary
    )
    $alts = New-Object System.Collections.Generic.List[string]
    if ($Query) { $alts.Add($Query) }
    if (-not $Query -or -not $Glossary -or $Glossary.Count -eq 0) { return @($alts) }
    $hasCjk = [regex]::IsMatch($Query, '\p{IsCJKUnifiedIdeographs}')
    if (-not $hasCjk) { return @($alts) }
    foreach ($g in $Glossary) {
        $hit = $false
        foreach ($t in $g.Zh) { if ($t -and $Query.Contains($t)) { $hit = $true; break } }
        if (-not $hit) { continue }
        # Prefer API identifiers first (more precise), then bare English terms.
        foreach ($t in $g.Api) { if ($t) { [void]$alts.Add($t) } }
        foreach ($t in $g.En)  { if ($t) { [void]$alts.Add($t) } }
    }
    return @($alts | Select-Object -Unique)
}

$glossary = if ($NoTranslate) { @() } else { Load-ZhEnGlossary -Path $GlossaryPath }

function Find-Rg {
    param([string]$Explicit)
    if ($Explicit -and (Test-Path $Explicit)) { return (Resolve-Path $Explicit).Path }
    $cmd = Get-Command rg -ErrorAction SilentlyContinue
    if ($cmd) { return $cmd.Path }
    $searchRoots = @()
    $cursorProc = Get-Process | Where-Object { $_.ProcessName -match 'cursor' } | Select-Object -First 1
    if ($cursorProc -and $cursorProc.Path) { $searchRoots += (Split-Path $cursorProc.Path -Parent) }
    $searchRoots += @(
        "$env:LOCALAPPDATA\Programs\cursor",
        "$env:LOCALAPPDATA\Programs\Microsoft VS Code",
        "${env:ProgramFiles}\Microsoft VS Code",
        "${env:ProgramFiles(x86)}\Microsoft VS Code"
    )
    foreach ($root in ($searchRoots | Where-Object { $_ -and (Test-Path $_) } | Select-Object -Unique)) {
        $hit = Get-ChildItem $root -Recurse -Filter 'rg.exe' -ErrorAction SilentlyContinue |
               Where-Object { $_.FullName -match 'x64-win32|@vscode\\ripgrep' } |
               Select-Object -First 1
        if ($hit) { return $hit.FullName }
    }
    return $null
}

$rg = Find-Rg -Explicit $RgPath
if (-not $rg) {
    Write-Error "ripgrep (rg.exe) not found. Pass -RgPath, install ripgrep, or ensure Cursor/VSCode is available."
    exit 1
}

# ----------------- symbol mode -----------------
function Invoke-SymbolMode {
    if (-not (Test-Path $jsonl)) {
        Write-Error @"
symbols.jsonl not found at $jsonl.
Restore the packaged index, or rebuild it as a maintainer:
  powershell -ExecutionPolicy Bypass -File scripts\build-api-index.ps1
"@
        exit 1
    }

    if (-not $Query -and -not $Parent -and -not $Kind) {
        Write-Error "Provide -Query, -Parent, or -Kind for symbol mode."
        exit 1
    }

    # Bilingual expansion: if $Query contains CJK, translate to English/API
    # symbol alternatives via the glossary. Matches are unioned across all alts
    # AND against the record's own "zh":"..." field (written by
    # build-api-index.ps1 for records whose name/parent maps to Chinese).
    $alternatives = Expand-QueryAlternatives -Query $Query -Glossary $glossary
    $queryIsCjk = $Query -and [regex]::IsMatch($Query, '\p{IsCJKUnifiedIdeographs}')
    if ($queryIsCjk -and $alternatives.Count -gt 1) {
        Write-Host ("CJK query '$Query' -> trying alternatives: " + (($alternatives | Select-Object -Skip 1) -join ', ')) -ForegroundColor DarkGray
    }
    $nameRegexes = @()
    foreach ($alt in $alternatives) {
        if ($alt) { $nameRegexes += [regex]::new([regex]::Escape($alt), 'IgnoreCase') }
    }

    # Stream + filter in PowerShell. Faster than shelling out to rg for this
    # use case, and avoids the PowerShell/rg nested-quote escaping nightmare.
    $candidates = [System.Collections.Generic.List[object]]::new()

    # Stream the jsonl line-by-line.
    $reader = [System.IO.StreamReader]::new($jsonl)
    try {
        while (-not $reader.EndOfStream) {
            $line = $reader.ReadLine()
            if (-not $line) { continue }

            if ($Parent -and $line -notmatch ('"parent":"' + [regex]::Escape($Parent) + '"')) { continue }
            if ($Kind   -and $line -notmatch ('"kind":"'   + [regex]::Escape($Kind)   + '"')) { continue }

            if ($Query) {
                $nameMatch = [regex]::Match($line, '"name":"([^"]+)"')
                if (-not $nameMatch.Success) { continue }
                $name = $nameMatch.Groups[1].Value
                $hit = $false
                foreach ($rx in $nameRegexes) {
                    if ($rx.IsMatch($name)) { $hit = $true; break }
                }
                # For CJK queries, also match the record's own "zh" field.
                if (-not $hit -and $queryIsCjk) {
                    $zhMatch = [regex]::Match($line, '"zh":"([^"]+)"')
                    if ($zhMatch.Success -and $zhMatch.Groups[1].Value.Contains($Query)) { $hit = $true }
                }
                if (-not $hit) { continue }
            }

            $candidates.Add($line)
            if ($candidates.Count -ge ($Top * 5)) { break }  # fetch a pool; we re-rank below
        }
    } finally { $reader.Dispose() }

    if ($candidates.Count -eq 0) {
        $filter = @()
        if ($Query)  { $filter += "name~$Query" }
        if ($Parent) { $filter += "parent=$Parent" }
        if ($Kind)   { $filter += "kind=$Kind" }
        Write-Host "No symbols found for: $($filter -join ', ')" -ForegroundColor Yellow
        if ($queryIsCjk) {
            Write-Host "Query was CJK; tried alternatives: $($alternatives -join ', ')" -ForegroundColor DarkYellow
            Write-Host "If the term should map to a Revit API symbol, add a row to:" -ForegroundColor DarkYellow
            Write-Host "  $GlossaryPath" -ForegroundColor DarkYellow
        }
        return
    }

    # Rank: exact name match first (against any alternative), then startswith,
    # then substring, then shortest name.
    $primary = if ($alternatives.Count -gt 0) { $alternatives[0] } else { $Query }
    # Prefer scoring against the first English alternative when the original is CJK,
    # since the JSONL "name" field is always English.
    $scoreKey = if ($queryIsCjk -and $alternatives.Count -gt 1) { $alternatives[1] } else { $primary }

    $ranked = @($candidates | ForEach-Object {
        $l = $_
        $n = ''
        if ($l -match '"name":"([^"]+)"') { $n = $Matches[1] }
        $score = 100
        if ($scoreKey) {
            if ($n -ieq $scoreKey)               { $score = 0 }
            elseif ($n -ilike "$scoreKey*")      { $score = 1 }
            elseif ($n -imatch [regex]::Escape($scoreKey)) { $score = 2 }
        }
        [pscustomobject]@{ Line = $l; Name = $n; Score = $score; Len = $n.Length }
    } | Sort-Object Score, Len, Name | Select-Object -First $Top)

    Write-Host "Found $($candidates.Count) candidate(s). Showing top $($ranked.Count)." -ForegroundColor Green
    Write-Host ""

    foreach ($r in $ranked) {
        $line = $r.Line
        $mdRel = $null; $id = $null
        if ($line -match '"md":"([^"]+)"') { $mdRel = $Matches[1] }
        if ($line -match '"id":"([^"]+)"') { $id    = $Matches[1] }
        $mdPath = if ($mdRel) { Join-Path $docsDir $mdRel } else { $null }

        Write-Host "===== $id" -ForegroundColor Cyan
        if ($mdPath -and (Test-Path $mdPath)) {
            $body = Get-Content $mdPath -Raw
            # Drop the YAML front-matter when printing for the agent; the id header above already has it.
            $body = [regex]::Replace($body, '(?s)^---.*?---\r?\n', '')
            Write-Host $body.TrimEnd()
        } else {
            Write-Host "(no sidecar at $mdRel)" -ForegroundColor DarkGray
        }
        Write-Host ""
    }
}

# ----------------- fulltext mode (cleaned version of the original) -----------------
function Strip-Chrome {
    param([string]$Html)
    # Collapse Sandcastle language-specific separator spans to the C# variant only.
    $t = [regex]::Replace(
        $Html,
        '(?is)<span class="languageSpecificText">\s*<span class="cs">(.*?)</span>\s*<span class="vb">.*?</span>\s*<span class="cpp">.*?</span>\s*<span class="nu">.*?</span>\s*<span class="fs">.*?</span>\s*</span>',
        '$1'
    )
    $t = [regex]::Replace($t, '(?is)<span class="languageSpecificText">.*?</span>', '')
    # Drop the whole Sandcastle page header (Collapse All / Code: C# / feedback links).
    $t = [regex]::Replace($t, '(?is)<div id="header">.*?</div>\s*<table id="gradientTable">.*?</table>', ' ')
    $t = [regex]::Replace($t, '(?is)<div id="footer">.*?</div>', ' ')
    # Drop VB + C++ syntax blocks entirely; keep only the C# variant.
    $t = [regex]::Replace($t, '(?is)<span codeLanguage="VisualBasicDeclaration">.*?</span>', ' ')
    $t = [regex]::Replace($t, '(?is)<span codeLanguage="ManagedCPlusPlus">.*?</span>', ' ')
    $t = [regex]::Replace($t, '(?is)<script.*?</script>', ' ')
    $t = [regex]::Replace($t, '(?is)<style.*?</style>', ' ')
    $t = [regex]::Replace($t, '<[^>]+>', ' ')
    $t = [System.Net.WebUtility]::HtmlDecode($t)
    $t = [regex]::Replace($t, '[ \t]+', ' ')
    $t = [regex]::Replace($t, '(\r?\n\s*){2,}', "`n")
    return $t.Trim()
}

function Invoke-FulltextMode {
    if (-not (Test-Path $htmlDir)) {
        Write-Error "HTML dir missing at $htmlDir. Fulltext mode is optional and requires maintainer-generated raw HTML from RevitAPI.chm. Use symbol mode for normal packaged-skill lookup."
        exit 1
    }
    if (-not $Query) { Write-Error "Provide -Query for fulltext mode."; exit 1 }

    $terms = $Query.Split(' ', [StringSplitOptions]::RemoveEmptyEntries)
    if ($terms.Count -eq 0) { Write-Error "Empty query."; exit 1 }

    Write-Host "Using rg: $rg" -ForegroundColor DarkGray

    $candidates = & $rg --files-with-matches -i --glob '*.htm' $terms[0] $htmlDir
    for ($i = 1; $i -lt $terms.Count; $i++) {
        if (-not $candidates) { break }
        $t = $terms[$i]
        $candidates = $candidates | ForEach-Object {
            $file = $_
            $hit = & $rg -l -i $t $file
            if ($hit) { $file }
        }
    }

    if (-not $candidates) { Write-Host "No matches for: $Query" -ForegroundColor Yellow; return }

    # Rank by match density (more hits of the first term = more relevant).
    $ranked = foreach ($f in $candidates) {
        $count = 0
        foreach ($ln in [System.IO.File]::ReadLines($f)) {
            if ($ln -imatch [regex]::Escape($terms[0])) { $count++ }
        }
        [pscustomobject]@{ File = $f; Hits = $count }
    }
    $ranked = $ranked | Sort-Object -Property @{Expression='Hits'; Descending=$true} | Select-Object -First $Top

    foreach ($r in $ranked) {
        $f = $r.File
        $raw = Get-Content -Raw -LiteralPath $f
        $titleMatch = [regex]::Match($raw, '(?is)<title>(.*?)</title>')
        $title = if ($titleMatch.Success) { ($titleMatch.Groups[1].Value -replace '\s+',' ').Trim() } else { Split-Path $f -Leaf }

        $text = Strip-Chrome $raw
        $lines = $text -split "`n"
        $hitIdxs = @()
        for ($i = 0; $i -lt $lines.Length; $i++) {
            if ($lines[$i] -imatch [regex]::Escape($terms[0])) { $hitIdxs += $i }
        }

        Write-Host ""
        Write-Host "===== $title (hits: $($r.Hits))" -ForegroundColor Cyan
        Write-Host "file: $f" -ForegroundColor DarkGray

        if ($hitIdxs.Count -eq 0) {
            ($lines | Where-Object { $_.Trim() } | Select-Object -First 10) -join "`n" | Write-Host
            continue
        }

        $shown = @{}
        foreach ($idx in ($hitIdxs | Select-Object -First 3)) {
            $lo = [Math]::Max(0, $idx - $Context)
            $hi = [Math]::Min($lines.Length - 1, $idx + $Context)
            $key = "$lo-$hi"
            if ($shown.ContainsKey($key)) { continue }
            $shown[$key] = $true
            $snippet = ($lines[$lo..$hi] | Where-Object { $_.Trim() }) -join "`n"
            Write-Host "--- lines $lo..$hi ---" -ForegroundColor DarkGray
            Write-Host $snippet
        }
    }
}

# ----------------- dispatch -----------------
if ($Fulltext) {
    Invoke-FulltextMode
} else {
    Invoke-SymbolMode
}
