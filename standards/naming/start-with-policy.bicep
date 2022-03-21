targetScope = 'subscription'

@description('Prefix that the resource must have')
param prefix string

@description('Resource provider namespace')
param providerNamespace string

@description('Resource type')
param resourceType string

@description('Determines under which category in the Azure portal the policy definition is displayed')
param category string = 'Naming'

@description('Tracks details about the version of the contents of a policy definition')
param version string

@description('True or false flag for if the policy definition is preview')
param preview bool = true

@description('True or false flag for if the policy definition has been marked as deprecated')
param deprecated bool = false

@allowed([
  'Deny'
  'Audit'
  'Disabled'
])
@description('The effect determines what happens when the policy rule is evaluated to match')
param effect string = 'Deny'

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'Default'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

var type = '${providerNamespace}/${resourceType}'
var normalizedPrefix = replace(prefix, '-', '')

resource startWithNamingPolicy 'Microsoft.Authorization/policyDefinitions@2021-06-01' = {
  name: 'policy-naming-${normalizedPrefix}'
  properties: {
    displayName: 'Resource type "${type}" should be start with ${prefix}'
    description: 'This policy enforce a standard for naming of ${type} resources'
    policyType: 'Custom'
    metadata: {
      version: version
      category: category
      preview: preview
      deprecated: deprecated
    }
    mode: 'All'
    policyRule: {
      if: {
        allOf: [
          {
            field: 'type'
            equals: type
          }
          {
            field: 'name'
            notLike: '${prefix}*'
          }
        ]
      }
      then: {
        effect: effect
      }
    }
  }
}

resource startWithNamingPolicyAssignment 'Microsoft.Authorization/policyAssignments@2021-06-01' = if (enableAssignment) {
  name: 'assignment-${startWithNamingPolicy.name}'
  properties: {
    displayName: 'Resource "${type}" should be start with ${prefix}*'
    description: 'This policy assignment was automatically created by oh-my-azure-playground'
    policyDefinitionId: startWithNamingPolicy.id
    enforcementMode: enforcementMode
  }
}
