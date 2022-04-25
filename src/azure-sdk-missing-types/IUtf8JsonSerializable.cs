// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources
{
    public interface IUtf8JsonSerializable
    {
        public void Write(Utf8JsonWriter writer);
    }
}
