function ConvertTo-CamelCase ([string] $value) {
  return $value -replace '-(\p{L})', { $_.Groups[1].Value.ToUpper() }
}
