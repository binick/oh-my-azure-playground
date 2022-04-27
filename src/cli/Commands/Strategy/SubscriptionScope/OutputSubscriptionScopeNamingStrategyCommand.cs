// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal class OutputSubscriptionScopeNamingStrategyCommand : SubscriptionScopeNamingStrategyCommand<OutputSubscriptionScopeNamingStrategySettings>
    {
        private readonly IStore store;

        public OutputSubscriptionScopeNamingStrategyCommand(ArmClient client, IStore store)
            : base(client)
        {
            this.store = store;
        }

        public override async Task<int> ExecuteAsync(CommandContext context, OutputSubscriptionScopeNamingStrategySettings settings)
        {
            var deployment = this.Provide(settings).ToSubscriptionDeployment();

            await this.store.SaveAsync(this.NormalizePath(settings.OutputPath), deployment.ToBinaryData());

            return 0;
        }

        private string NormalizePath(string path)
        {
            return Path.IsPathFullyQualified(path)
                ? path
                : Path.Combine(AppContext.BaseDirectory, path);
        }
    }
}
