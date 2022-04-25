// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Xunit;
using Xunit.Abstractions;

namespace Playground.Tests
{
    public class PolicyRuleEqualsConditionTests
    {
        private readonly ITestOutputHelper output;

        public PolicyRuleEqualsConditionTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("type", "[concat(parameters('providerNamespace'), '/', parameters('entity'))]")]
        public void ShouldBeFormattedAsExpected(string expectedField, string expectedValue)
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new PolicyRuleEqualsCondition(expectedField, expectedValue).ToBinaryData());

            Assert.Null(exception);

            var json = JsonDocument.Parse(binaryData).RootElement;
            Assert.Equal(expectedField, json.GetProperty("field").ToString());
            Assert.Equal(expectedValue, json.GetProperty("equals").ToString());
        }
    }
}
