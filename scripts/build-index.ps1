<#
.SYNOPSIS
    Mine every existing Revit plug-in under existingCodes/ and emit the packaged
    scaffold reference index used by the revit-addin-scaffold skill.

.DESCRIPTION
    For each .csproj under -Root, walks its sibling .cs files (skipping bin/obj),
    extracts: Transaction labels, TaskDialog titles, BuiltInCategory refs,
    BuiltInParameter refs, key API usages, UI framework, integrations, and a
    compact source snippet. Classifies each project into a domain by keyword
    score and writes a grep-friendly markdown catalog grouped by domain.

.PARAMETER Root
    Folder to scan. Default: existingCodes

.PARAMETER Output
    Where to write INDEX.md. Default:
    .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md

.PARAMETER SnippetDir
    Where to write compact per-project markdown snippets. Default:
    .cursor\skills\revit-addin-scaffold\samples-index\snippets

.PARAMETER MaxItemsPerField
    Cap on items shown per Actions / Dialogs / Categories / Parameters. Default 5.

.EXAMPLE
    powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1

.NOTES
    Run once during project setup, then again whenever you add or change plug-ins
    under existingCodes/. The produced samples-index folder is committed with
    the skill so normal users do not need the full existingCodes tree.
#>
[CmdletBinding()]
param(
    [string]$Root = 'existingCodes',
    [string]$Output = '.cursor\skills\revit-addin-scaffold\samples-index\INDEX.md',
    [string]$SnippetDir = '.cursor\skills\revit-addin-scaffold\samples-index\snippets',
    [int]$MaxItemsPerField = 5,
    [string]$GlossaryPath = '.cursor\skills\glossary.zh-en.md',
    [int]$MaxSnippetLines = 220,
    [switch]$SkipSnippets
)

$ErrorActionPreference = 'Stop'
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

if (-not (Test-Path $Root)) { Write-Error "Root '$Root' not found."; exit 1 }
$Root = (Resolve-Path $Root).Path

# ----------- bilingual glossary -----------
# Parses .cursor\skills\glossary.zh-en.md into a flat list of rows. Each row
# carries the full en/zh/api synonym sets plus pre-split lowercase token lists
# for cheap matching.
function Load-Glossary {
    param([string]$Path)
    if (-not $Path -or -not (Test-Path $Path)) {
        Write-Host "Glossary not found at '$Path' - bilingual tags disabled." -ForegroundColor Yellow
        return @()
    }
    $text = [System.IO.File]::ReadAllText((Resolve-Path $Path).Path, [System.Text.UTF8Encoding]::new($false))
    $rows = New-Object System.Collections.Generic.List[object]
    foreach ($line in ($text -split "`r?`n")) {
        if ($line -notmatch '^\s*\|') { continue }
        $m = [regex]::Match($line, '^\s*\|\s*([^|]+?)\s*\|\s*([^|]+?)\s*\|\s*([^|]+?)\s*\|\s*$')
        if (-not $m.Success) { continue }
        $en  = $m.Groups[1].Value.Trim()
        $zh  = $m.Groups[2].Value.Trim()
        $api = $m.Groups[3].Value.Trim()
        # Skip the table header row and the |---|---|---| separator row.
        if ($en -ieq 'en' -or $en -match '^:?-+:?$') { continue }
        # Split on ASCII comma, CJK comma, or semicolon ONLY. Do NOT split on '/'
        # because that would break "n/a" into "n" and "a", which then match every
        # English haystack ("n" is a substring of almost any word). Filter "n/a"
        # up-front instead.
        $splitTerms = {
            param($cell)
            if (-not $cell) { return @() }
            if ($cell.Trim() -ieq 'n/a') { return @() }
            ($cell -split '[,、;]') | ForEach-Object { $_.Trim() } |
                Where-Object { $_ -and $_ -ine 'n/a' }
        }
        $enTerms  = @(& $splitTerms $en)
        $zhTerms  = @(& $splitTerms $zh)
        $apiTerms = @(& $splitTerms $api)
        # Defence in depth: drop single-char English/API tokens (e.g. 'm') which
        # would match huge swathes of text. Keep full CJK tokens since each CJK
        # character is meaningful.
        $enTerms  = @($enTerms  | Where-Object { $_.Length -ge 2 })
        $apiTerms = @($apiTerms | Where-Object { $_.Length -ge 2 })
        $rows.Add([pscustomobject]@{
            En       = $enTerms
            Zh       = $zhTerms
            Api      = $apiTerms
            EnLower  = @($enTerms  | ForEach-Object { $_.ToLowerInvariant() })
            ApiLower = @($apiTerms | ForEach-Object { $_.ToLowerInvariant() })
        })
    }
    Write-Host "Loaded $($rows.Count) glossary rows from $Path" -ForegroundColor DarkGray
    return $rows
}

