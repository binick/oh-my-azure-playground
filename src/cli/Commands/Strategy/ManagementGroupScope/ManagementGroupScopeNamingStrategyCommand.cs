// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Playground.Policies.Naming;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal abstract class ManagementGroupScopeNamingStrategyCommand<TSettings> : AsyncCommand<TSettings>
        where TSettings : ManagementGroupScopeNamingStrategySettings
    {
        private readonly ArmClient client;

        protected ManagementGroupScopeNamingStrategyCommand(ArmClient client)
        {
            this.client = client;
        }

        protected Policies.Strategy Provide(TSettings settings)
        {
            var managementGroup = this.client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier(settings.Scope));

            return new ResourceNamingStrategyBuilder(managementGroup)
                .UseSuffix(settings.UseSuffix)
                .Build();
        }
    }
}
