// See the LICENSE.TXT file in the project root for full license information.

using Playground.Cli.Commands.Strategy.ManagementGroupScope;
using Spectre.Console.Cli;
using Xunit;

namespace Playground.Cli.Tests
{
    public class OutputSubscriptionScopeNamingStrategyCommandTests
    {
        [Fact]
        public async Task ShouldBeExecutableAsync()
        {
            var store = new MockStore();
            var client = new FakeArmClient();
            var context = new CommandContext(new StubRemainingArguments(), string.Empty, null);
            var settings = new OutputSubscriptionScopeNamingStrategySettings
            {
                Scope = Guid.NewGuid().ToString(),
                OutputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())
            };

            var exception = await Record.ExceptionAsync(() => new OutputSubscriptionScopeNamingStrategyCommand(client, store).ExecuteAsync(context, settings));

            Assert.Null(exception);
        }
    }
}
