<#
.SYNOPSIS
    Migrate Revit API markdown sidecars from GUID filenames to HelpId-based stems
    and rewrite symbols.jsonl `md` paths to match.

.PARAMETER DocsDir
    Path to the revit-api-lookup docs folder (default: .cursor\skills\revit-api-lookup\docs).

.PARAMETER WhatIf
    Print planned renames and skip file/jsonl changes.

.PARAMETER NoBackup
    Do not backup symbols.jsonl before rewriting.
#>
[CmdletBinding()]
param(
    [string]$DocsDir = ".cursor\skills\revit-api-lookup\docs",
    [switch]$WhatIf,
    [switch]$NoBackup
)

$ErrorActionPreference = 'Stop'

if (-not $PSScriptRoot) { throw 'PSScriptRoot is empty; run as: powershell -File scripts\rename-api-md-sidecars.ps1' }
$repoRoot = Split-Path $PSScriptRoot -Parent

$docsAbs = if ([IO.Path]::IsPathRooted($DocsDir)) {
    $DocsDir
} else {
    Join-Path $repoRoot $DocsDir.TrimStart('\').Replace('/', [IO.Path]::DirectorySeparatorChar)
}
$docsAbs = (Resolve-Path $docsAbs).Path

$mdRoot    = Join-Path $docsAbs 'md'
$jsonlAbs = Join-Path $docsAbs 'symbols.jsonl'

if (-not (Test-Path $jsonlAbs)) { throw "symbols.jsonl not found: $jsonlAbs" }
if (-not (Test-Path $mdRoot))   { throw "md folder not found: $mdRoot" }

. (Join-Path $PSScriptRoot 'api-md-naming.ps1')

function Get-Sha8 {
    param([string]$Text)
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($Text)
    $h = [System.Security.Cryptography.SHA1]::Create().ComputeHash($bytes)
    return ([BitConverter]::ToString($h).Replace('-', '').Substring(0, 8)).ToLowerInvariant()
}

function Normalize-MdRel([string]$Rel) {
    if ([string]::IsNullOrWhiteSpace($Rel)) { return '' }
    ($Rel -replace '\\', '/').TrimStart('/')
}

Write-Host "Loading $jsonlAbs ..." -ForegroundColor Cyan
$records = New-Object System.Collections.Generic.List[hashtable]
$reader = [System.IO.StreamReader]::new($jsonlAbs)
try {
    while ($null -ne ($line = $reader.ReadLine())) {
        if ([string]::IsNullOrWhiteSpace($line)) { continue }
        try {
            $obj = $line | ConvertFrom-Json
        } catch {
            throw "Invalid JSONL line: $($line.Substring(0, [Math]::Min(140, $line.Length))) ..."
        }
        $h = @{}
        foreach ($p in $obj.PSObject.Properties) { $h[$p.Name] = $p.Value }
        [void]$records.Add($h)
    }
} finally {
    $reader.Dispose()
}

Write-Host "Loaded $($records.Count) records." -ForegroundColor Green

$buckets = @{}
foreach ($h in $records) {
    $id = [string]$h['id']
    if (-not $id) { continue }
    $stem = Get-ApiSidecarStemFromHelpId -HelpId $id
    if (-not $buckets[$stem]) {
        $buckets[$stem] = [System.Collections.Generic.List[string]]::new()
    }
    [void]$buckets[$stem].Add($id)
}

$idToStem = @{}
foreach ($stem in @($buckets.Keys)) {
    $ids = @($buckets[$stem] | Sort-Object -Unique)
    foreach ($hid in $ids) {
        if ($ids.Count -le 1) {
            [void]$idToStem.Add($hid, $stem)
        } else {
            [void]$idToStem.Add($hid, ($stem + '__' + (Get-Sha8 -Text $hid)))
        }
    }
}

$oldMdToNew = @{}
foreach ($h in $records) {
    if (-not $h['md']) { continue }
    $id = [string]$h['id']
    if (-not $idToStem.ContainsKey($id)) {
        Write-Warning "No stem for id '$id'"
        continue
    }

    $oldNorm = Normalize-MdRel ([string]$h['md'])
    $stemFin = [string]$idToStem[$id]
    $newNorm = "md/$stemFin.md".Replace('\\', '/')

    if ($oldMdToNew.ContainsKey($oldNorm)) {
        $ex = [string]$oldMdToNew[$oldNorm]
        if ($ex -ne $newNorm) {
            throw "Conflict for md path '$oldNorm': '$ex' vs '$newNorm'"
        }
    } else {
        [void]$oldMdToNew.Add($oldNorm, $newNorm)
    }
}

Write-Host ("Distinct md file renames: {0}" -f $oldMdToNew.Count) -ForegroundColor Cyan

if ($WhatIf) {
    $i = 0
    foreach ($k in ($oldMdToNew.Keys | Sort-Object)) {
        $i++
        if ($i -le 30) { Write-Host "  $k  ->  $($oldMdToNew[$k])" -ForegroundColor Gray }
    }
    if ($oldMdToNew.Count -gt 30) { Write-Host "  ... $($oldMdToNew.Count - 30) more" -ForegroundColor Gray }
    Write-Host "WhatIf: no files modified." -ForegroundColor Yellow
    exit 0
}

if (-not $NoBackup) {
    $bak = Join-Path $docsAbs ('symbols.jsonl.bak.' + (Get-Date -Format 'yyyyMMddHHmmss'))
    Copy-Item -LiteralPath $jsonlAbs -Destination $bak -Force
    Write-Host "Backup: $bak" -ForegroundColor DarkGray
}

foreach ($coll in @( $oldMdToNew.GetEnumerator() | Where-Object { $_.Key -ne $_.Value } )) {
    $oldAbs = Join-Path $docsAbs (($coll.Key) -replace '/', [IO.Path]::DirectorySeparatorChar)
    $newAbs = Join-Path $docsAbs (($coll.Value) -replace '/', [IO.Path]::DirectorySeparatorChar)
    if ($oldAbs -ieq $newAbs) { continue }
    if ((Test-Path -LiteralPath $newAbs)) {
        throw "Target exists (would overwrite): $newAbs"
    }
}

$order = @($oldMdToNew.Keys | Sort-Object)
foreach ($oldRel in $order) {
    $newRel = [string]$oldMdToNew[$oldRel]
    $oldAbs = Join-Path $docsAbs (($oldRel) -replace '/', [IO.Path]::DirectorySeparatorChar)
    $newAbs = Join-Path $docsAbs (($newRel) -replace '/', [IO.Path]::DirectorySeparatorChar)
    if ($oldAbs -ieq $newAbs) { continue }

    if (-not (Test-Path -LiteralPath $oldAbs)) {
        Write-Warning "Missing source (skip): $oldAbs"
        continue
    }

    $newDir = Split-Path -Parent $newAbs
    if (-not (Test-Path -LiteralPath $newDir)) {
        New-Item -ItemType Directory -Force -Path $newDir | Out-Null
    }
    Move-Item -LiteralPath $oldAbs -Destination $newAbs -Force
}

$tmpOut = $jsonlAbs + '.new'
if (Test-Path -LiteralPath $tmpOut) { Remove-Item -LiteralPath $tmpOut -Force }

$sw = [System.IO.StreamWriter]::new($tmpOut, $false, [System.Text.UTF8Encoding]::new($false))
try {
    foreach ($h in $records) {
        if ($h.ContainsKey('md')) {
            $on = Normalize-MdRel ([string]$h['md'])
            if ($oldMdToNew.ContainsKey($on)) {
                $h['md'] = $oldMdToNew[$on]
            }
        }
        $line = ($h | ConvertTo-Json -Depth 30 -Compress)
        [void]$sw.WriteLine($line)
    }
} finally {
    $sw.Dispose()
}

Move-Item -LiteralPath $tmpOut -Destination $jsonlAbs -Force
Write-Host "Updated $jsonlAbs" -ForegroundColor Green
Write-Host "Done." -ForegroundColor Green
