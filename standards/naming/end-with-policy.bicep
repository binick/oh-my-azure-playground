targetScope = 'subscription'

@description('Determines under which category in the Azure portal the policy definition is displayed.')
param category string = 'Naming'

@description('Tracks details about the version of the contents of a policy definition.')
param version string

@description('True or false flag for if the policy definition is preview.')
param preview bool = true

@description('True or false flag for if the policy definition has been marked as deprecated.')
param deprecated bool = false

@allowed([
  'Deny'
  'Audit'
  'Disabled'
])
@description('The effect determines what happens when the policy rule is evaluated to match.')
param effect string = 'Deny'

var displayName = 'Require a suffix on resources, resource groups and subscriptions.'

resource policy 'Microsoft.Authorization/policyDefinitions@2021-06-01' = {
  name: 'policy-end-with-naming'
  properties: {
    displayName: preview ? '[Preview]: ${displayName}' : displayName
    description: 'Enforces existence of a suffix.'
    policyType: 'Custom'
    metadata: {
      version: preview ? '${version}-preview' : version
      category: category
      preview: preview
      deprecated: deprecated
    }
    parameters: {
      prividerNamespace: {
        type: 'String'
        metadata: {
          displayName: 'Resource provider namespace'
          description: 'Identify the ARM resource provider'
        }
      }
      entity: {
        type: 'String'
        metadata: {
          displayName: 'Entity'
          description: 'Name of the ARM entity'
        }
      }
      prefix: {
        type: 'String'
        metadata: {
          displayName: 'Prefix'
          description: 'Prefix that the resource must have, such as \'app-\''
        }
      }
    }
    mode: 'All'
    policyRule: {
      if: {
        allOf: [
          {
            field: 'type'
            equals: '[parameters(\'prividerNamespace\')]/[parameters(\'entity\')]'
          }
          {
            field: 'name'
            notLike: '*[parameters(\'prefix\')]'
          }
        ]
      }
      then: {
        effect: effect
      }
    }
  }
}
