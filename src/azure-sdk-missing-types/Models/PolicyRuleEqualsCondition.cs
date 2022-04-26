// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleEqualsCondition : Condition
    {
        public PolicyRuleEqualsCondition(string field, string value)
            : base(field)
        {
            this.Equal = value;
        }

        public string Equal { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteObjectValue(this.EspaceExperession(this.Field));
            writer.WritePropertyName("equals");
            writer.WriteObjectValue(this.EspaceExperession(this.Equal));
            writer.WriteEndObject();
        }
    }
}
