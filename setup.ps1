<#
.SYNOPSIS
    One-shot setup for the Revit Add-in Skills workspace.

.DESCRIPTION
    Run this once after cloning the repo. It:
      1. Verifies Revit 2024 is installed and a C# builder is available.
      2. Locates RevitAPI.chm (from the Revit SDK or prompts you).
      3. Decompiles the CHM into HTML (~3 min, ~420 MB on disk, gitignored).
      4. Builds the structured symbol index + markdown sidecars (~3 min, ~30 MB, gitignored).
      5. Builds the existingCodes\INDEX.md catalog (~3 sec).

    Safe to re-run: each step skips if its output already exists unless -Force.

.PARAMETER ChmPath
    Explicit path to RevitAPI.chm. If omitted, setup checks the skill folder
    and then common SDK install locations.

.PARAMETER Force
    Re-run all generation steps, overwriting existing output.

.PARAMETER SkipApiIndex
    Skip the CHM decompile + symbol index build (useful if you only want
    existingCodes\INDEX.md rebuilt).

.EXAMPLE
    # Default: detect everything, run all steps that need running.
    .\setup.ps1

.EXAMPLE
    # Point at a custom CHM location and rebuild everything from scratch.
    .\setup.ps1 -ChmPath 'D:\RevitSDK\RevitAPI.chm' -Force
#>
[CmdletBinding()]
param(
    [string]$ChmPath,
    [switch]$Force,
    [switch]$SkipApiIndex
)

$ErrorActionPreference = 'Stop'
$repoRoot   = $PSScriptRoot
$skillDir   = Join-Path $repoRoot '.cursor\skills\revit-api-lookup'
$docsDir    = Join-Path $skillDir 'docs'
$htmlDir    = Join-Path $docsDir 'html'
$jsonl      = Join-Path $docsDir 'symbols.jsonl'
$existing   = Join-Path $repoRoot 'existingCodes'
$indexFile  = Join-Path $existing 'INDEX.md'
$builtInChm = Join-Path $skillDir 'RevitAPI.chm'

function Write-Step   ([string]$m) { Write-Host "==> $m" -ForegroundColor Cyan }
function Write-Ok     ([string]$m) { Write-Host "  ok: $m" -ForegroundColor Green }
function Write-Warn2  ([string]$m) { Write-Host "  !!  $m" -ForegroundColor Yellow }
function Write-Fail   ([string]$m) { Write-Host "  XX  $m" -ForegroundColor Red }

# ---------------------------------------------------------------------------
# 1. Prerequisites
# ---------------------------------------------------------------------------
Write-Step 'Checking prerequisites'

$revitDll = 'C:\Program Files\Autodesk\Revit 2024\RevitAPI.dll'
$revitInstallOverride = $env:RevitInstallPath
if ($revitInstallOverride) {
    $revitDll = Join-Path $revitInstallOverride 'RevitAPI.dll'
}
if (Test-Path $revitDll) {
    Write-Ok "Revit 2024 found: $(Split-Path $revitDll -Parent)"
} else {
    Write-Warn2 "Revit 2024 not found at the default path. If it's installed elsewhere, set the env var before using build/deploy:"
    Write-Warn2 "  `$env:RevitInstallPath = 'D:\Your\Path\To\Revit 2024'"
}

$builderFound = $false
$msbuild = Get-Command msbuild -ErrorAction SilentlyContinue
$dotnet  = Get-Command dotnet  -ErrorAction SilentlyContinue
if ($msbuild) { Write-Ok "MSBuild on PATH: $($msbuild.Path)"; $builderFound = $true }
elseif ($dotnet) { Write-Ok "dotnet CLI on PATH: $($dotnet.Path) (will be used as builder)"; $builderFound = $true }
else {
    Write-Fail 'No builder found. Install one of:'
    Write-Fail '  - Visual Studio Build Tools (for msbuild), or'
    Write-Fail '  - .NET SDK (for dotnet CLI)  https://dotnet.microsoft.com/download'
}

# Ripgrep (shipped with Cursor/VSCode). Only warn.
$rg = Get-Command rg -ErrorAction SilentlyContinue
if ($rg) {
    Write-Ok "ripgrep on PATH: $($rg.Path)"
} else {
    Write-Ok 'ripgrep will be auto-detected from Cursor/VSCode by the API-lookup script.'
}

