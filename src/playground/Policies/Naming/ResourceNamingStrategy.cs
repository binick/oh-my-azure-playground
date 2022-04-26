// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public sealed class ResourceNamingStrategy : Strategy
    {
        public ResourceNamingStrategy(SubscriptionResource subscription, Policy abbreviationPolicy, Initiative abbreviationInitiative, EnforcementMode enforcementMode)
            : base(new[] { abbreviationPolicy }, new[] { abbreviationInitiative }, new HashSet<Assignment>(ResourceNamingStrategy.GetAssignments(SubscriptionPolicySetDefinitionResource.CreateResourceIdentifier(subscription.Id, ResourceNamingInitiativeBuilder.Name), enforcementMode)))
        {
        }

        public ResourceNamingStrategy(ManagementGroupResource managementGroup, Policy abbreviationPolicy, Initiative abbreviationInitiative, EnforcementMode enforcementMode)
            : base(new[] { abbreviationPolicy }, new[] { abbreviationInitiative }, new HashSet<Assignment>(ResourceNamingStrategy.GetAssignments(ManagementGroupPolicySetDefinitionResource.CreateResourceIdentifier(managementGroup.Id, ResourceNamingInitiativeBuilder.Name), enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(ResourceIdentifier policy, EnforcementMode enforcementMode)
        {
            return new[]
            {
                new Assignment(
                    $"assignment-{ResourceNamingInitiativeBuilder.Name}",
                    "Resource should be named correctly",
                    policy,
                    enforcementMode)
            };
        }
    }
}
