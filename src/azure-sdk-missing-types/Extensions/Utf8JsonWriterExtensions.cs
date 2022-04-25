// See the LICENSE.TXT file in the project root for full license information.

using System.Reflection;
using Azure.ResourceManager.Resources;

namespace System.Text.Json
{
    public static class Utf8JsonWriterExtensions
    {
        // Credits https://github.com/Azure/azure-sdk-for-net/blob/55f6b3ab30fa5e8dcd655c07a34fd7c16d33f125/sdk/core/Azure.Core/src/Messaging/CloudEventConverter.cs#L225
        public static void WriteObjectValue(this Utf8JsonWriter writer, object? value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case byte[] bytes:
                    writer.WriteStringValue(Convert.ToBase64String(bytes));
                    break;
                case ReadOnlyMemory<byte> rom:
                    writer.WriteRawValue(rom.ToString());
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case Guid g:
                    writer.WriteStringValue(g);
                    break;
                case Uri u:
                    writer.WriteStringValue(u.ToString());
                    break;
                case DateTimeOffset dateTimeOffset:
                    writer.WriteStringValue(dateTimeOffset);
                    break;
                case DateTime dateTime:
                    writer.WriteStringValue(dateTime);
                    break;
                case JsonElement json:
                    writer.WriteRawValue(json.ToString());
                    break;
                case IEnumerable<KeyValuePair<string, object>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        writer.WriteObjectValue(pair.Value);
                    }

                    writer.WriteEndObject();
                    break;
                case IEnumerable<object> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object item in objectEnumerable)
                    {
                        writer.WriteObjectValue(item);
                    }

                    writer.WriteEndArray();
                    break;
                case IUtf8JsonSerializable serializable:
                    serializable.Write(writer);
                    break;
                default:
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
                    var writerMethod = value.GetType().GetMethod("Azure.Core.IUtf8JsonSerializable.Write", BindingFlags.Instance | BindingFlags.NonPublic) !;
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
                    if (writerMethod is not null)
                    {
                        writerMethod.Invoke(value, new[] { writer });
                    }
                    else
                    {
                        throw new NotSupportedException("Not supported type " + value.GetType());
                    }

                    break;
            }
        }
    }
}
