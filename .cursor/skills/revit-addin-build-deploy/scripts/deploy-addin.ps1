<#
.SYNOPSIS
    Build a Revit 2024 C# add-in and install it into %AppData%\Autodesk\Revit\Addins\<ver>\.

.PARAMETER ProjectPath
    Path to the SDK-style .csproj.

.PARAMETER Configuration
    Debug or Release. Default Release.

.PARAMETER RevitVersion
    Revit version folder under Addins. Default 2024.

.PARAMETER AddinsDir
    Destination directory. Default %AppData%\Autodesk\Revit\Addins\<RevitVersion>.

.PARAMETER SkipBuild
    Skip MSBuild; deploy whatever is already in bin/.

.EXAMPLE
    # From the workspace root:
    powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1 -ProjectPath MyAddin\MyAddin.csproj
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$ProjectPath,
    [ValidateSet('Debug','Release')][string]$Configuration = 'Release',
    [string]$RevitVersion = '2024',
    [string]$AddinsDir,
    [switch]$SkipBuild
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path $ProjectPath)) { Write-Error "csproj not found: $ProjectPath"; exit 1 }
$ProjectPath = (Resolve-Path $ProjectPath).Path
$projDir = Split-Path $ProjectPath -Parent
$projName = [IO.Path]::GetFileNameWithoutExtension($ProjectPath)

if (-not $AddinsDir) {
    $AddinsDir = Join-Path $env:AppData "Autodesk\Revit\Addins\$RevitVersion"
}
if (-not (Test-Path $AddinsDir)) {
    New-Item -ItemType Directory -Path $AddinsDir -Force | Out-Null
}

function Resolve-Builder {
    # Returns @{ Kind = 'msbuild'|'dotnet'; Path = <exe> }
    $msbuild = Get-Command msbuild -ErrorAction SilentlyContinue
    if ($msbuild) { return @{ Kind='msbuild'; Path=$msbuild.Path } }

    $vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
    if (Test-Path $vswhere) {
        $path = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
        if ($path -and (Test-Path $path)) { return @{ Kind='msbuild'; Path=$path } }
    }

    # Fallback: dotnet CLI (its bundled MSBuild builds SDK-style net48 projects just fine,
    # provided the .NET Framework 4.8 targeting pack is installed).
    $dn = Get-Command dotnet -ErrorAction SilentlyContinue
    if ($dn) { return @{ Kind='dotnet'; Path=$dn.Path } }

    return $null
}

if (-not $SkipBuild) {
    $builder = Resolve-Builder
    if (-not $builder) {
        Write-Error "No builder found. Install one of: Visual Studio Build Tools (msbuild), or the .NET SDK (dotnet)."
        exit 1
    }
    Write-Host "Builder: $($builder.Kind) @ $($builder.Path)" -ForegroundColor DarkGray
    Write-Host "Building $projName ($Configuration, x64) ..." -ForegroundColor Cyan

    if ($builder.Kind -eq 'msbuild') {
        & $builder.Path $ProjectPath /t:Restore`;Build /p:Configuration=$Configuration /p:Platform=x64 /nologo /v:minimal
    } else {
        & $builder.Path build $ProjectPath -c $Configuration /p:Platform=x64 --nologo -v minimal
    }
    if ($LASTEXITCODE -ne 0) { Write-Error "Build failed (exit $LASTEXITCODE)"; exit $LASTEXITCODE }
}

# Output layout varies by tool and csproj settings. Possible shapes:
#   bin\<Config>\<Assembly>.dll                 (msbuild / AppendTargetFrameworkToOutputPath=false)
#   bin\<Config>\net48\<Assembly>.dll           (default .NET SDK, no suffix suppression)
#   bin\x64\<Config>\<Assembly>.dll             (dotnet build with Platform=x64)
#   bin\x64\<Config>\net48\<Assembly>.dll
# Strategy: recursive glob under bin\, pick the newest <projName>.dll.
$binRoot = Join-Path $projDir 'bin'
if (-not (Test-Path $binRoot)) {
    Write-Error "No bin\ directory under $projDir. Did the build succeed?"
    exit 1
}

$dll = Get-ChildItem $binRoot -Recurse -Filter "$projName.dll" -ErrorAction SilentlyContinue |
       Where-Object { $_.FullName -match "\\$([regex]::Escape($Configuration))\\" } |
       Sort-Object LastWriteTime -Descending | Select-Object -First 1
if (-not $dll) {
    # Last-ditch: any dll named after the project anywhere in bin\
    $dll = Get-ChildItem $binRoot -Recurse -Filter "$projName.dll" -ErrorAction SilentlyContinue |
           Sort-Object LastWriteTime -Descending | Select-Object -First 1
}
if (-not $dll) { Write-Error "Could not find $projName.dll anywhere under $binRoot"; exit 1 }

$binDir = Split-Path $dll.FullName -Parent
Write-Host "Build output: $binDir" -ForegroundColor DarkGray

$pdb = Join-Path $binDir "$($dll.BaseName).pdb"
$addinSrc = Get-ChildItem $projDir -Filter '*.addin' -ErrorAction SilentlyContinue | Select-Object -First 1
if (-not $addinSrc) {
    $addinSrc = Get-ChildItem $binDir -Filter '*.addin' -ErrorAction SilentlyContinue | Select-Object -First 1
}
if (-not $addinSrc) {
    Write-Error "No .addin manifest found in $projDir or $binDir."
    exit 1
}

$deployedDll = Join-Path $AddinsDir $dll.Name
$deployedAddin = Join-Path $AddinsDir $addinSrc.Name

# Rewrite <Assembly> path inside the addin manifest to the deployed DLL location.
# UTF-8: manifests often use Chinese in <Name>/<Text>; default encoding would corrupt XML.
[xml]$x = Get-Content -Raw -LiteralPath $addinSrc.FullName -Encoding UTF8
$changed = $false
foreach ($a in $x.SelectNodes('//AddIn')) {
    $asmNode = $a.SelectSingleNode('Assembly')
    if ($asmNode) {
        $asmNode.InnerText = $deployedDll
        $changed = $true
    }
}
if (-not $changed) { Write-Warning "No <Assembly> node found in $($addinSrc.Name); manifest may be malformed." }

# Copy DLL (+ PDB if present).
Write-Host "Copying $($dll.Name) -> $AddinsDir" -ForegroundColor Cyan
Copy-Item $dll.FullName $deployedDll -Force
if (Test-Path $pdb) { Copy-Item $pdb (Join-Path $AddinsDir (Split-Path $pdb -Leaf)) -Force }

# Also copy any additional loose files next to the dll (dependencies excluding RevitAPI*)
Get-ChildItem $binDir -File | Where-Object {
    $_.Name -notmatch '^(RevitAPI|RevitAPIUI|AdWindows|UIFramework)' -and
    $_.Extension -in @('.dll','.pdb','.config') -and
    $_.FullName -ne $dll.FullName
} | ForEach-Object {
    Copy-Item $_.FullName (Join-Path $AddinsDir $_.Name) -Force
}

# Save the rewritten manifest.
$x.Save($deployedAddin)

Write-Host "" 
Write-Host "Deployed:" -ForegroundColor Green
Write-Host "  DLL     $deployedDll"
Write-Host "  Addin   $deployedAddin"
Write-Host ""
Write-Host "Launch Revit $RevitVersion to load the add-in." -ForegroundColor Yellow
