[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)]
  [string] $Location,
  [Parameter(Mandatory = $true)] 
  [ValidateScript({ Test-Path $_ })]
  [string] $File,
  [Parameter(Mandatory = $false)] 
  [string] $Parameters
)

$timestamp = Get-Date -UFormat "%F_%s"

$params = if ($Parameters) { "-p $Parameters" } else { '' }

try {
  az deployment sub create -n $timestamp -l $Location -f $File -c $params
}
catch {
  Write-Host $_.ScriptStackTrace
  ExitWithExitCode 1
}
