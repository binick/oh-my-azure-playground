targetScope = 'subscription'

@description('An array of the allowed locations, all other locations will be denied by the created policy.')
param allowedLocations array = []

@description('An array of expected tags for resource group.')
param expectedTags array = []

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module namingPolicy 'naming/main.bicep' = {
  name: 'naming-policy'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module taggingPolicy 'tagging/main.bicep' = {
  name: 'tagging-policy'
  params: {
    expectedTags: expectedTags
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module locatingPolicy 'locating/main.bicep' = {
  name: 'locating-policy'
  params: {
    allowedLocations: allowedLocations
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}