# ---------------------------------------------------------------------------
# 2. Locate RevitAPI.chm
# ---------------------------------------------------------------------------
if (-not $SkipApiIndex) {
    Write-Step 'Locating RevitAPI.chm'

    $chm = $null
    $candidates = @()
    if ($ChmPath)                 { $candidates += $ChmPath }
    if (Test-Path $builtInChm)    { $candidates += $builtInChm }
    $candidates += @(
        'C:\Program Files\Autodesk\Revit 2024 SDK\RevitAPI.chm',
        'C:\Autodesk\Revit 2024 SDK\RevitAPI.chm'
    )
    foreach ($c in $candidates | Select-Object -Unique) {
        if ($c -and (Test-Path $c)) { $chm = (Resolve-Path $c).Path; break }
    }

    if (-not $chm) {
        Write-Fail 'RevitAPI.chm not found.'
        Write-Fail 'Install the Revit 2024 SDK, or pass -ChmPath <full path>.'
        Write-Fail '  SDK download: https://www.autodesk.com/developer-network/platform-technologies/revit'
        exit 1
    }
    Write-Ok "Using CHM: $chm"

    if ($chm -ne $builtInChm) {
        Copy-Item $chm $builtInChm -Force
        Write-Ok "Copied to $builtInChm"
    }

    # -----------------------------------------------------------------------
    # 3. Decompile CHM -> HTML
    # -----------------------------------------------------------------------
    Write-Step 'Step 1/3: decompile CHM -> HTML'
    $needDecompile = $Force -or -not (Test-Path $htmlDir) -or `
        ((Get-ChildItem $htmlDir -Filter '*.htm' -ErrorAction SilentlyContinue | Measure-Object).Count -lt 100)
    if ($needDecompile) {
        & powershell -ExecutionPolicy Bypass -File (Join-Path $skillDir 'scripts\decompile-chm.ps1')
        if ($LASTEXITCODE -ne 0) { Write-Fail 'Decompile failed.'; exit $LASTEXITCODE }
    } else {
        $count = (Get-ChildItem $htmlDir -Filter '*.htm').Count
        Write-Ok "Already decompiled ($count .htm files); skip. Use -Force to redo."
    }

    # -----------------------------------------------------------------------
    # 4. Build symbol index + md sidecars
    # -----------------------------------------------------------------------
    Write-Step 'Step 2/3: build symbol index (JSONL + markdown sidecars)'
    $needIndex = $Force -or -not (Test-Path $jsonl) -or ((Get-Item $jsonl).Length -lt 1MB)
    if ($needIndex) {
        $args = @('-ExecutionPolicy','Bypass','-File', (Join-Path $repoRoot 'scripts\build-api-index.ps1'))
        if ($Force) { $args += '-Force' }
        & powershell @args
        if ($LASTEXITCODE -ne 0) { Write-Fail 'build-api-index failed.'; exit $LASTEXITCODE }
    } else {
        Write-Ok "Symbol index already present ($([math]::Round((Get-Item $jsonl).Length / 1MB, 1)) MB); skip. Use -Force to rebuild."
    }
} else {
    Write-Warn2 'Skipping API index (--SkipApiIndex). API-lookup skill will not work until this is run.'
}

# ---------------------------------------------------------------------------
# 5. Build existingCodes catalog
# ---------------------------------------------------------------------------
Write-Step 'Step 3/3: build existingCodes\INDEX.md'
if (-not (Test-Path $existing)) {
    Write-Warn2 "No existingCodes\ directory found; skip. (That folder is where the scaffold skill looks for reference plug-ins.)"
} else {
    & powershell -ExecutionPolicy Bypass -File (Join-Path $repoRoot 'scripts\build-index.ps1')
    if ($LASTEXITCODE -ne 0) { Write-Fail 'build-index failed.'; exit $LASTEXITCODE }
    if (Test-Path $indexFile) {
        $entries = (Select-String -Path $indexFile -Pattern '^### ' -AllMatches | Measure-Object).Count
        Write-Ok "INDEX.md written with $entries entries."
    }
}

# ---------------------------------------------------------------------------
# Done
# ---------------------------------------------------------------------------
Write-Host ''
Write-Host 'Setup complete.' -ForegroundColor Green
Write-Host 'Open this folder in Cursor and ask the agent:'
Write-Host '  "Create a Revit add-in that ..."' -ForegroundColor DarkGray
Write-Host ''
if (-not $builderFound) {
    Write-Warn2 'Reminder: install a C# builder (msbuild or dotnet SDK) before building any add-in.'
}
