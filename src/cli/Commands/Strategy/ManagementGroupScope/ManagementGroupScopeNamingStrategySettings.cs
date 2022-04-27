// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal class ManagementGroupScopeNamingStrategySettings : NamingStrategySettings
    {
        [CommandArgument(0, "<MANAGEMENT_GROUP_ID>")]
        public string Scope { get; init; } = null!;
    }
}
