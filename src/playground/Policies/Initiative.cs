// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Initiative : Resource<PolicySetDefinitionData>
    {
        public Initiative(string name, string displayName, string description, PolicyMetadata metadata, PolicyDefinitionReference policyDefinition, params PolicyDefinitionReference[] otherPolicyDefinitions)
            : base("Microsoft.Authorization/policySetDefinitions", name, "2021-06-01")
        {
            this.Properties.PolicyType = PolicyType.Custom;
            this.Properties.DisplayName = metadata.IsPreview ? $"[Preview]: {displayName}" : displayName;
            this.Properties.Description = description;
            this.Properties.Metadata = metadata.ToBinaryData();
            this.Properties.PolicyDefinitions.Add(policyDefinition);
            foreach (var definition in otherPolicyDefinitions)
            {
                this.Properties.PolicyDefinitions.Add(definition);
            }
        }
    }
}
