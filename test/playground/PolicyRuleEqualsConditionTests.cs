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
        [InlineData("type", "sample", "type", "sample")]
        [InlineData("type", "[expressions]", "type", "[[expressions]")]
        public void ShouldBeFormattedAsExpected(string field, string value, string expectedField, string excpectedValue)
        {
            BinaryData binaryData = null!;

            var exception = Record.Exception(() => binaryData = new PolicyRuleEqualsCondition(field, value).ToBinaryData());

            Assert.Null(exception);

            var json = JsonDocument.Parse(binaryData).RootElement;
            Assert.Equal(expectedField, json.GetProperty("field").ToString());
            Assert.Equal(excpectedValue, json.GetProperty("equals").ToString());
        }
    }
}
