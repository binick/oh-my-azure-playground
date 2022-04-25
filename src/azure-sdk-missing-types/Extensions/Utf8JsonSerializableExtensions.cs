// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources
{
    public static class Utf8JsonSerializableExtensions
    {
        public static BinaryData ToBinaryData(this object serializable)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            writer.WriteObjectValue(serializable);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var binaryData = BinaryData.FromStream(stream);
            stream.Flush();
            return binaryData;
        }
    }
}
