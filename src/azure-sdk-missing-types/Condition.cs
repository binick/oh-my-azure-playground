using System.Text.Json;

namespace Azure.ResourceManager.Resources
{
    public abstract class Condition : IUtf8JsonSerializable
    {
        protected Condition(string field)
        {
            this.Field = field;
        }

        public string Field { get; }

        public abstract void Write(Utf8JsonWriter writer);
    }
}
