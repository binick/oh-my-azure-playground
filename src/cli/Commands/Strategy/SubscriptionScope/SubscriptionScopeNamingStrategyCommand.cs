// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Playground.Policies.Naming;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal abstract class SubscriptionScopeNamingStrategyCommand<TSettings> : AsyncCommand<TSettings>
        where TSettings : SubscriptionScopeNamingStrategySettings
    {
        private readonly ArmClient client;

        protected SubscriptionScopeNamingStrategyCommand(ArmClient client)
        {
            this.client = client;
        }

        protected Policies.Strategy Provide(TSettings settings)
        {
            var subscription = this.client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(settings.Scope));

            return new ResourceNamingStrategyBuilder(subscription)
                .UseSuffix(settings.UseSuffix)
                .Build();
        }
    }
}
