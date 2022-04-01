// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Initiative : PolicySetDefinitionData
    {
        public Initiative(string name, string displayName, string description, PolicyMetadata metadata, PolicyDefinitionReference policyDefinition, params PolicyDefinitionReference[] otherPolicyDefinitions)
        {
            this.PolicySetName = name;
            this.PolicyType = Azure.ResourceManager.Resources.Models.PolicyType.Custom;
            this.DisplayName = metadata.IsPreview ? $"[Preview]: {displayName}" : displayName;
            this.Description = description;
            using var metadataStream = new MemoryStream();
            using var metadataWriter = new Utf8JsonWriter(metadataStream);
            metadataWriter.WriteObjectValue(metadata);
            metadataWriter.Flush();
            metadataStream.Seek(0, SeekOrigin.Begin);
            this.Metadata = JsonSerializer.Deserialize<object>(metadataStream);
            this.PolicyDefinitions.Add(policyDefinition);
            foreach (var definition in otherPolicyDefinitions)
            {
                this.PolicyDefinitions.Add(definition);
            }
        }

        public string PolicySetName { get; }
    }
}
