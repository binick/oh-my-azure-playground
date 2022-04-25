// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Tagging
{
    public sealed class ResourceTaggingStrategy : Strategy
    {
        public ResourceTaggingStrategy(ResourceGroupTaggingInitiativeBuilder taggingInitiativeBuilder, EnforcementMode enforcementMode)
            : base(
                  new HashSet<Policy>(),
                  new[] { taggingInitiativeBuilder.Build() },
                  new HashSet<Assignment>(ResourceTaggingStrategy.GetAssignments(enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(EnforcementMode enforcementMode)
        {
            return new[]
            {
                new Assignment(
                    name: $"assignment-{ResourceGroupTaggingInitiativeBuilder.Name}",
                    displayName: "Resource group should be tagged correctly",
                    policyDefinition: TenantPolicyDefinitionResource.CreateResourceIdentifier(ResourceGroupTaggingInitiativeBuilder.Name),
                    enforcementMode: enforcementMode)
            };
        }
    }
}
