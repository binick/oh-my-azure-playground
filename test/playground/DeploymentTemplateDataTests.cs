// See the LICENSE.TXT file in the project root for full license information.

using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Xunit;
using Xunit.Abstractions;

namespace Playground.Tests
{
    public class DeploymentTemplateDataTests
    {
        private readonly ITestOutputHelper output;

        public DeploymentTemplateDataTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeFormattedAsExpected()
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new DeploymentTemplateData().ToBinaryData());

            Assert.Null(exception);
            var value = Encoding.UTF8.GetString(binaryData);
            this.output.WriteLine(value);
            Assert.Collection(
                JsonDocument.Parse(value).RootElement.EnumerateObject(),
                property => Assert.Equal("$schema", property.Name),
                property => Assert.Equal("contentVersion", property.Name),
                property => Assert.Equal("parameters", property.Name),
                property => Assert.Equal("resources", property.Name));
        }
    }
}
