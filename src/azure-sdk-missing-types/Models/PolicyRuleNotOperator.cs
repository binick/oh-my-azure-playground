// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleNotOperator : Operator
    {
        public PolicyRuleNotOperator(IUtf8JsonSerializable argument)
        {
            this.Not = argument;
        }

        public IUtf8JsonSerializable Not { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("not");
            writer.WriteObjectValue(this.Not);
            writer.WriteEndObject();
        }
    }
}
