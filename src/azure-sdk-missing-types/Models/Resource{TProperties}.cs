// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public abstract class Resource<TProperties> : Resource
        where TProperties : new()
    {
        protected Resource(string type, string name, string apiVersion)
            : base(type, name, apiVersion)
        {
            this.Properties = new ();
        }

        public TProperties Properties { get; set; }

        public override void Write(Utf8JsonWriter writer)
        {
            this.AdditionalProperties.Add("properties", JsonDocument.Parse(this.Properties!.ToBinaryData().ToString()).RootElement.GetProperty("properties"));
            base.Write(writer);
        }
    }
}
