// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleNotEqualsCondition : Condition
    {
        public PolicyRuleNotEqualsCondition(string field, string value)
            : base(field)
        {
            this.NotEqual = value;
        }

        public string NotEqual { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteObjectValue(this.Field);
            writer.WritePropertyName("notEquals");
            writer.WriteObjectValue(this.NotEqual);
            writer.WriteEndObject();
        }
    }
}
