targetScope = 'subscription'

@description('Enable policy assignment, by default the policy will not be assign.')
param enableAssignment bool = false

@allowed([
  'Default'
  'DoNotEnforce'
])
@description('When enforcement mode is disabled, the policy effect isn\'t enforced (i.e. deny policy won\'t deny resources). Compliance assessment results are still available.')
param enforcementMode string = 'DoNotEnforce'

module apiManagementServiceInstance 'resources/api-management-service-instance.bicep' = {
  name: 'module-api-management-service-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module managedIdentity 'resources/managed-identity.bicep' = {
  name: 'module-managed-identity-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module managementGroup 'resources/management-group.bicep' = {
  name: 'module-management-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module policyDefinition 'resources/policy-definition.bicep' = {
  name: 'module-policy-definition-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module resourceGroup 'resources/resource-group.bicep' = {
  name: 'module-resource-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module applicationGateway 'resources/application-gateway.bicep' = {
  name: 'module-application-gateway-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module applicationSecurityGroup 'resources/application-security-group.bicep' = {
  name: 'module-application-security-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module bastion 'resources/bastion.bicep' = {
  name: 'module-bastion-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module cdnProfile 'resources/cdn-profile.bicep' = {
  name: 'module-cdn-profile-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module cdnEndpoint 'resources/cdn-endpoint.bicep' = {
  name: 'module-cdn-endpoint-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module connections 'resources/connections.bicep' = {
  name: 'module-connections-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module dns 'resources/dns.bicep' = {
  name: 'module-dns-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module dnsZone 'resources/dns-zone.bicep' = {
  name: 'module-dns-zone-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module firewall 'resources/firewall.bicep' = {
  name: 'module-firewall-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module firewallPolicy 'resources/firewall-policy.bicep' = {
  name: 'module-firewall-policy-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module expressRouteCircuit 'resources/express-route-circuit.bicep' = {
  name: 'module-express-route-circuit-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module frontDoorInstance 'resources/front-door-instance.bicep' = {
  name: 'module-front-door-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module frontDoorFirewallPolicy 'resources/front-door-firewall-policy.bicep' = {
  name: 'module-front-door-firewall-policy-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module loadBalancerInternal 'resources/load-balancer-internal.bicep' = {
  name: 'module-load-balancer-internal-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module loadBalancerExternal 'resources/load-balancer-external.bicep' = {
  name: 'module-load-balancer-external-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module loadBalancerRule 'resources/load-balancer-rule.bicep' = {
  name: 'module-load-balancer-rule-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module localNetworkGateway 'resources/local-network-gateway.bicep' = {
  name: 'module-local-network-gateway-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module natGateway 'resources/nat-gateway.bicep' = {
  name: 'module-nat-gateway-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module networkInterface 'resources/network-interface.bicep' = {
  name: 'module-network-interface-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module networkSecurityGroup 'resources/network-security-group.bicep' = {
  name: 'module-network-security-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module networkSecurityGroupSecurityRules 'resources/network-security-group-security-rules.bicep' = {
  name: 'module-network-security-group-security-rules-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module networkWatcher 'resources/network-watcher.bicep' = {
  name: 'module-network-watcher-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module privateLink 'resources/private-link.bicep' = {
  name: 'module-private-link-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module publicIpAddress 'resources/public-ip-address.bicep' = {
  name: 'module-public-ip-address-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module publicIpAddressPrefix 'resources/public-ip-address-prefix.bicep' = {
  name: 'module-public-ip-address-prefix-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module routeFilter 'resources/route-filter.bicep' = {
  name: 'module-route-filter-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module routeTable 'resources/route-table.bicep' = {
  name: 'module-route-table-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module serviceEndpoint 'resources/service-endpoint.bicep' = {
  name: 'module-service-endpoint-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module trafficManagerProfile 'resources/traffic-manager-profile.bicep' = {
  name: 'module-traffic-manager-profile-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module userDefinerRoute 'resources/user-definer-route.bicep' = {
  name: 'module-user-definer-route-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualNetwork 'resources/virtual-network.bicep' = {
  name: 'module-virtual-network-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualNetworkPeering 'resources/virtual-network-peering.bicep' = {
  name: 'module-virtual-network-peering-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualNetworkSubnet 'resources/virtual-network-subnet.bicep' = {
  name: 'module-virtual-network-subnet-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualWan 'resources/virtual-wan.bicep' = {
  name: 'module-virtual-wan-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module vpnGateway 'resources/vpn-gateway.bicep' = {
  name: 'module-vpn-gateway-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module vpnConnection 'resources/vpn-connection.bicep' = {
  name: 'module-vpn-connection-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module vpnSite 'resources/vpn-site.bicep' = {
  name: 'module-vpn-site-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualNetworkGateway 'resources/virtual-network-gateway.bicep' = {
  name: 'module-virtual-network-gateway-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module webApplicationFirewallPolicy 'resources/web-application-firewall-policy.bicep' = {
  name: 'module-web-application-firewall-policy-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module webApplicationFirewallPolicyRuleGroup 'resources/web-application-firewall-policy-rule-group.bicep' = {
  name: 'module-web-application-firewall-policy-rule-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module appServiceEnvironment 'resources/app-service-environment.bicep' = {
  name: 'module-app-service-environment-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module appServicePlan 'resources/app-service-plan.bicep' = {
  name: 'module-app-service-plan-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module availabilitySet 'resources/availability-set.bicep' = {
  name: 'module-availability-set-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureArcEnabledServer 'resources/azure-arc-enabled-server.bicep' = {
  name: 'module-azure-arc-enabled-server-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureArcEnabledKubernetesCluster 'resources/azure-arc-enabled-kubernetes-cluster.bicep' = {
  name: 'module-azure-arc-enabled-kubernetes-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module cloudService 'resources/cloud-service.bicep' = {
  name: 'module-cloud-service-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module dataEncryptionSet 'resources/data-encryption-set.bicep' = {
  name: 'module-data-encryption-set-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module functionApp 'resources/function-app.bicep' = {
  name: 'module-function-app-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module gallery 'resources/gallery.bicep' = {
  name: 'module-gallery-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module managedDiskOs 'resources/managed-disk-os.bicep' = {
  name: 'module-managed-disk-os-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module managedDiskData 'resources/managed-disk-data.bicep' = {
  name: 'module-managed-disk-data-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module notificationHubs 'resources/notification-hubs.bicep' = {
  name: 'module-notification-hubs-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module notificationHubsNamespace 'resources/notification-hubs-namespace.bicep' = {
  name: 'module-notification-hubs-namespace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module snapshot 'resources/snapshot.bicep' = {
  name: 'module-snapshot-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module staticWebApp 'resources/static-web-app.bicep' = {
  name: 'module-static-web-app-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualMachine 'resources/virtual-machine.bicep' = {
  name: 'module-virtual-machine-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualMachineScaleSet 'resources/virtual-machine-scale-set.bicep' = {
  name: 'module-virtual-machine-scale-set-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module webApp 'resources/web-app.bicep' = {
  name: 'module-web-app-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module aksCluster 'resources/aks-cluster.bicep' = {
  name: 'module-aks-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module containerRegistry 'resources/container-registry.bicep' = {
  name: 'module-container-registry-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module containerInstance 'resources/container-instance.bicep' = {
  name: 'module-container-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module serviceFabricCluster 'resources/service-fabric-cluster.bicep' = {
  name: 'module-service-fabric-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureCosmosDbDatabase 'resources/azure-cosmos-db-database.bicep' = {
  name: 'module-azure-cosmos-db-database-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureCacheForRedisInstance 'resources/azure-cache-for-redis-instance.bicep' = {
  name: 'module-azure-cache-for-redis-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureSqlDatabaseServer 'resources/azure-sql-database-server.bicep' = {
  name: 'module-azure-sql-database-server-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureSqlDatabase 'resources/azure-sql-database.bicep' = {
  name: 'module-azure-sql-database-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureSynapseAnalytics 'resources/azure-synapse-analytics.bicep' = {
  name: 'module-azure-synapse-analytics-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureSynapseAnalyticsWorkspace 'resources/azure-synapse-analytics-workspace.bicep' = {
  name: 'module-azure-synapse-analytics-workspace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureSynapseAnalyticsSqlDedicatedPool 'resources/azure-synapse-analytics-sql-dedicated-pool.bicep' = {
  name: 'module-azure-synapse-analytics-sql-dedicated-pool-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureSynapseAnalyticsSparkPool 'resources/azure-synapse-analytics-spark-pool.bicep' = {
  name: 'module-azure-synapse-analytics-spark-pool-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module mysqlDatabase 'resources/mysql-database.bicep' = {
  name: 'module-mysql-database-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module postgresqlDatabase 'resources/postgresql-database.bicep' = {
  name: 'module-postgresql-database-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module sqlServerStretchDatabase 'resources/sql-server-stretch-database.bicep' = {
  name: 'module-sql-server-stretch-database-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module sqlManagedInstance 'resources/sql-managed-instance.bicep' = {
  name: 'module-sql-managed-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module storageAccount 'resources/storage-account.bicep' = {
  name: 'module-storage-account-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureStorSimple 'resources/azure-stor-simple.bicep' = {
  name: 'module-azure-stor-simple-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureCognitiveSearch 'resources/azure-cognitive-search.bicep' = {
  name: 'module-azure-cognitive-search-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureCognitiveServices 'resources/azure-cognitive-services.bicep' = {
  name: 'module-azure-cognitive-services-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureMachineLearningWorkspace 'resources/azure-machine-learning-workspace.bicep' = {
  name: 'module-azure-machine-learning-workspace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureAnalysisServicesServer 'resources/azure-analysis-services-server.bicep' = {
  name: 'module-azure-analysis-services-server-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureDatabricksWorkspace 'resources/azure-databricks-workspace.bicep' = {
  name: 'module-azure-databricks-workspace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureStreamAnalytics 'resources/azure-stream-analytics.bicep' = {
  name: 'module-azure-stream-analytics-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureDataExplorerCluster 'resources/azure-data-explorer-cluster.bicep' = {
  name: 'module-azure-data-explorer-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureDataExplorerClusterDatabase 'resources/azure-data-explorer-cluster-database.bicep' = {
  name: 'module-azure-data-explorer-cluster-database-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureDataFactory 'resources/azure-data-factory.bicep' = {
  name: 'module-azure-data-factory-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module dataLakeStoreAccount 'resources/data-lake-store-account.bicep' = {
  name: 'module-data-lake-store-account-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module dataLakeAnalyticsAccount 'resources/data-lake-analytics-account.bicep' = {
  name: 'module-data-lake-analytics-account-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module eventHubsNamespace 'resources/event-hubs-namespace.bicep' = {
  name: 'module-event-hubs-namespace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module eventHub 'resources/event-hub.bicep' = {
  name: 'module-event-hub-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module eventGridDomain 'resources/event-grid-domain.bicep' = {
  name: 'module-event-grid-domain-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module eventGridSubscriptions 'resources/event-grid-subscriptions.bicep' = {
  name: 'module-event-grid-subscriptions-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module eventGridTopic 'resources/event-grid-topic.bicep' = {
  name: 'module-event-grid-topic-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module hdinsightHadoopCluster 'resources/hdinsight-hadoop-cluster.bicep' = {
  name: 'module-hdinsight-hadoop-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module hdinsightHbaseCluster 'resources/hdinsight-hbase-cluster.bicep' = {
  name: 'module-hdinsight-hbase-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module hdinsightKafkaCluster 'resources/hdinsight-kafka-cluster.bicep' = {
  name: 'module-hdinsight-kafka-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module hdinsightSparkCluster 'resources/hdinsight-spark-cluster.bicep' = {
  name: 'module-hdinsight-spark-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module hdinsightStormCluster 'resources/hdinsight-storm-cluster.bicep' = {
  name: 'module-hdinsight-storm-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module hdinsightMlServicesCluster 'resources/hdinsight-ml-services-cluster.bicep' = {
  name: 'module-hdinsight-ml-services-cluster-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module iotHub 'resources/iot-hub.bicep' = {
  name: 'module-iot-hub-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module provisioningServices 'resources/provisioning-services.bicep' = {
  name: 'module-provisioning-services-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module provisioningServicesCertificate 'resources/provisioning-services-certificate.bicep' = {
  name: 'module-provisioning-services-certificate-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module powerBiEmbedded 'resources/power-bi-embedded.bicep' = {
  name: 'module-power-bi-embedded-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module timeSeriesInsightsEnvironment 'resources/time-series-insights-environment.bicep' = {
  name: 'module-time-series-insights-environment-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualDesktopHostPool 'resources/virtual-desktop-host-pool.bicep' = {
  name: 'module-virtual-desktop-host-pool-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualDesktopApplicationGroup 'resources/virtual-desktop-application-group.bicep' = {
  name: 'module-virtual-desktop-application-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module virtualDesktopWorkspace 'resources/virtual-desktop-workspace.bicep' = {
  name: 'module-virtual-desktop-workspace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module appConfigurationStore 'resources/app-configuration-store.bicep' = {
  name: 'module-app-configuration-store-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module signalr 'resources/signalr.bicep' = {
  name: 'module-signalr-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module integrationAccount 'resources/integration-account.bicep' = {
  name: 'module-integration-account-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module logicApps 'resources/logic-apps.bicep' = {
  name: 'module-logic-apps-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module serviceBus 'resources/service-bus.bicep' = {
  name: 'module-service-bus-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module serviceBusQueue 'resources/service-bus-queue.bicep' = {
  name: 'module-service-bus-queue-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module serviceBusTopic 'resources/service-bus-topic.bicep' = {
  name: 'module-service-bus-topic-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module automationAccount 'resources/automation-account.bicep' = {
  name: 'module-automation-account-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module applicationInsights 'resources/application-insights.bicep' = {
  name: 'module-application-insights-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureMonitorActionGroup 'resources/azure-monitor-action-group.bicep' = {
  name: 'module-azure-monitor-action-group-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azurePureviewInstance 'resources/azure-pureview-instance.bicep' = {
  name: 'module-azure-pureview-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module blueprint 'resources/blueprint.bicep' = {
  name: 'module-blueprint-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module blueprintAssignment 'resources/blueprint-assignment.bicep' = {
  name: 'module-blueprint-assignment-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module keyVault 'resources/key-vault.bicep' = {
  name: 'module-key-vault-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module logAnalyticsWorkspace 'resources/log-analytics-workspace.bicep' = {
  name: 'module-log-analytics-workspace-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module azureMigrateProject 'resources/azure-migrate-project.bicep' = {
  name: 'module-azure-migrate-project-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module databaseMigrationServiceInstance 'resources/database-migration-service-instance.bicep' = {
  name: 'module-database-migration-service-instance-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}

module recoveryServicesVault 'resources/recovery-services-vault.bicep' = {
  name: 'module-recovery-services-vault-naming'
  params: {
    enableAssignment: enableAssignment
    enforcementMode: enforcementMode
  }
}
