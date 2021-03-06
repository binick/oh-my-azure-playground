// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.Core;
using JsonObject = System.Collections.Generic.IDictionary<string, object>;

namespace Azure.ResourceManager.Resources.Models
{
    public abstract class Resource : IUtf8JsonSerializable
    {
        private readonly JsonObject templateParameters;
        private readonly ICollection<ResourceIdentifier> dependsOn;

        protected Resource(string type, string name, string apiVersion)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or empty.", nameof(type));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(apiVersion))
            {
                throw new ArgumentException($"'{nameof(apiVersion)}' cannot be null or empty.", nameof(apiVersion));
            }

            this.templateParameters = new Dictionary<string, object>();
            this.dependsOn = new HashSet<ResourceIdentifier>();

            this.Type = type;
            this.Name = name;
            this.ApiVersion = apiVersion;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        public string Type { get; }

        public string Name { get; }

        public string ApiVersion { get; }

        public JsonObject AdditionalProperties { get; }

        public IEnumerable<ResourceIdentifier> DependsOn => this.dependsOn;

        public IEnumerable<KeyValuePair<string, object>> GetTemplateParameters()
        {
            return this.templateParameters.AsEnumerable();
        }

        public void AddTemplateParameter(string name, object value)
        {
            this.templateParameters.Add(name, JsonSerializer.SerializeToElement(value));
        }

        public void AddDependency(ResourceIdentifier resourceId)
        {
            this.dependsOn.Add(resourceId);
        }

        public virtual void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteObjectValue(this.Type);
            writer.WritePropertyName("name");
            writer.WriteObjectValue(this.Name);
            writer.WritePropertyName("apiVersion");
            writer.WriteObjectValue(this.ApiVersion);
            foreach (var property in this.AdditionalProperties)
            {
                writer.WritePropertyName(property.Key);
                writer.WriteObjectValue(property.Value);
            }

            writer.WritePropertyName("dependsOn");
            writer.WriteObjectValue(this.DependsOn.Select(r => this.EscapeMalformedSubscriptionResourceIdentifier(r)));
            writer.WriteEndObject();
        }

        private string EscapeMalformedSubscriptionResourceIdentifier(ResourceIdentifier resourceIdentifier)
        {
            return resourceIdentifier.ToString().Replace("/subscriptions//subscriptions", "/subscriptions");
        }
    }
}
