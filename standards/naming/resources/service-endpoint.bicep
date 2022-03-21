targetScope = 'subscription'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module serviceEndpoint '../start-with-policy.bicep' = {
  name: 'service-endpoint-name-start-with'
  params: {
    prefix: 'se-'
    providerNamespace: 'Microsoft.Network'
    resourceType: 'serviceEndPointPolicies'
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
    version: '0.1.0'
    category: 'Network'
    preview: true
    deprecated: false
  }
}

