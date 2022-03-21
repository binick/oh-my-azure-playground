targetScope = 'subscription'

@description('An array of the allowed locations, all other locations will be denied by the created policy.')
param allowedLocations array = []

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

var builtInPolicyId = 'e765b5de-1225-4ba3-bd56-1ac6695af988'

resource locatingPolicyAssignment 'Microsoft.Authorization/policyAssignments@2021-06-01' = if (enableAssignment) {
  name: 'assignment-policy-resource-group-allowed-locations'
  properties: {
    displayName: 'Resource group should be located correctly'
    description: 'This policy assignment was automatically created by oh-my-azure-playground'
    parameters: {
      listOfAllowedLocations: {
        value: allowedLocations
      }
    }
    policyDefinitionId: tenantResourceId('Microsoft.Authorization/policyDefinitions', builtInPolicyId)
    enforcementMode: enforcementMode
  }
}
