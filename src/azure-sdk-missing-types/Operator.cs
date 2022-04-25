// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources
{
    public abstract class Operator : IUtf8JsonSerializable
    {
        public abstract void Write(Utf8JsonWriter writer);
    }
}
