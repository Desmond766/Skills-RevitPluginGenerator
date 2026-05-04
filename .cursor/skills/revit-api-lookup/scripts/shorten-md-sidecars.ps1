<#
.SYNOPSIS
    Renames docs/md sidecars from long HelpId-based names to short deterministic
    names (md/s<hex>.md) and rewrites the "md" field in docs/symbols.jsonl.

.DESCRIPTION
    Each new filename is md/s + hex prefix of SHA256(UTF-8 symbol id), growing
    the prefix on collision until unique (extraordinarily rare).

.PARAMETER DocsDir
    Path to the skill's docs folder (containing symbols.jsonl and md/).
#>
[CmdletBinding()]
param(
    [string]$DocsDir = ''
)

if (-not $DocsDir) {
    $here = if ($PSScriptRoot) { $PSScriptRoot } else { Split-Path -Parent $MyInvocation.MyCommand.Path }
    $DocsDir = Join-Path (Split-Path -Parent $here) 'docs'
}

$ErrorActionPreference = 'Stop'

$jsonl = Join-Path $DocsDir 'symbols.jsonl'
$mdDir = Join-Path $DocsDir 'md'

if (-not (Test-Path $jsonl)) { Write-Error "Missing $jsonl"; exit 1 }
if (-not (Test-Path $mdDir)) { Write-Error "Missing $mdDir"; exit 1 }

function New-Stem {
    param(
        [string]$Id,
        [hashtable]$StemOwner
    )
    $sha = [System.Security.Cryptography.SHA256]::Create()
    $b = $sha.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($Id))
    for ($byteCount = 4; $byteCount -le 32; $byteCount++) {
        $hex = -join ($b[0..($byteCount - 1)] | ForEach-Object { $_.ToString('x2') })
        $owner = $StemOwner[$hex]
        if (-not $owner) {
            $StemOwner[$hex] = $Id
            return $hex
        }
        if ($owner -eq $Id) {
            return $hex
        }
    }
    throw "Could not allocate unique stem for id: $Id"
}

Write-Host "Reading $jsonl ..."
$lines = [System.IO.File]::ReadAllLines($jsonl)
$stemOwner = @{}
$newLines = New-Object string[] $lines.Length
$renames = New-Object System.Collections.Generic.List[object]

for ($i = 0; $i -lt $lines.Length; $i++) {
    $line = $lines[$i]
    if (-not $line) {
        $newLines[$i] = $line
        continue
    }
    if ($line -notmatch '"id":"([^"]+)"') { throw "Line $($i+1): missing id" }
    $id = $Matches[1]
    if ($line -notmatch '"md":"(md/[^"]+)"') { throw "Line $($i+1): missing md" }
    $oldMd = $Matches[1]
    $stem = New-Stem -Id $id -StemOwner $stemOwner
    $newMd = "md/s$stem.md"
    $newLines[$i] = [regex]::Replace($line, '"md":"md/[^"]+"', ('"md":"' + $newMd + '"'), 1)
    $renames.Add([pscustomobject]@{ Old = $oldMd; New = $newMd })
}

$byOld = @{}
foreach ($r in $renames) {
    if ($byOld.ContainsKey($r.Old) -and $byOld[$r.Old] -ne $r.New) {
        throw "Inconsistent mapping for $($r.Old)"
    }
    $byOld[$r.Old] = $r.New
}

$newTargets = @{}
foreach ($r in $renames) {
    if ($newTargets.ContainsKey($r.New) -and $newTargets[$r.New] -ne $r.Old) {
        throw "Duplicate target $($r.New)"
    }
    $newTargets[$r.New] = $r.Old
}

Write-Host "Renaming $($renames.Count) sidecars under $mdDir ..."

foreach ($r in $renames) {
    $oldFull = Join-Path $DocsDir $r.Old
    $newFull = Join-Path $DocsDir $r.New
    if (-not (Test-Path -LiteralPath $oldFull)) {
        Write-Warning "Missing (skipped): $oldFull"
        continue
    }
    if (Test-Path -LiteralPath $newFull) {
        throw "Target already exists: $newFull"
    }
    Move-Item -LiteralPath $oldFull -Destination $newFull -Force
}

Write-Host "Writing updated $jsonl"
[System.IO.File]::WriteAllLines($jsonl, $newLines)
Write-Host "Done."
