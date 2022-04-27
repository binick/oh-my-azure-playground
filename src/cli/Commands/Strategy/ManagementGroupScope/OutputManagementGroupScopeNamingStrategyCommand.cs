// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Spectre.Console.Cli;

namespace Playground.Cli.Commands.Strategy.ManagementGroupScope
{
    internal class OutputManagementGroupScopeNamingStrategyCommand : ManagementGroupScopeNamingStrategyCommand<OutputManagementGroupScopeNamingStrategySettings>
    {
        public OutputManagementGroupScopeNamingStrategyCommand(ArmClient client)
            : base(client)
        {
        }

        public override async Task<int> ExecuteAsync(CommandContext context, OutputManagementGroupScopeNamingStrategySettings settings)
        {
            var deployment = this.Provide(settings).ToManagementGroupDeployment();

            await File.WriteAllBytesAsync(this.NormalizePath(settings.OutputPath), deployment.ToBinaryData().ToArray());

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
