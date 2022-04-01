// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    // https://docs.microsoft.com/azure/governance/policy/concepts/definition-structure#metadata
    public record PolicyMetadata : IUtf8JsonSerializable
    {
        public PolicyMetadata(string category, string version, bool isPreview, bool isDeprecated)
        {
            this.Category = category;
            this.Version = version;
            this.IsPreview = isPreview;
            this.IsDeprecated = isDeprecated;
            this.ReviewRequired = string.Empty;
        }

        /// <summary>
        /// Gets determines under which category in the Azure portal the policy definition is displayed.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Gets tracks details about the version of the contents of a policy definition.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets a value indicating whether true or false flag for if the policy definition is preview.
        /// </summary>
        public bool IsPreview { get; }

        /// <summary>
        /// Gets a value indicating whether true or false flag for if the policy definition has been marked as deprecated.
        /// </summary>
        public bool IsDeprecated { get; }

        /// <summary>
        /// Gets determines whether parameters should be reviewed in the portal, regardless of the required input.
        /// </summary>
        public string ReviewRequired { get; }

        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (!string.IsNullOrWhiteSpace(this.Category))
            {
                writer.WritePropertyName("category");
                writer.WriteObjectValue(this.Category);
            }

            if (!string.IsNullOrWhiteSpace(this.Version))
            {
                writer.WritePropertyName("version");
                writer.WriteObjectValue(this.Version);
            }

            writer.WritePropertyName("preview");
            writer.WriteObjectValue(this.IsPreview);
            writer.WritePropertyName("deprecated");
            writer.WriteObjectValue(this.IsDeprecated);

            if (!string.IsNullOrWhiteSpace(this.Version))
            {
                // Todo: check if this is represent by an array
                // writer.WritePropertyName("portalReview");
                // writer.WriteObjectValue(this.ReviewRequired);
            }

            writer.WriteEndObject();
        }
    }
}
