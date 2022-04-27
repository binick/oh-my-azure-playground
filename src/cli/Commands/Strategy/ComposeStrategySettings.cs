// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy
{
    internal abstract class ComposeStrategySettings : CommandSettings
    {
        [CommandOption("-p|--policies")]
        public IEnumerable<string> PolicyNames { get; init; } = Enumerable.Empty<string>();

        [CommandOption("-i|--initiatives")]
        public IEnumerable<string> InitiativeNames { get; init; } = Enumerable.Empty<string>();

        [CommandOption("-a|--assignments")]
        public IEnumerable<string> AssignmentNames { get; init; } = Enumerable.Empty<string>();

        [CommandOption("-o|--output")]
        public string? OutputPath { get; init; }
    }
}
