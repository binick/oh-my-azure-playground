// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;
using Playground.Policies.Naming;
using Xunit;
using Xunit.Abstractions;

namespace Playground.Tests
{
    public class ResourceSuffixPolicyBuilderTests
    {
        private readonly ITestOutputHelper output;

        public ResourceSuffixPolicyBuilderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeSerialized()
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new ResourceSuffixPolicyBuilder(new FakeSubscriptionResource()).Build().ToBinaryData());

            Assert.Null(exception);
            this.output.WriteLine(binaryData.ToString());
        }
    }
}
