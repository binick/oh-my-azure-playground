using System.Text.Json;

namespace Azure.ResourceManager.Resources
{
    public abstract class Operator : IUtf8JsonSerializable
    {
        public abstract void Write(Utf8JsonWriter writer);
    }
}
