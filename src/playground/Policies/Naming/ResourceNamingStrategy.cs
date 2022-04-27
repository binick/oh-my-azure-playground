// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public sealed class ResourceNamingStrategy : Strategy
    {
        public ResourceNamingStrategy(SubscriptionResource scope, Policy abbreviationPolicy, Initiative abbreviationInitiative, EnforcementMode enforcementMode)
            : base(scope, new[] { abbreviationPolicy }, new[] { abbreviationInitiative }, new HashSet<Assignment>(ResourceNamingStrategy.GetAssignments(scope, SubscriptionPolicySetDefinitionResource.CreateResourceIdentifier(scope.Id, ResourceNamingInitiativeBuilder.Name), enforcementMode)))
        {
        }

        public ResourceNamingStrategy(ManagementGroupResource scope, Policy abbreviationPolicy, Initiative abbreviationInitiative, EnforcementMode enforcementMode)
            : base(scope, new[] { abbreviationPolicy }, new[] { abbreviationInitiative }, new HashSet<Assignment>(ResourceNamingStrategy.GetAssignments(scope, ManagementGroupPolicySetDefinitionResource.CreateResourceIdentifier(scope.Id, ResourceNamingInitiativeBuilder.Name), enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(ArmResource scope, ResourceIdentifier policy, EnforcementMode enforcementMode)
        {
            return new[]
            {
                new Assignment(
                    scope,
                    $"assignment-{ResourceNamingInitiativeBuilder.Name}",
                    "Resource should be named correctly",
                    policy,
                    enforcementMode)
            };
        }
    }
}