# Given a project's concatenated name + actions + dialogs + categories + params,
# return the union of EN + ZH synonyms for every glossary row that matched.
function Get-BilingualTags {
    param(
        [string]$Haystack,
        [array]$Glossary
    )
    if (-not $Glossary -or $Glossary.Count -eq 0 -or -not $Haystack) { return @() }
    $hayLower = $Haystack.ToLowerInvariant()
    $tags = New-Object System.Collections.Generic.HashSet[string] ([System.StringComparer]::OrdinalIgnoreCase)
    foreach ($g in $Glossary) {
        $matched = $false
        foreach ($t in $g.EnLower)  { if ($t -and $hayLower.Contains($t)) { $matched = $true; break } }
        if (-not $matched) {
            foreach ($t in $g.ApiLower) { if ($t -and $hayLower.Contains($t)) { $matched = $true; break } }
        }
        if (-not $matched) {
            # CJK terms are case-insensitive by construction; search the raw haystack.
            foreach ($t in $g.Zh) { if ($t -and $Haystack.Contains($t)) { $matched = $true; break } }
        }
        if ($matched) {
            foreach ($t in $g.En) { if ($t) { [void]$tags.Add($t) } }
            foreach ($t in $g.Zh) { if ($t) { [void]$tags.Add($t) } }
        }
    }
    return @($tags | Sort-Object)
}

$glossary = Load-Glossary -Path $GlossaryPath
$outDir = Split-Path $Output -Parent
if ($outDir -and -not (Test-Path $outDir)) { New-Item -ItemType Directory -Path $outDir -Force | Out-Null }
if (-not $SkipSnippets -and $SnippetDir -and -not (Test-Path $SnippetDir)) {
    New-Item -ItemType Directory -Path $SnippetDir -Force | Out-Null
}

# Domain keyword dictionary (matched against project name + categories + actions + dialogs)
$domainKeywords = [ordered]@{
    'MEP'          = @('Pipe','Duct','Cable','Conduit','CableTray','MEP','Electrical','Mechanical','Plumbing','Sprinkler','Wire','Junction','Fitting','Ductwork','HVAC')
    'Structural'   = @('Beam','Column','Rebar','Foundation','Brace','Truss','Slab','StructuralColumn','StructuralFraming','StructuralFoundation')
    'Architecture' = @('Wall','Door','Window','Room','Floor','Ceiling','Roof','Stair','Railing','Curtain','ARC_','Area')
    'Export/IO'    = @('Excel','CSV','Export','Import','DWG','IFC','Schedule','Output')
    'Utilities'    = @('Filter','Setting','Manager','Helper','Util','Check','Infochecker','TypeName','Browser','Tool')
}

function Read-FileSafe {
    param([string]$Path)
    try {
        return [System.IO.File]::ReadAllText($Path, [System.Text.Encoding]::UTF8)
    } catch {
        try { return (Get-Content -Raw -LiteralPath $Path -ErrorAction Stop) } catch { return '' }
    }
}

