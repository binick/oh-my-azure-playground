[CmdletBinding()]
param (
  [Parameter(Mandatory = $false)]
  [switch] $Force
)

. .\src\mustache.ps1
. .\src\converters.ps1
. .\src\resource-naming\generate-start-with.ps1

$namingRootOutputPath = Join-Path $PSScriptRoot "..\..\standards\naming"
$resourceNamingOutputPath = Join-Path $namingRootOutputPath "..\..\standards\naming\resources"

if (!(Test-Path $namingRootOutputPath)) {
  mkdir $namingRootOutputPath
}

if (!(Test-Path $resourceNamingOutputPath)) {
  mkdir $resourceNamingOutputPath
}

$moduleImportTemplate = @"
module {{ name }} '{{ path }}' = {
  name: 'module-{{ module }}'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}
"@

$template = Get-Content (Join-Path $PSScriptRoot 'start-with-policy-module.template') -Raw

$namingModuleImports = @();

function Get-ModuleImport([string] $template, [string] $module) {
  $template = Replace $template 'name' $(ConvertTo-CamelCase $module)
  $template = Replace $template 'path' "resources/${module}.bicep"
  $template = Replace $template 'module' "${module}-naming"

  return $template
}

foreach ($resource in $(Get-Content (Join-Path $PSScriptRoot 'prefixes.json') | ConvertFrom-Json)) {
  $outputPath = Join-Path $resourceNamingOutputPath "$($resource.module).bicep"
  if (!(Test-Path $outputPath) -or ($Force -eq $true)) {
    Get-StartWith `
      $template `
      $resource.module `
      $resource.prefix `
      $resource.providerNamespace `
      $resource.resourceType `
      $resource.version `
      $resource.category `
      $resource.preview `
      $resource.deprecated | Out-File -FilePath $outputPath -Force
  }
  $namingModuleImports += Get-ModuleImport $moduleImportTemplate $resource.module
}

$mainOutputPath = Join-Path $namingRootOutputPath "main.bicep"
if (!(Test-Path $mainOutputPath) -or ($Force -eq $true)) {
  "targetScope = 'subscription'`n
@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false`n
@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'`n
$($namingModuleImports -join "`n`n")" | Out-File -FilePath $mainOutputPath -Force
}
