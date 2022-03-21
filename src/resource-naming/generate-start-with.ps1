. .\src\mustache.ps1
. .\src\converters.ps1

function Get-StartWith(
  [string] $template,
  [string] $module,
  [string] $prefix,
  [string] $providerNamespace,
  [string] $resourceType,
  [string] $version,
  [string] $category,
  [bool] $preview,
  [bool] $deprecated) {
  $template = Replace $template 'module' $(ConvertTo-CamelCase $module)
  $template = Replace $template 'prefix' $prefix
  $template = Replace $template 'name' "${module}-name-start-with"
  $template = Replace $template 'providerNamespace' $providerNamespace
  $template = Replace $template 'resourceType' $resourceType
  $template = Replace $template 'version' $version
  $template = Replace $template 'category' $category
  $template = Replace $template 'preview' $preview.ToString().ToLower()
  $template = Replace $template 'deprecated' $deprecated.ToString().ToLower()

  return $template
}
