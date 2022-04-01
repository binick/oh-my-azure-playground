targetScope = 'subscription'

var displayName = 'Require a prefix on resources, resource groups and subscriptions.'
var version = '0.1.0'
var preview = true

resource policy 'Microsoft.Authorization/policyDefinitions@2021-06-01' = {
  name: 'policy-start-with-naming'
  properties: {
    displayName: preview ? '[Preview]: ${displayName}' : displayName
    description: 'Enforces existence of a prefix.'
    policyType: 'Custom'
    metadata: {
      version: preview ? '${version}-preview' : version
      category: 'General'
      preview: preview
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
      effect: {
        type: 'String'
        metadata: {
          displayName: 'Effect'
          description: 'Enable or disable the execution of the policy'
        }
        allowedValues: [
          'Audit'
          'Deny'
        ]
        defaultValue: 'Audit'
      }
    }
    mode: 'All'
    policyRule: {
      if: {
        allOf: [
          {
            field: 'type'
            equals: '[concat(parameters(\'prividerNamespace\'), \'/\', parameters(\'entity\')]'
          }
          {
            field: 'name'
            notLike: '[concat(parameters(\'prefix\'), \'*\')]'
          }
        ]
      }
      then: {
        effect: '[parameters(\'effect\')]'
      }
    }
  }
}