function Get-RegexMatches {
    param([string]$Text, [string]$Pattern)
    if (-not $Text) { return @() }
    $result = New-Object System.Collections.Generic.List[string]
    $matches = [regex]::Matches($Text, $Pattern)
    foreach ($m in $matches) {
        if ($m.Groups.Count -ge 2 -and $m.Groups[1].Value) {
            $v = $m.Groups[1].Value.Trim()
            if ($v -and $v.Length -le 80) { [void]$result.Add($v) }
        }
    }
    return ($result | Select-Object -Unique)
}

function ConvertTo-SafeFileName {
    param([string]$Text)
    $name = if ($Text) { $Text } else { 'sample' }
    $invalid = [IO.Path]::GetInvalidFileNameChars()
    foreach ($c in $invalid) { $name = $name.Replace($c, '-') }
    $name = [regex]::Replace($name, '\s+', '-')
    $name = [regex]::Replace($name, '-+', '-').Trim('-')
    if (-not $name) { $name = 'sample' }
    if ($name.Length -gt 80) { $name = $name.Substring(0, 80).Trim('-') }
    return $name
}

function Write-ProjectSnippet {
    param(
        [string]$ProjectName,
        [string]$ProjectDir,
        [string]$SourceLabel,
        [array]$CsFiles,
        [int]$Index
    )
    if ($SkipSnippets -or -not $SnippetDir -or -not $CsFiles) { return $null }

    $safeName = ConvertTo-SafeFileName -Text $ProjectName
    $snippetName = ('{0:D4}-{1}.md' -f $Index, $safeName)
    $snippetPath = Join-Path $SnippetDir $snippetName

    $preferred = @()
    $preferred += @($CsFiles | Where-Object { $_.Name -match '(?i)^Command.*\.cs$|.*Command.*\.cs$' -and $_.Name -notmatch '(?i)\.Designer\.cs$' })
    $preferred += @($CsFiles | Where-Object { $_.Name -match '(?i)^App.*\.cs$|.*Application.*\.cs$|UIRibbon\.cs|Utils\.cs|Helper.*\.cs' -and $_.Name -notmatch '(?i)\.Designer\.cs$' })
    $preferred += @($CsFiles | Where-Object { $_.Name -notmatch '(?i)\.Designer\.cs$' })
    $preferred = @($preferred | Select-Object -Unique -First 3)

    if (-not $preferred) { return $null }

    $remaining = $MaxSnippetLines
    $md = [System.Text.StringBuilder]::new()
    [void]$md.AppendLine("# Sample Snippet: $ProjectName")
    [void]$md.AppendLine('')
    if (-not $SourceLabel) { $SourceLabel = Split-Path $ProjectDir -Leaf }
    [void]$md.AppendLine("Source project: ``$SourceLabel``")
    [void]$md.AppendLine('')
    [void]$md.AppendLine('This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.')
    [void]$md.AppendLine('')

    foreach ($f in $preferred) {
        if ($remaining -le 0) { break }
        $rel = $f.FullName.Substring($ProjectDir.Length).TrimStart('\','/')
        $lines = @((Read-FileSafe $f.FullName) -split "`r?`n")
        if ($lines.Count -eq 0) { continue }
        $take = [Math]::Min($remaining, [Math]::Min($lines.Count, 90))
        [void]$md.AppendLine("## $rel")
        [void]$md.AppendLine('')
        [void]$md.AppendLine('```csharp')
        [void]$md.AppendLine(($lines | Select-Object -First $take) -join "`n")
        if ($lines.Count -gt $take) { [void]$md.AppendLine('// ... truncated ...') }
        [void]$md.AppendLine('```')
        [void]$md.AppendLine('')
        $remaining -= $take
    }

    [System.IO.File]::WriteAllText($snippetPath, $md.ToString(), [System.Text.UTF8Encoding]::new($false))
    return $snippetPath
}

$csprojs = @(Get-ChildItem $Root -Recurse -Filter '*.csproj' -ErrorAction SilentlyContinue)
Write-Host "Found $($csprojs.Count) csproj files under $Root" -ForegroundColor Cyan

$entries = New-Object System.Collections.Generic.List[object]
$i = 0
foreach ($csproj in $csprojs) {
    $i++
    if ($i % 20 -eq 0) { Write-Host "  processed $i / $($csprojs.Count) ..." -ForegroundColor DarkGray }

    $projDir = Split-Path $csproj.FullName -Parent
    $projName = [IO.Path]::GetFileNameWithoutExtension($csproj.FullName)

    $relFromRoot = $csproj.FullName.Substring($Root.Length).TrimStart('\','/')
    $segments = $relFromRoot -split '[\\/]'
    $author = if ($segments.Count -gt 0) { $segments[0] } else { '' }

    # relPath = "existingCodes\...\<projectDir>"
    $projDirRelFromRoot = $relFromRoot -replace '[\\/][^\\/]+$',''
    $rootLeaf = Split-Path $Root -Leaf
    $relPath  = if ($projDirRelFromRoot) { "$rootLeaf\$projDirRelFromRoot" } else { $rootLeaf }

    $csFiles = @(Get-ChildItem $projDir -Recurse -Filter '*.cs' -ErrorAction SilentlyContinue |
                 Where-Object { $_.FullName -notmatch '\\(bin|obj)\\' })

    if (-not $csFiles) {
        $entries.Add([pscustomobject]@{
            Name = $projName; Author = $author; Path = $relPath
            Actions = @(); Dialogs = @(); Categories = @(); Parameters = @()
            APIs = @(); UI = ''; Integrations = @()
            Snippet = ''
            Domain = 'Uncategorized'; Signals = 0
        })
        continue
    }

    $sb = [System.Text.StringBuilder]::new()
    foreach ($f in $csFiles) { [void]$sb.AppendLine((Read-FileSafe $f.FullName)) }
    $allText = $sb.ToString()

    $actions    = Get-RegexMatches $allText 'new\s+Transaction\s*\(\s*[\w\.]+\s*,\s*"([^"\r\n]+)"'
    $dialogs    = Get-RegexMatches $allText 'TaskDialog\.Show\s*\(\s*"([^"\r\n]+)"'
    $categories = Get-RegexMatches $allText 'BuiltInCategory\.OST_(\w+)'
    $parameters = Get-RegexMatches $allText 'BuiltInParameter\.(\w+)'

    $apis = New-Object System.Collections.Generic.List[string]
    if ($allText -match 'FilteredElementCollector')                       { [void]$apis.Add('FilteredElementCollector') }
    if ($allText -match 'PickObject|PickElementsByRectangle|PickPoint')   { [void]$apis.Add('Pick (Selection)') }
    if ($allText -match 'ElementTransformUtils')                          { [void]$apis.Add('ElementTransformUtils') }
    if ($allText -match 'Wall\.Create|\.NewFamilyInstance|Create\.NewFamilyInstance') { [void]$apis.Add('Element creation') }
    if ($allText -match 'IExternalApplication|CreateRibbonPanel|CreateRibbonTab')     { [void]$apis.Add('Ribbon (IExternalApplication)') }
    if ($allText -match 'IExternalEventHandler|ExternalEvent\.Create')                { [void]$apis.Add('Modeless (ExternalEvent)') }
    if ($allText -match 'TransactionGroup')                                            { [void]$apis.Add('TransactionGroup') }
    if ($allText -match 'ReferenceIntersector|FindReferencesWithContextByDirection')  { [void]$apis.Add('RayCast / ReferenceIntersector') }
    if ($allText -match 'FamilyManager')                                               { [void]$apis.Add('FamilyManager (family editor)') }
    if ($allText -match 'SharedParameter|BindingMap')                                  { [void]$apis.Add('Shared parameters') }

    $ui = ''
    if ($allText -match 'System\.Windows\.Forms') { $ui = 'WinForms' }
    elseif ($allText -match 'PresentationFramework|xmlns="http://schemas\.microsoft\.com/winfx') { $ui = 'WPF' }

    $integrations = New-Object System.Collections.Generic.List[string]
    if ($allText -match 'Microsoft\.Office\.Interop\.Excel') { [void]$integrations.Add('Excel interop') }
    if ($allText -match 'NPOI\.')                            { [void]$integrations.Add('NPOI (xlsx)') }
    if ($allText -match 'OleDb|SQLite|SqlConnection')        { [void]$integrations.Add('Database') }
    if ($allText -match 'Newtonsoft\.Json|System\.Text\.Json'){ [void]$integrations.Add('JSON') }
    if ($allText -match 'HttpClient|WebClient|WebRequest')   { [void]$integrations.Add('HTTP') }

    # Domain classification: score each domain against a corpus of project name + categories + first dialogs/actions
    $haystack = (@($projName) + @($categories) + @($actions | Select-Object -First 3) + @($dialogs | Select-Object -First 3)) -join ' '
    $scores = @{}
    foreach ($dom in $domainKeywords.Keys) {
        $hit = 0
        foreach ($kw in $domainKeywords[$dom]) {
            if ($haystack -match "(?i)$([regex]::Escape($kw))") { $hit++ }
        }
        $scores[$dom] = $hit
    }
    $best = $scores.GetEnumerator() | Sort-Object Value -Descending | Select-Object -First 1
    $domain = if ($best.Value -gt 0) { $best.Key } else { 'Uncategorized' }

    $signalCount = ($actions.Count + $dialogs.Count + $categories.Count + $parameters.Count + $apis.Count)

    # Bilingual tag set: union of EN + ZH synonyms for every glossary row that
    # matched any signal (name, actions, dialogs, categories, or parameters).
    $tagHaystack = (@($projName) + @($actions) + @($dialogs) + @($categories) + @($parameters)) -join ' '
    $tags = Get-BilingualTags -Haystack $tagHaystack -Glossary $glossary
    $snippetPath = Write-ProjectSnippet -ProjectName $projName -ProjectDir $projDir -SourceLabel $relPath -CsFiles $csFiles -Index $i

    $entries.Add([pscustomobject]@{
        Name       = $projName
        Author     = $author
        Path       = $relPath
        Actions    = @($actions    | Select-Object -First $MaxItemsPerField)
        Dialogs    = @($dialogs    | Select-Object -First $MaxItemsPerField)
        Categories = @($categories | Select-Object -First $MaxItemsPerField)
        Parameters = @($parameters | Select-Object -First $MaxItemsPerField)
        APIs       = @($apis)
        UI         = $ui
        Integrations = @($integrations)
        Tags       = @($tags)
        Snippet    = $snippetPath
        Domain     = $domain
        Signals    = $signalCount
    })
}

# Emit INDEX.md
$domainOrder = @('Architecture','Structural','MEP','Export/IO','Utilities','Uncategorized')

$md = [System.Text.StringBuilder]::new()
[void]$md.AppendLine('# Existing Plug-ins Index')
[void]$md.AppendLine('')
[void]$md.AppendLine("Auto-generated catalog of $($entries.Count) Revit plug-ins under ``$($rootLeaf)/``. Each entry summarizes signals mined from the source (Transaction labels, TaskDialog titles, BuiltInCategory / BuiltInParameter references, UI framework, integrations) and links to a compact source snippet when available.")
[void]$md.AppendLine('')
[void]$md.AppendLine('**Regenerate** when you add or change plug-ins:')
[void]$md.AppendLine('')
[void]$md.AppendLine('```powershell')
[void]$md.AppendLine('powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1')
[void]$md.AppendLine('```')
[void]$md.AppendLine('')
[void]$md.AppendLine('**Search** (agents should always `rg` this file first before reading snippets or optional full source).')
[void]$md.AppendLine('Each entry carries a `Tags:` line seeded from `.cursor/skills/glossary.zh-en.md`')
[void]$md.AppendLine('that unions English and Chinese synonyms, so either-language grep finds the same entry:')
[void]$md.AppendLine('')
[void]$md.AppendLine('```powershell')
[void]$md.AppendLine('# Bilingual regex: English OR Chinese term, both hit the same entries.')
[void]$md.AppendLine('rg -i "wall|墙.*material|材质" .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8')
[void]$md.AppendLine('rg -i "pipe|管道.*elevation|高程"  .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8')
[void]$md.AppendLine('rg -i "excel|表格"                  .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8')
[void]$md.AppendLine('rg -i "hanger|吊架"                 .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8')
[void]$md.AppendLine('```')
[void]$md.AppendLine('')

foreach ($dom in $domainOrder) {
    $group = @($entries | Where-Object { $_.Domain -eq $dom } | Sort-Object Name)
    if (-not $group) { continue }
    [void]$md.AppendLine("## $dom ($($group.Count))")
    [void]$md.AppendLine('')
    foreach ($e in $group) {
        [void]$md.AppendLine("### $($e.Name)")
        [void]$md.AppendLine("- Path: $($e.Path)")
        [void]$md.AppendLine("- Author: $($e.Author)")
        if ($e.Actions.Count    -gt 0) { [void]$md.AppendLine("- Actions: " + (($e.Actions    | ForEach-Object { '"' + $_ + '"' }) -join ', ')) }
        if ($e.Dialogs.Count    -gt 0) { [void]$md.AppendLine("- Dialogs: " + (($e.Dialogs    | ForEach-Object { '"' + $_ + '"' }) -join ', ')) }
        if ($e.Categories.Count -gt 0) { [void]$md.AppendLine("- Categories: " + (($e.Categories | ForEach-Object { 'OST_' + $_ }) -join ', ')) }
        if ($e.Parameters.Count -gt 0) { [void]$md.AppendLine("- Parameters: " + ($e.Parameters -join ', ')) }
        if ($e.APIs.Count       -gt 0) { [void]$md.AppendLine("- APIs: " + ($e.APIs -join ', ')) }
        if ($e.UI)                     { [void]$md.AppendLine("- UI: $($e.UI)") }
        if ($e.Integrations.Count -gt 0) { [void]$md.AppendLine("- Integrations: " + ($e.Integrations -join ', ')) }
        if ($e.Tags.Count         -gt 0) { [void]$md.AppendLine("- Tags: " + ($e.Tags -join ', ')) }
        if ($e.Snippet)                  { [void]$md.AppendLine("- Snippet: $($e.Snippet)") }
        [void]$md.AppendLine("- Description: TODO (hand-edit)")
        [void]$md.AppendLine('')
    }
}

[System.IO.File]::WriteAllText($Output, $md.ToString(), [System.Text.UTF8Encoding]::new($false))

$byDomain = $entries | Group-Object Domain | Sort-Object Name
Write-Host ''
Write-Host "Wrote $($entries.Count) entries to $Output" -ForegroundColor Green
Write-Host 'By domain:' -ForegroundColor Cyan
foreach ($g in $byDomain) { Write-Host ("  {0,-14} {1,4}" -f $g.Name, $g.Count) }
$weak = @($entries | Where-Object { $_.Signals -eq 0 })
if ($weak) {
    Write-Host ''
    Write-Host "Warning: $($weak.Count) projects had zero signals (no Transaction / TaskDialog / BuiltInCategory / BuiltInParameter found). Review manually:" -ForegroundColor Yellow
    $weak | Select-Object -First 10 | ForEach-Object { Write-Host "  - $($_.Name) ($($_.Path))" }
}
