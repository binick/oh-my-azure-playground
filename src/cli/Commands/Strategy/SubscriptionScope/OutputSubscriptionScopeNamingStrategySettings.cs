// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal class OutputSubscriptionScopeNamingStrategySettings : SubscriptionScopeNamingStrategySettings
    {
        [CommandArgument(0, "<OUTPUT_PATH>")]
        public string OutputPath { get; init; } = string.Empty;
    }
}
