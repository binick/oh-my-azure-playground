// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRule : IUtf8JsonSerializable
    {
        public PolicyRule(Operator @if, PolicyRuleEffect then)
        {
            this.If = @if;
            this.Then = then;
        }

        public Operator If { get; }

        public PolicyRuleEffect Then { get; }

        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("if");
            writer.WriteObjectValue(this.If);
            writer.WritePropertyName("then");
            writer.WriteObjectValue(this.Then);
            writer.WriteEndObject();
        }
    }
}
