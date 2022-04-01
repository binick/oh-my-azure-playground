// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleMatchInsensitivelyCondition : Condition
    {
        public PolicyRuleMatchInsensitivelyCondition(string field, string value)
            : base(field)
        {
            this.MatchInsensitively = value;
        }

        public string MatchInsensitively { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteObjectValue(this.Field);
            writer.WritePropertyName("matchInsensitively");
            writer.WriteObjectValue(this.MatchInsensitively);
            writer.WriteEndObject();
        }
    }
}
