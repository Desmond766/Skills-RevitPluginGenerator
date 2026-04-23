<#
.SYNOPSIS
    Mine every existing Revit plug-in under existingCodes/ and emit INDEX.md.

.DESCRIPTION
    For each .csproj under -Root, walks its sibling .cs files (skipping bin/obj),
    extracts: Transaction labels, TaskDialog titles, BuiltInCategory refs,
    BuiltInParameter refs, key API usages, UI framework, integrations.
    Classifies each project into a domain by keyword score and writes a
    grep-friendly markdown catalog grouped by domain.

.PARAMETER Root
    Folder to scan. Default: existingCodes

.PARAMETER Output
    Where to write INDEX.md. Default: existingCodes\INDEX.md

.PARAMETER MaxItemsPerField
    Cap on items shown per Actions / Dialogs / Categories / Parameters. Default 5.

.EXAMPLE
    powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1

.NOTES
    Run once during project setup, then again whenever you add or change plug-ins
    under existingCodes/. The produced INDEX.md is consumed by the
    revit-addin-scaffold skill to pick the closest existing plug-in for reference.
#>
[CmdletBinding()]
param(
    [string]$Root = 'existingCodes',
    [string]$Output = 'existingCodes\INDEX.md',
    [int]$MaxItemsPerField = 5
)

$ErrorActionPreference = 'Stop'
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

if (-not (Test-Path $Root)) { Write-Error "Root '$Root' not found."; exit 1 }
$Root = (Resolve-Path $Root).Path
$outDir = Split-Path $Output -Parent
if ($outDir -and -not (Test-Path $outDir)) { New-Item -ItemType Directory -Path $outDir -Force | Out-Null }

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
        Domain     = $domain
        Signals    = $signalCount
    })
}

# Emit INDEX.md
$domainOrder = @('Architecture','Structural','MEP','Export/IO','Utilities','Uncategorized')

$md = [System.Text.StringBuilder]::new()
[void]$md.AppendLine('# Existing Plug-ins Index')
[void]$md.AppendLine('')
[void]$md.AppendLine("Auto-generated catalog of $($entries.Count) Revit plug-ins under ``$($rootLeaf)/``. Each entry summarizes signals mined from the source (Transaction labels, TaskDialog titles, BuiltInCategory / BuiltInParameter references, UI framework, integrations) plus a hand-editable ``Description:`` line.")
[void]$md.AppendLine('')
[void]$md.AppendLine('**Regenerate** when you add or change plug-ins:')
[void]$md.AppendLine('')
[void]$md.AppendLine('```powershell')
[void]$md.AppendLine('powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1')
[void]$md.AppendLine('```')
[void]$md.AppendLine('')
[void]$md.AppendLine('**Search** (agents should always `rg` this file first before reading source):')
[void]$md.AppendLine('')
[void]$md.AppendLine('```powershell')
[void]$md.AppendLine('rg -i "wall.*material|material.*wall" existingCodes\INDEX.md -A 7')
[void]$md.AppendLine('rg -i "export.*excel|excel.*export" existingCodes\INDEX.md -A 7')
[void]$md.AppendLine('rg -i "takeoff|quantity" existingCodes\INDEX.md -A 7')
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
