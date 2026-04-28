<#
.SYNOPSIS
    Maintainer-only decompile of RevitAPI.chm into ./docs/html for rebuilding
    the packaged API symbol index.

.DESCRIPTION
    Uses Windows built-in hh.exe -decompile to extract HTML from the CHM.
    Target: .cursor/skills/revit-api-lookup/docs/

.PARAMETER ChmPath
    Path to RevitAPI.chm. Defaults to the CHM sitting next to this script's skill folder.

.EXAMPLE
    pwsh -File .cursor/skills/revit-api-lookup/scripts/decompile-chm.ps1

.EXAMPLE
    pwsh -File .cursor/skills/revit-api-lookup/scripts/decompile-chm.ps1 -ChmPath "C:\Program Files\Autodesk\Revit 2024 SDK\RevitAPI.chm"
#>
[CmdletBinding()]
param(
    [string]$ChmPath
)

$ErrorActionPreference = 'Stop'

$skillDir = Split-Path -Parent $PSScriptRoot
$docsDir  = Join-Path $skillDir 'docs'

if (-not $ChmPath) {
    $candidates = @(
        (Join-Path $skillDir 'RevitAPI.chm'),
        (Join-Path $skillDir 'Revit.chm'),
        'C:\Program Files\Autodesk\Revit 2024 SDK\RevitAPI.chm'
    )
    $ChmPath = $candidates | Where-Object { Test-Path $_ } | Select-Object -First 1
}

if (-not $ChmPath -or -not (Test-Path $ChmPath)) {
    Write-Error "Could not locate RevitAPI.chm. Pass -ChmPath or place the file at: $skillDir\RevitAPI.chm"
    exit 1
}

$ChmPath = (Resolve-Path $ChmPath).Path
Write-Host "CHM: $ChmPath"

if (Test-Path $docsDir) {
    Write-Host "Removing existing $docsDir ..."
    Remove-Item $docsDir -Recurse -Force
}
New-Item -ItemType Directory -Path $docsDir | Out-Null

$hh = Join-Path $env:WINDIR 'hh.exe'
if (-not (Test-Path $hh)) {
    Write-Error "hh.exe not found at $hh. This script only runs on Windows."
    exit 1
}

Write-Host "Decompiling to $docsDir ..."
# hh.exe -decompile <outdir> <chm>  (synchronous, no progress output)
& $hh -decompile $docsDir $ChmPath | Out-Null

$count = (Get-ChildItem $docsDir -Recurse -Filter *.htm -ErrorAction SilentlyContinue | Measure-Object).Count
if ($count -eq 0) {
    Write-Error "Decompile produced no .htm files. CHM may be DRM-protected or corrupted."
    exit 1
}

Write-Host "Done. Extracted $count .htm files." -ForegroundColor Green
Write-Host "Next: use scripts/search-api.ps1 -Query '<terms>' to search."
