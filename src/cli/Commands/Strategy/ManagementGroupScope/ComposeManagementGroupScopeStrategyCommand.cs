// See the LICENSE.TXT file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using Playground.Cli.Infrastructure;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal class ComposeManagementGroupScopeStrategyCommand : ComposeStrategyCommand<ComposeManagementGroupScopeStrategySettings>
    {
        public ComposeManagementGroupScopeStrategyCommand(AssemblyScanner assemblyScanner)
            : base(assemblyScanner)
        {
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComposeManagementGroupScopeStrategySettings settings)
        {
            throw new NotImplementedException();
        }
    }
}
