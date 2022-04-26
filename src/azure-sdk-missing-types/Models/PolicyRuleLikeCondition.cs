// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleLikeCondition : Condition
    {
        public PolicyRuleLikeCondition(string field, string value)
            : base(field)
        {
            this.Like = value;
        }

        public string Like { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteObjectValue(this.EspaceExperession(this.Field));
            writer.WritePropertyName("like");
            writer.WriteObjectValue(this.EspaceExperession(this.Like));
            writer.WriteEndObject();
        }
    }
}
