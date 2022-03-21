targetScope = 'subscription'

@description('An array of the allowed locations, all other locations will be denied by the created policy.')
param allowedLocations array = []

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

@allowed([
  'Strict'
  'ResourceGroup'
])
@description('When correlation mode is resource group, the policy effect isn\'t enforced on resources (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param correlationMode string = 'ResourceGroup'

var us = [
  'eastus'
  'eastus2'
  'southcentralus'
  'westus2'
  'westus3'
  'centralus'
  'northcentralus'
  'westus'
  'centralusstage'
  'eastusstage'
  'eastus2stage'
  'northcentralusstage'
  'southcentralusstage'
  'westusstage'
  'westus2stage'
  'centraluseuap'
  'eastus2euap'
  'westcentralus'
]

var asiaPacific = [
  'australiaeast'
  'southeastasia'
  'centralindia'
  'eastasia'
  'japaneast'
  'jioindiawest'
  'koreacentral'
  'eastasiastage'
  'southeastasiastage'
  'australiacentral'
  'australiacentral2'
  'australiasoutheast'
  'japanwest'
  'jioindiacentral'
  'koreasouth'
  'southindia'
  'westindia'
]

var europe = [
  'northeurope'
  'swedencentral'
  'uksouth'
  'westeurope'
  'francecentral'
  'germanywestcentral'
  'norwayeast'
  'switzerlandnorth'
  'francesouth'
  'germanynorth'
  'norwaywest'
  'switzerlandwest'
  'ukwest'
]

var africa = [
  'southafricanorth'
  'southafricawest'
]

var canada = [
  'canadacentral'
  'canadaeast'
]

var middleEast = [
  'uaenorth'
  'uaecentral'
]

var southAmerica = [
  'brazilsouth'
  'brazilsoutheast'
]

var others = [
  'asia'
  'asiapacific'
  'australia'
  'brazil'
  'canada'
  'europe'
  'france'
  'germany'
  'global'
  'india'
  'japan'
  'korea'
  'norway'
  'southafrica'
  'switzerland'
  'uae'
  'uk'
  'unitedstates'
  'unitedstateseuap'
]

var locations = empty(allowedLocations) ? concat(us, asiaPacific, europe, africa, canada, middleEast, southAmerica, southAmerica, others) : allowedLocations

module resourceGroupAllowedLocations 'groups/resource-group-allowed-locations-policy.bicep' = {
  name: 'module-resource-group-allowed-locations'
  params: {
    allowedLocations: locations
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module resourceAllowedLocations 'resources/resource-allowed-locations-policy.bicep' = if (correlationMode == 'Strict') {
  name: 'module-resource-allowed-locations'
  params: {
    allowedLocations: locations
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module resourceMatchesResourceGroupLocations 'resources/resource-allowed-locations-policy.bicep' = if (correlationMode == 'ResourceGroup') {
  name: 'module-resource-matches-resource-group-location'
  params: {
    allowedLocations: locations
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}
