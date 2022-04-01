// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Locating
{
    public sealed class ResourceLocatingStrategy : Strategy
    {
        public ResourceLocatingStrategy(EnforcementMode enforcementMode, bool stringMode = false, params AzureLocation[] locations)
            : base(
                  new HashSet<Policy>(),
                  new HashSet<Initiative>(),
                  new HashSet<Assignment>(ResourceLocatingStrategy.GetAssignments(locations, stringMode, enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(IEnumerable<AzureLocation> locations, bool strictMode, EnforcementMode enforcementMode)
        {
            var resourceGroupAllowedLocationsPolicyDefinition = TenantPolicyDefinition.CreateResourceIdentifier("e765b5de-1225-4ba3-bd56-1ac6695af988");
            var resourceGroupAllowedLocationsAssignment = new Assignment(
                name: $"assignment-{resourceGroupAllowedLocationsPolicyDefinition.Name}",
                displayName: "Resource group should be located correctly",
                resourceGroupAllowedLocationsPolicyDefinition,
                enforcementMode);

            IEnumerable<Assignment> assignments = new[] { resourceGroupAllowedLocationsAssignment };
            if (!strictMode)
            {
                var resourceMatchesResourceGroupLocationsPolicyDefinition = TenantPolicyDefinition.CreateResourceIdentifier("0a914e76-4921-4c19-b460-a2d36003525a");
                assignments = assignments.Append(new Assignment(
                    name: $"assignment-{resourceMatchesResourceGroupLocationsPolicyDefinition}",
                    displayName: "Resource location should be matches its resource group location",
                    resourceMatchesResourceGroupLocationsPolicyDefinition,
                    enforcementMode));
            }
            else
            {
                var resourceAllowedLocationsPolicyDefinition = TenantPolicyDefinition.CreateResourceIdentifier("e56962a6-4747-49cd-b67b-bf8b01975c4c");
                assignments = assignments.Append(new Assignment(
                    name: $"assignment-{resourceAllowedLocationsPolicyDefinition.Name}",
                    displayName: "Resource should be located correctly",
                    resourceAllowedLocationsPolicyDefinition,
                    enforcementMode));
            }

            foreach (var assignment in assignments)
            {
                assignment.Parameters.Add("listOfAllowedLocations", new ParameterValuesValue
                {
                    Value = locations
                });
            }

            return assignments;
        }
    }
}
