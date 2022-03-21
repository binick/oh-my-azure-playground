targetScope = 'subscription'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module resourceGroupTags 'groups/resource-group-tagging-initiative.bicep' = {
  name: 'module-resource-group-tags'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}
