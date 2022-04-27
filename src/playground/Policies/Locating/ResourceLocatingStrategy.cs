// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Locating
{
    public sealed class ResourceLocatingStrategy : Strategy
    {
        public ResourceLocatingStrategy(ArmResource scope, EnforcementMode enforcementMode, bool stringMode = false, params AzureLocation[] locations)
            : base(
                  scope,
                  new HashSet<Policy>(),
                  new HashSet<Initiative>(),
                  new HashSet<Assignment>(ResourceLocatingStrategy.GetAssignments(scope, locations, stringMode, enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(ArmResource scope, IEnumerable<AzureLocation> locations, bool strictMode, EnforcementMode enforcementMode)
        {
            var resourceGroupAllowedLocationsPolicyDefinition = TenantPolicyDefinitionResource.CreateResourceIdentifier("e765b5de-1225-4ba3-bd56-1ac6695af988");
            var resourceGroupAllowedLocationsAssignment = new Assignment(
                scope: scope,
                name: $"assignment-{resourceGroupAllowedLocationsPolicyDefinition.Name}",
                displayName: "Resource group should be located correctly",
                resourceGroupAllowedLocationsPolicyDefinition,
                enforcementMode);

            IEnumerable<Assignment> assignments = new[] { resourceGroupAllowedLocationsAssignment };
            if (!strictMode)
            {
                var resourceMatchesResourceGroupLocationsPolicyDefinition = TenantPolicyDefinitionResource.CreateResourceIdentifier("0a914e76-4921-4c19-b460-a2d36003525a");
                assignments = assignments.Append(new Assignment(
                    scope: scope,
                    name: $"assignment-{resourceMatchesResourceGroupLocationsPolicyDefinition}",
                    displayName: "Resource location should be matches its resource group location",
                    resourceMatchesResourceGroupLocationsPolicyDefinition,
                    enforcementMode));
            }
            else
            {
                var resourceAllowedLocationsPolicyDefinition = TenantPolicyDefinitionResource.CreateResourceIdentifier("e56962a6-4747-49cd-b67b-bf8b01975c4c");
                assignments = assignments.Append(new Assignment(
                    scope: scope,
                    name: $"assignment-{resourceAllowedLocationsPolicyDefinition.Name}",
                    displayName: "Resource should be located correctly",
                    resourceAllowedLocationsPolicyDefinition,
                    enforcementMode));
            }

            foreach (var assignment in assignments)
            {
                assignment.Properties.Parameters.Add("listOfAllowedLocations", new ArmPolicyParameterValue
                {
                    Value = BinaryData.FromObjectAsJson(locations)
                });
            }

            return assignments;
        }
    }
}
