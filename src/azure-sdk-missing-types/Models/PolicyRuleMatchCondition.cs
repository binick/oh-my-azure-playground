// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleMatchCondition : Condition
    {
        public PolicyRuleMatchCondition(string field, string value)
            : base(field)
        {
            this.Match = value;
        }

        public string Match { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteObjectValue(this.EspaceExperession(this.Field));
            writer.WritePropertyName("match");
            writer.WriteObjectValue(this.EspaceExperession(this.Match));
            writer.WriteEndObject();
        }
    }
}
