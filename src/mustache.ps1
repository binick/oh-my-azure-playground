function Replace ([string] $template, [string] $key, [string] $value) {
  return $template -replace "{{ $key }}", $value
}
