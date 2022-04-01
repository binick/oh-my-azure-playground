// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public class PolicyRuleEffect : IUtf8JsonSerializable
    {
        public static readonly PolicyRuleEffect Deny = new (nameof(Deny));
        public static readonly PolicyRuleEffect Audit = new (nameof(Audit));
        public static readonly PolicyRuleEffect Modify = new (nameof(Modify));
        public static readonly PolicyRuleEffect Append = new (nameof(Append));
        public static readonly PolicyRuleEffect AuditIfNotExists = new (nameof(AuditIfNotExists));
        public static readonly PolicyRuleEffect DeployIfNotExists = new (nameof(DeployIfNotExists));
        public static readonly PolicyRuleEffect Disabled = new (nameof(Disabled));

        public PolicyRuleEffect(string effect)
        {
            this.Effect = effect;
        }

        public string Effect { get; }

        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("effect");
            writer.WriteObjectValue(this.Effect);
            writer.WriteEndObject();
        }
    }
}
