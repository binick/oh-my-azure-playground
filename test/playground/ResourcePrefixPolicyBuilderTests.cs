// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;
using Playground.Policies.Naming;
using Xunit;
using Xunit.Abstractions;

namespace Playground.Tests
{
    public class ResourcePrefixPolicyBuilderTests
    {
        private readonly ITestOutputHelper output;

        public ResourcePrefixPolicyBuilderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeSerialized()
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new ResourcePrefixPolicyBuilder().Build().ToBinaryData());

            Assert.Null(exception);
            this.output.WriteLine(binaryData.ToString());
        }
    }
}
