// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Policy : PolicyDefinitionData
    {
        public Policy(string name, string displayName, string description, PolicyMetadata metadata, PolicyRule policyRule)
        {
            this.PolicyName = name;
            this.PolicyType = Azure.ResourceManager.Resources.Models.PolicyType.Custom;
            this.DisplayName = metadata.IsPreview ? $"[Preview]: {displayName}" : displayName;
            this.Description = description;
            using var metadataStream = new MemoryStream();
            using var metadataWriter = new Utf8JsonWriter(metadataStream);
            metadataWriter.WriteObjectValue(metadata);
            metadataWriter.Flush();
            metadataStream.Seek(0, SeekOrigin.Begin);
            this.Metadata = JsonSerializer.Deserialize<object>(metadataStream);
            using var policyRuleStream = new MemoryStream();
            using var policyRuleWriter = new Utf8JsonWriter(policyRuleStream);
            policyRuleWriter.WriteObjectValue(policyRule);
            policyRuleWriter.Flush();
            policyRuleStream.Seek(0, SeekOrigin.Begin);
            this.PolicyRule = JsonSerializer.Deserialize<object>(policyRuleStream);
        }

        public string PolicyName { get; }
    }
}
