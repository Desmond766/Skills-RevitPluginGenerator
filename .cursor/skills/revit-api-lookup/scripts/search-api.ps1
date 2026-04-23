<#
.SYNOPSIS
    Search the Revit 2024 API docs. Defaults to the structured symbol index
    (fast, precise, ~10x fewer tokens); falls back to fulltext HTML grep.

.DESCRIPTION
    Two modes:

    1. Symbol mode (default): greps docs\symbols.jsonl by symbol name / parent
       type / kind, then prints the corresponding clean markdown sidecars.
       Use this for "what's the signature of X", "what does this enum value
       mean", "which methods live on this class".

    2. Fulltext mode (-Fulltext): greps the raw decompiled HTML for arbitrary
       phrase matches. Slower, noisier, but covers prose in remarks/examples
       that isn't in the symbol index.

    Symbol mode requires scripts\build-api-index.ps1 to have been run once.

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
    [string]$RgPath
)

$ErrorActionPreference = 'Stop'

$skillDir = Split-Path -Parent $PSScriptRoot
$docsDir  = Join-Path $skillDir 'docs'
$htmlDir  = Join-Path $docsDir  'html'
$mdDir    = Join-Path $docsDir  'md'
$jsonl    = Join-Path $docsDir  'symbols.jsonl'

if (-not (Test-Path $docsDir)) {
    Write-Error "Docs not found at $docsDir. Run scripts\decompile-chm.ps1 first."
    exit 1
}

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
Run: powershell -ExecutionPolicy Bypass -File scripts\build-api-index.ps1
"@
        exit 1
    }

    if (-not $Query -and -not $Parent -and -not $Kind) {
        Write-Error "Provide -Query, -Parent, or -Kind for symbol mode."
        exit 1
    }

    # Stream + filter in PowerShell. Faster than shelling out to rg for this
    # use case, and avoids the PowerShell/rg nested-quote escaping nightmare.
    $candidates = [System.Collections.Generic.List[object]]::new()
    $nameRx = if ($Query) { [regex]::new([regex]::Escape($Query), 'IgnoreCase') } else { $null }

    # Stream the jsonl line-by-line.
    $reader = [System.IO.StreamReader]::new($jsonl)
    try {
        while (-not $reader.EndOfStream) {
            $line = $reader.ReadLine()
            if (-not $line) { continue }

            if ($Parent -and $line -notmatch ('"parent":"' + [regex]::Escape($Parent) + '"')) { continue }
            if ($Kind   -and $line -notmatch ('"kind":"'   + [regex]::Escape($Kind)   + '"')) { continue }

            if ($nameRx) {
                $nameMatch = [regex]::Match($line, '"name":"([^"]+)"')
                if (-not $nameMatch.Success) { continue }
                if (-not $nameRx.IsMatch($nameMatch.Groups[1].Value)) { continue }
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
        return
    }

    # Rank: exact name match first, then startswith, then substring, then shortest name.
    $ranked = @($candidates | ForEach-Object {
        $l = $_
        $n = ''
        if ($l -match '"name":"([^"]+)"') { $n = $Matches[1] }
        $score = 100
        if ($Query) {
            if ($n -ieq $Query)         { $score = 0 }
            elseif ($n -ilike "$Query*") { $score = 1 }
            elseif ($n -imatch [regex]::Escape($Query)) { $score = 2 }
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
        Write-Error "HTML dir missing at $htmlDir."
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
