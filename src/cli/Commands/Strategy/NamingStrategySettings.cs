// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy
{
    internal class NamingStrategySettings : CommandSettings
    {
        [CommandOption("-s|--use-suffix")]
        public bool UseSuffix { get; init; } = false;
    }
}
