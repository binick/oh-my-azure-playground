targetScope = 'subscription'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module hdinsightSparkCluster '../start-with-policy.bicep' = {
  name: 'hdinsight-spark-cluster-name-start-with'
  params: {
    prefix: 'spark-'
    providerNamespace: 'Microsoft.HDInsight'
    resourceType: 'clusters'
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
    version: '0.1.0'
    category: 'HDInsight'
    preview: true
    deprecated: false
  }
}

