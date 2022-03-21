targetScope = 'subscription'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module managedIdentity '../start-with-policy.bicep' = {
  name: 'managed-identity-name-start-with'
  params: {
    prefix: 'id-'
    providerNamespace: 'Microsoft.ManagedIdentity'
    resourceType: 'userAssignedIdentities'
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
    version: '0.1.0'
    category: 'Managed Identity'
    preview: true
    deprecated: false
  }
}

