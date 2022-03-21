[CmdletBinding()]
param (
  [Parameter(Mandatory = $false)]
  [switch] $Force,
  [Parameter(Mandatory = $false)]
  [switch] $AssignPolicies
)

. .\src\mustache.ps1
. .\src\converters.ps1
. .\src\resource-naming\resource-naming.ps1
