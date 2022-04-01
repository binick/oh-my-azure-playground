// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Assignment : PolicyAssignmentData
    {
        public Assignment(string name, string displayName, ResourceIdentifier policyDefinition, AssignmentMetadata metadata, EnforcementMode enforcementMode)
            : this(name, displayName, policyDefinition, enforcementMode)
        {
            using var metadataStream = new MemoryStream();
            using var metadataWriter = new Utf8JsonWriter(metadataStream);
            metadataWriter.WriteObjectValue(metadata);
            metadataWriter.Flush();
            metadataStream.Seek(0, SeekOrigin.Begin);
            this.Metadata = JsonSerializer.Deserialize<object>(metadataStream);
        }

        public Assignment(string name, string displayName, ResourceIdentifier policyDefinition, EnforcementMode enforcementMode)
        {
            this.AssignmentName = name;
            this.DisplayName = displayName;
            this.Description = "This policy assignment was automatically created by oh-my-azure-playground";
            this.EnforcementMode = enforcementMode;
            this.PolicyDefinitionId = policyDefinition;
        }

        public string AssignmentName { get; }
    }
}
