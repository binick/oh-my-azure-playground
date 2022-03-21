targetScope = 'subscription'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module blueprint '../start-with-policy.bicep' = {
  name: 'blueprint-name-start-with'
  params: {
    prefix: 'bp-'
    providerNamespace: 'Microsoft.Blueprint'
    resourceType: 'blueprints'
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
    version: '0.1.0'
    category: 'Blueprint'
    preview: true
    deprecated: false
  }
}

