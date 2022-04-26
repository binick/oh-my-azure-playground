// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleNotLikeCondition : Condition
    {
        public PolicyRuleNotLikeCondition(string field, string value)
            : base(field)
        {
            this.NotLike = value;
        }

        public string NotLike { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteObjectValue(this.EspaceExperession(this.Field));
            writer.WritePropertyName("match");
            writer.WriteObjectValue(this.EspaceExperession(this.NotLike));
            writer.WriteEndObject();
        }
    }
}
