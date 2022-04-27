// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Tagging
{
    public sealed class ResourceTaggingStrategy : Strategy
    {
        public ResourceTaggingStrategy(ArmResource scope, ResourceGroupTaggingInitiativeBuilder taggingInitiativeBuilder, EnforcementMode enforcementMode)
            : base(
                  scope,
                  new HashSet<Policy>(),
                  new[] { taggingInitiativeBuilder.Build() },
                  new HashSet<Assignment>(ResourceTaggingStrategy.GetAssignments(scope, enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(ArmResource scope, EnforcementMode enforcementMode)
        {
            return new[]
            {
                new Assignment(
                    scope: scope,
                    name: $"assignment-{ResourceGroupTaggingInitiativeBuilder.Name}",
                    displayName: "Resource group should be tagged correctly",
                    policyDefinition: TenantPolicyDefinitionResource.CreateResourceIdentifier(ResourceGroupTaggingInitiativeBuilder.Name),
                    enforcementMode: enforcementMode)
            };
        }
    }
}
