// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Models;
using JsonObject = System.Collections.Generic.IDictionary<string, object>;

namespace Azure.ResourceManager.Resources.Models
{
    public class DeploymentTemplateData : ResourceData, IUtf8JsonSerializable
    {
        public DeploymentTemplateData(params Resource[] resources)
        {
            this.Resources = resources;
            this.Schema = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#";
            this.ContentVersion = "1.0.0.0";
            this.Parameters = resources.SelectMany(r => r.GetTemplateParameters()).ToDictionary(p => p.Key, p => p.Value);
        }

        public string Schema { get; protected set; }

        public string ContentVersion { get; set; }

        public string? ApiProfile { get; set; }

        public JsonObject? Parameters { get; set; }

        public BinaryData? Variables { get; set; }

        public BinaryData? Functions { get; set; }

        public ICollection<Resource> Resources { get; }

        public BinaryData? Outputs { get; set; }

        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("$schema");
            writer.WriteObjectValue(this.Schema);
            writer.WritePropertyName("contentVersion");
            writer.WriteObjectValue(this.ContentVersion);
            if (!string.IsNullOrEmpty(this.ApiProfile))
            {
                writer.WritePropertyName("apiProfile");
                writer.WriteObjectValue(this.ApiProfile);
            }

            if (this.Parameters is not null)
            {
                writer.WritePropertyName("parameters");
                writer.WriteObjectValue(this.Parameters);
            }

            if (this.Variables is not null)
            {
                writer.WritePropertyName("variables");
                writer.WriteObjectValue(this.Variables);
            }

            if (this.Functions is not null)
            {
                writer.WritePropertyName("functions");
                writer.WriteObjectValue(this.Functions);
            }

            writer.WritePropertyName("resources");
            writer.WriteObjectValue(this.Resources);

            if (this.Outputs is not null)
            {
                writer.WritePropertyName("outputs");
                writer.WriteObjectValue(this.Outputs);
            }

            writer.WriteEndObject();
        }
    }
}
