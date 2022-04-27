// See the LICENSE.TXT file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using Playground.Cli.Infrastructure;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.SubscriptionScope
{
    internal class ComposeSubscriptionScopeStrategyCommand : ComposeStrategyCommand<ComposeSubscriptionScopeStrategySettings>
    {
        public ComposeSubscriptionScopeStrategyCommand(AssemblyScanner assemblyScanner)
            : base(assemblyScanner)
        {
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] ComposeSubscriptionScopeStrategySettings settings)
        {
            throw new NotImplementedException();
        }
    }
}
