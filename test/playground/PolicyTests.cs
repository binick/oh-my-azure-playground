// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Resources;
using Xunit;
using Xunit.Abstractions;

namespace Playground.Tests
{
    public class PolicyTests
    {
        private readonly ITestOutputHelper output;

        public PolicyTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeFormattedAsExpected()
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new DummyPolicy().ToBinaryData());

            Assert.Null(exception);

            var json = JsonDocument.Parse(binaryData).RootElement;
            Assert.True(json.TryGetProperty("properties", out var properties));
            Assert.False(properties.TryGetProperty("properties", out _));
        }
    }
}
