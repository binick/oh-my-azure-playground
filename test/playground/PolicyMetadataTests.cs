// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Xunit;
using Xunit.Abstractions;

namespace Playground.Tests
{
    public class PolicyMetadataTests
    {
        private readonly ITestOutputHelper output;

        public PolicyMetadataTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("Test", "0.1.0", true, true)]
        [InlineData("Test2", "1.0.0", false, false)]
        public async Task ShouldBeFormattedAsExpected(string expectedCategory, string expectedVersion, bool expectedIsPreview, bool expectedIsDeprecated)
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new PolicyMetadata(expectedCategory, expectedVersion, expectedIsPreview, expectedIsDeprecated).ToBinaryData());

            Assert.Null(exception);
            this.output.WriteLine(binaryData.ToString());
            Assert.Collection(
                JsonDocument.Parse(binaryData).RootElement.EnumerateObject(),
                property => Assert.Equal("category", property.Name),
                property => Assert.Equal("version", property.Name),
                property => Assert.Equal("preview", property.Name),
                property => Assert.Equal("deprecated", property.Name));
        }
    }
}
