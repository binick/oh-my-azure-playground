// See the LICENSE.TXT file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using Azure.ResourceManager.Resources.Models;
using Playground.Cli.Infrastructure;
using Playground.Policies;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy
{
    internal class ComposeStrategyCommand<TSettings> : Command<TSettings>
        where TSettings : ComposeStrategySettings
    {
        private readonly AssemblyScanner assemblyScanner;

        public ComposeStrategyCommand(AssemblyScanner assemblyScanner)
        {
            this.assemblyScanner = assemblyScanner;
        }

        protected IEnumerable<Policy> Policies { get; private set; } = Enumerable.Empty<Policy>();

        protected IEnumerable<Initiative> Initiatives { get; private set; } = Enumerable.Empty<Initiative>();

        protected IEnumerable<Assignment> Assignments { get; private set; } = Enumerable.Empty<Assignment>();

        public override int Execute([NotNull] CommandContext context, [NotNull] TSettings settings)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Policy> FindPolicyByName(IEnumerable<string> names)
        {
            return this.FindResourceByName(this.assemblyScanner.Scan<PolicyBuilder>().Select(p => p.Build()), names);
        }

        private IEnumerable<Initiative> FindInitiativeByName(IEnumerable<string> names)
        {
            return this.FindResourceByName(this.assemblyScanner.Scan<InitiativeBuilder>().Select(p => p.Build()), names);
        }

        private IEnumerable<T> FindResourceByName<T>(IEnumerable<T> resources, IEnumerable<string> names)
            where T : Resource
        {
            return resources.Where(resource => names.Any(n => resource.Name.Equals(n)));
        }
    }
}
