// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Policy : Resource<PolicyDefinitionData>
    {
        public Policy(string name, string displayName, string description, PolicyMetadata metadata, PolicyRule policyRule)
            : base("Microsoft.Authorization/policyDefinitions", name, "2021-06-01")
        {
            this.Properties.PolicyType = PolicyType.Custom;
            this.Properties.DisplayName = metadata.IsPreview ? $"[Preview]: {displayName}" : displayName;
            this.Properties.Description = description;
            this.Properties.Metadata = metadata.ToBinaryData();
            this.Properties.PolicyRule = policyRule.ToBinaryData();
        }
    }
}
