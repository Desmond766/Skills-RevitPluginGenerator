<#
.SYNOPSIS
    Deterministic, human-readable stem for Revit API markdown sidecar files.

.DESCRIPTION
    Sidecar files are named from Microsoft.Help.Id (e.g. M:Autodesk.Revit.DB.Wall.Create(...)).
    This keeps names stable across rebuilds and easier to grep/maintain than GUID filenames.

.NOTES
    Used by build-api-index.ps1 and rename-api-md-sidecars.ps1. Keep in sync.
#>

function Get-ApiSidecarStemFromHelpId {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$HelpId,
        [int]$MaxLen = 180
    )

    if ([string]::IsNullOrWhiteSpace($HelpId)) {
        return 'empty_help_id'
    }

    $colon = $HelpId.IndexOf(':')
    if ($colon -lt 0) {
        $rest = $HelpId
    } else {
        $rest = $HelpId.Substring($colon + 1)
    }

    # Dots separate namespace parts → underscores; strip everything else that is not alphanumeric.
    $stem = $rest -replace '\.', '_'
    $stem = $stem -replace '[^a-zA-Z0-9_]', '_'
    $stem = $stem -replace '_+', '_'
    $stem = $stem -replace '^_|_$', ''

    if ([string]::IsNullOrWhiteSpace($stem)) {
        $h = [System.Security.Cryptography.SHA1]::Create().ComputeHash(
            [System.Text.Encoding]::UTF8.GetBytes($HelpId))
        $hex = [BitConverter]::ToString($h).Replace('-', '').Substring(0, 8).ToLowerInvariant()
        return "id_$hex"
    }

    if ($stem.Length -gt $MaxLen) {
        $bytes = [System.Text.Encoding]::UTF8.GetBytes($HelpId)
        $h = [System.Security.Cryptography.SHA1]::Create().ComputeHash($bytes)
        $short = [BitConverter]::ToString($h).Replace('-', '').Substring(0, 8).ToLowerInvariant()
        $keep = $MaxLen - 9
        if ($keep -lt 32) { $keep = 32 }
        $stem = ($stem.Substring(0, [Math]::Min($keep, $stem.Length))) + '_' + $short
    }

    return $stem
}

function Get-ApiSidecarFileName {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$HelpId
    )
    return "$(Get-ApiSidecarStemFromHelpId -HelpId $HelpId).md"
}
