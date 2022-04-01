// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public sealed class ResourceNamingStrategy : Strategy
    {
        public ResourceNamingStrategy(Policy abbreviationPolicy, Initiative abbreviationInitiative, EnforcementMode enforcementMode)
            : base(new[] { abbreviationPolicy }, new[] { abbreviationInitiative }, new HashSet<Assignment>(ResourceNamingStrategy.GetAssignments(enforcementMode)))
        {
        }

        private static IEnumerable<Assignment> GetAssignments(EnforcementMode enforcementMode)
        {
            return new[]
            {
                new Assignment(
                    $"assignment-{ResourceNamingInitiativeBuilder.Name}",
                    "Resource should be named correctly",
                    TenantPolicyDefinition.CreateResourceIdentifier(ResourceNamingInitiativeBuilder.Name),
                    enforcementMode)
            };
        }
    }
}
