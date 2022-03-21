targetScope = 'subscription'

@description('An array of expected tags for resource group, such as ')
param expectedTags array = []

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

var builtInPolicyId = '96670d01-0a4d-4649-9c89-2d3abc0a5025'

var suggestedTags = [
  {
    name: 'workload-name'
    description: 'Name of the workload the resource supports.'
  }
  {
    name: 'data-classification'
    description: 'Sensitivity of data hosted by this resource.'
  }
  {
    name: 'criticality'
    description: 'Business impact of the resource or supported workload.'
  }
  {
    name: 'business-unit'
    description: 'Top-level division of your company that owns the subscription or workload that the resource belongs to. In smaller organizations, this tag might represent a single corporate or shared top-level organizational element.'
  }
  {
    name: 'ops-commitment'
    description: 'Level of operations support provided for this workload or resource.'
  }
  {
    name: 'ops-team'
    description: 'Team accountable for day-to-day operations.'
  }
]

var otherCommonTags = [
  {
    name: 'app-name'
    description: 'Added granularity if the workload is subdivided across multiple applications or services.'
  }
  {
    name: 'approver'
    description: 'Person responsible for approving costs related to this resource.'
  }
  {
    name: 'budget-amount'
    description: 'Money approved for this application service or workload.'
  }
  {
    name: 'cost-center'
    description: 'Accounting cost center associated with this resource.'
  }
  {
    name: 'dr'
    description: 'Business criticality of the application workload or service.'
  }
  {
    name: 'end-date'
    description: 'Date when the application workload or service is scheduled for retirement.'
  }
  {
    name: 'env'
    description: 'Deployment environment of the application workload or service.'
  }
  {
    name: 'owner'
    description: 'Owner of the application workload or service.'
  }
  {
    name: 'requester'
    description: 'User who requested the creation of this application.'
  }
  {
    name: 'service-class'
    description: 'Service level agreement level of the application workload or service.'
  }
  {
    name: 'start-date'
    description: 'Date when the application workload or service was first deployed.'
  }
]

var tags = empty(expectedTags) ? concat(suggestedTags, otherCommonTags) : expectedTags

resource taggingInitiative 'Microsoft.Authorization/policySetDefinitions@2021-06-01' = {
  name: 'policy-resource-group-tagging-initiative'
  properties: {
    displayName: 'Resource group should be tagged correctly'
    description: 'This policy enforce a standard tagging of resource groups'
    policyType: 'Custom'
    metadata: {
      version: '0.1.0'
      category: 'Tags'
      preview: true
      deprecated: false
    }
    policyDefinitions: [for tag in tags: {
      parameters: {
        tagName: {
          value: tag.name
        }
      }
      policyDefinitionReferenceId: guid(builtInPolicyId, tag.name)
      policyDefinitionId: tenantResourceId('Microsoft.Authorization/policyDefinitions', builtInPolicyId)
    }]
  }
}

resource taggingInitiativeAssignment 'Microsoft.Authorization/policyAssignments@2021-06-01' = if (enableAssignment) {
  name: 'assignment-${taggingInitiative.name}'
  properties: {
    displayName: 'Resource group should be tagged correctly'
    description: 'This policy assignment was automatically created by oh-my-azure-playground'
    policyDefinitionId: taggingInitiative.id
    enforcementMode: enforcementMode
  }
}
