// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleAnyOfOperator : Operator
    {
        public PolicyRuleAnyOfOperator(IUtf8JsonSerializable argument, params IUtf8JsonSerializable[] others)
        {
            this.AnyOf = others.Reverse().Append(argument).Reverse();
        }

        public IEnumerable<IUtf8JsonSerializable> AnyOf { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("anyOf");
            writer.WriteObjectValue(this.AnyOf);
            writer.WriteEndObject();
        }
    }
}
