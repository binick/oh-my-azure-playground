using System.Text.Json;

namespace Azure.ResourceManager.Resources
{
    public interface IUtf8JsonSerializable
    {
        public void Write(Utf8JsonWriter writer);
    }
}
