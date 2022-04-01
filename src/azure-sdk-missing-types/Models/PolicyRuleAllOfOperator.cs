// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleAllOfOperator : Operator
    {
        public PolicyRuleAllOfOperator(IUtf8JsonSerializable argument, params IUtf8JsonSerializable[] others)
        {
            this.AllOf = others.Reverse().Append(argument).Reverse();
        }

        public IEnumerable<IUtf8JsonSerializable> AllOf { get; }

        public override void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("allOf");
            writer.WriteObjectValue(this.AllOf);
            writer.WriteEndObject();
        }
    }
}
