// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Microsoft.Extensions.DependencyInjection;
using Playground.Cli.Commands.Strategy;
using Playground.Cli.Commands.Strategy.ManagementGroupScope;
using Playground.Cli.Infrastructure;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Playground.Cli
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<TokenCredential, DefaultAzureCredential>();
            services.AddSingleton<IStore, FileStore>();
            services.AddSingleton<ArmClient>();
            services.AddSingleton(s => new AssemblyScanner(AppDomain.CurrentDomain.GetAssemblies(), s));

            var app = new CommandApp(new TypeRegistrar(services));
            app.Configure(configurator =>
            {
                configurator.AddBranch<NamingStrategySettings>("naming", compose =>
                {
                    compose.AddCommand<OutputManagementGroupScopeNamingStrategyCommand>("management-group");

                    compose.AddCommand<OutputSubscriptionScopeNamingStrategyCommand>("subscription");
                });
            });

            try
            {
                await app.RunAsync(args);
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
        }
    }
}
