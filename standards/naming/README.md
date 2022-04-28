# Naming.

This strategy defines the abbreviations that resources must respect within the name.

The abbreviation may be treated as a prefix `app-{resource-name}` or as a suffix `{resource-name}-app`.

| Resource type | Prefix | Suffix |
| --- | :-: | :-: |
| Microsoft.ApiManagement/service | `apim-` | `-apim` |
| Microsoft.ManagedIdentity/userAssignedIdentities | `id-` | `-id` |
| Microsoft.Management/managementGroups | `mg-` | `-mg` |
| Microsoft.Authorization/policyDefinitions | `policy-` | `-policy` |
| Microsoft.Resources/resourceGroups | `rg-` | `-rg` |
| Microsoft.Network/applicationGateways | `agw-` | `-agw` |
| Microsoft.Network/applicationSecurityGroups | `asg-` | `-asg` |
| Microsoft.Network/bastionHosts | `bas-` | `-bas` |
| Microsoft.Cdn/profiles | `cdnp-` | `-cdnp` |
| Microsoft.Cdn/profiles/endpoints | `cdne-` | `-cdne` |
| Microsoft.Network/connections | `con-` | `-con` |
| Microsoft.Network/dnsZones | `dnsz-` | `-dnsz` |
| Microsoft.Network/privateDnsZones | `pdnsz-` | `-pdnsz` |
| Microsoft.Network/azureFirewalls | `afw-` | `-afw` |
| Microsoft.Network/firewallPolicies | `afwp-` | `-afwp` |
| Microsoft.Network/expressRouteCircuits | `erc-` | `-erc` |
| Microsoft.Network/frontDoors | `fd-` | `-fd` |
| Microsoft.Network/frontdoorWebApplicationFirewallPolicies | `fdfp-` | `-fdfp` |
| Microsoft.Network/loadBalancers | `lbi-` | `-lbi` |
| Microsoft.Network/loadBalancers | `lbe-` | `-lbe` |
| Microsoft.Network/loadBalancers/inboundNatRules | `rule-` | `-rule` |
| Microsoft.Network/localNetworkGateways | `lgw-` | `-lgw` |
| Microsoft.Network/natGateways | `ng` | `ng` |
| Microsoft.Network/networkInterfaces | `nic-` | `-nic` |
| Microsoft.Network/networkSecurityGroups | `nsg-` | `-nsg` |
| Microsoft.Network/networkSecurityGroups/securityRules | `nsgsr-` | `-nsgsr` |
| Microsoft.Network/networkWatchers | `nw-` | `-nw` |
| Microsoft.Network/privateLinkServices | `pl-` | `-pl` |
| Microsoft.Network/publicIPAddresses | `pip-` | `-pip` |
| Microsoft.Network/publicIPabbreviationes | `ippre-` | `-ippre` |
| Microsoft.Network/routeFilters | `rf-` | `-rf` |
| Microsoft.Network/routeTables | `rt-` | `-rt` |
| Microsoft.Network/serviceEndPointPolicies | `se-` | `-se` |
| Microsoft.Network/trafficManagerProfiles | `traf-` | `-traf` |
| Microsoft.Network/routeTables/routes | `udr-` | `-udr` |
| Microsoft.Network/virtualNetworks | `vnet-` | `-vnet` |
| Microsoft.Network/virtualNetworks/virtualNetworkPeerings | `peer-` | `-peer` |
| Microsoft.Network/virtualNetworks/subnets | `snet-` | `-snet` |
| Microsoft.Network/virtualWans | `vwan-` | `-vwan` |
| Microsoft.Network/vpnGateways | `vpng-` | `-vpng` |
| Microsoft.Network/vpnGateways/vpnConnections | `vcn-` | `-vcn` |
| Microsoft.Network/vpnGateways/vpnSites | `vst-` | `-vst` |
| Microsoft.Network/virtualNetworkGateways | `vgw-` | `-vgw` |
| Microsoft.Network/firewallPolicies | `waf` | `waf` |
| Microsoft.Network/firewallPolicies/ruleGroups | `wafrg` | `wafrg` |
| Microsoft.Web/sites | `ase-` | `-ase` |
| Microsoft.Web/serverFarms | `plan-` | `-plan` |
| Microsoft.Compute/availabilitySets | `avail-` | `-avail` |
| Microsoft.HybridCompute/machines | `arcs-` | `-arcs` |
| Microsoft.Kubernetes/connectedClusters | `arck` | `arck` |
| Microsoft.Compute/cloudServices | `cld-` | `-cld` |
| Microsoft.Compute/diskEncryptionSets | `des` | `des` |
| Microsoft.Web/sites | `func-` | `-func` |
| Microsoft.Compute/galleries | `gal` | `gal` |
| Microsoft.Compute/disks | `osdisk` | `osdisk` |
| Microsoft.Compute/disks | `disk` | `disk` |
| Microsoft.NotificationHubs/namespaces/notificationHubs | `ntf-` | `-ntf` |
| Microsoft.NotificationHubs/namespaces | `ntfns-` | `-ntfns` |
| Microsoft.Compute/snapshots | `snap-` | `-snap` |
| Microsoft.Web/staticSites | `stapp-` | `-stapp` |
| Microsoft.Compute/virtualMachines | `vm` | `vm` |
| Microsoft.Compute/virtualMachineScaleSets | `vmss-` | `-vmss` |
| Microsoft.Web/sites | `app-` | `-app` |
| Microsoft.ContainerService/managedClusters | `aks-` | `-aks` |
| Microsoft.ContainerService/registries | `cr` | `cr` |
| Microsoft.ContainerService/containerGroups | `ci` | `ci` |
| Microsoft.ServiceFabric/clusters | `sf-` | `-sf` |
| Microsoft.DocumentDB/databaseAccounts/sqlDatabases | `cosmos-` | `-cosmos` |
| Microsoft.Cache/Redis | `redis-` | `-redis` |
| Microsoft.Sql/servers | `sql-` | `-sql` |
| Microsoft.Sql/servers/databases | `sqldb-` | `-sqldb` |
| Microsoft.Synapse/workspaces | `syn` | `syn` |
| Microsoft.Synapse/workspaces | `synw` | `synw` |
| Microsoft.Synapse/workspaces/sqlPools | `syndp` | `syndp` |
| Microsoft.Synapse/workspaces/sqlPools | `synsp` | `synsp` |
| Microsoft.DBforMySQL/servers | `mysql-` | `-mysql` |
| Microsoft.DBforPostgreSQL/servers | `psql-` | `-psql` |
| Microsoft.Sql/databases | `sqlstrdb-` | `-sqlstrdb` |
| Microsoft.Sql/managedInstances | `sqlmi-` | `-sqlmi` |
| Microsoft.Storage/storageAccounts | `st` | `st` |
| Microsoft.StorSimple/managers | `ssimp` | `ssimp` |
| Microsoft.Search/searchServices | `srch-` | `-srch` |
| Microsoft.CognitiveServices/accounts | `cog-` | `-cog` |
| Microsoft.MachineLearningServices/workspaces | `mlw-` | `-mlw` |
| Microsoft.AnalysisServices/servers | `as` | `as` |
| Microsoft.Databricks/workspaces | `dbw-` | `-dbw` |
| Microsoft.StreamAnalytics/cluster | `asa-` | `-asa` |
| Microsoft.Kusto/clusters | `dec` | `dec` |
| Microsoft.Kusto/clusters/databases | `dedb` | `dedb` |
| Microsoft.DataFactory/factories | `adf-` | `-adf` |
| Microsoft.DataLakeStore/accounts | `dls` | `dls` |
| Microsoft.DataLakeAnalytics/accounts | `dla` | `dla` |
| Microsoft.EventHub/namespaces | `evhns-` | `-evhns` |
| Microsoft.EventHub/namespaces/eventHubs | `evh-` | `-evh` |
| Microsoft.EventGrid/domains | `evgd-` | `-evgd` |
| Microsoft.EventGrid/eventSubscriptions | `evgs-` | `-evgs` |
| Microsoft.EventGrid/domains/topics | `evgt-` | `-evgt` |
| Microsoft.HDInsight/clusters | `hadoop-` | `-hadoop` |
| Microsoft.HDInsight/clusters | `hbase-` | `-hbase` |
| Microsoft.HDInsight/clusters | `kafka-` | `-kafka` |
| Microsoft.HDInsight/clusters | `spark-` | `-spark` |
| Microsoft.HDInsight/clusters | `storm-` | `-storm` |
| Microsoft.HDInsight/clusters | `mls-` | `-mls` |
| Microsoft.Devices/IotHubs | `iot-` | `-iot` |
| Microsoft.Devices/provisioningServices | `provs-` | `-provs` |
| Microsoft.Devices/provisioningServices/certificates | `pcert-` | `-pcert` |
| Microsoft.PowerBIDedicated/capacities | `pbi-` | `-pbi` |
| Microsoft.TimeSeriesInsights/environments | `tsi-` | `-tsi` |
| Microsoft.DesktopVirtualization/hostPools | `vdpool-` | `-vdpool` |
| Microsoft.DesktopVirtualization/applicationGroups | `vdag-` | `-vdag` |
| Microsoft.DesktopVirtualization/workspaces | `vdws-` | `-vdws` |
| Microsoft.AppConfiguration/configurationStores | `appcs-` | `-appcs` |
| Microsoft.SignalRService/SignalR | `sigr` | `sigr` |
| Microsoft.Logic/integrationAccounts | `ia-` | `-ia` |
| Microsoft.Logic/workflows | `logic-` | `-logic` |
| Microsoft.ServiceBus/namespaces | `sb-` | `-sb` |
| Microsoft.ServiceBus/namespaces/queues | `sbq-` | `-sbq` |
| Microsoft.ServiceBus/namespaces/topics | `sbt-` | `-sbt` |
| Microsoft.Automation/automationAccounts | `aa-` | `-aa` |
| Microsoft.Insights/components | `appi-` | `-appi` |
| Microsoft.Insights/actionGroups | `ag-` | `-ag` |
| Microsoft.Purview/accounts | `pview-` | `-pview` |
| Microsoft.Blueprint/blueprints | `bp-` | `-bp` |
| Microsoft.Blueprint/blueprints/artifacts | `bpa-` | `-bpa` |
| Microsoft.KeyVault/vaults | `kv-` | `-kv` |
| Microsoft.OperationalInsights/workspaces | `log-` | `-log` |
| Microsoft.Migrate/assessmentProjects | `migr-` | `-migr` |
| Microsoft.DataMigration/services | `dms-` | `-dms` |
| Microsoft.RecoveryServices/vaults | `rsv-` | `-rsv` |

## Apply prefix strategy.

This strategy contains:

  - `policy-start-with-naming`: the policy that enforce the resource naming
  - `policy-resource-naming-initiative`: the policy set that specify the abbreviation for each resource above
  - `assignment-policy-resource-naming-initiative`: the inititiative assignment

[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fbinick%2Foh-my-azure-playground%2Fmain%2Fstandards%2Fnaming%2Fwith-prefix.json)
[![Deploy To Azure US Gov](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazuregov.svg?sanitize=true)](https://portal.azure.us/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fbinick%2Foh-my-azure-playground%2Fmain%2Fstandards%2Fnaming%2Fwith-prefix.json)
[![Visualize](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fbinick%2Foh-my-azure-playground%2Fmain%2Fstandards%2Fnaming%2Fwith-prefix.json)
