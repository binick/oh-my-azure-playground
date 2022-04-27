// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.SubscriptionScope
{
    internal class ComposeSubscriptionScopeStrategySettings : ComposeStrategySettings
    {
        [CommandArgument(0, "<SUBSCRIPTION_ID>")]
        public string Scope { get; init; } = null!;
    }
}
