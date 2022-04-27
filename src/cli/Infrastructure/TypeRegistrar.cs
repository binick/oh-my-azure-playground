// See the LICENSE.TXT file in the project root for full license information.

using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Playground.Cli.Infrastructure
{
    public sealed class TypeRegistrar : ITypeRegistrar
    {
        private readonly IServiceCollection services;

        public TypeRegistrar(IServiceCollection services)
        {
            this.services = services;
        }

        public ITypeResolver Build()
        {
            return new TypeResolver(this.services.BuildServiceProvider());
        }

        public void Register(Type service, Type implementation)
        {
            this.services.AddSingleton(service, implementation);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            this.services.AddSingleton(service, implementation);
        }

        public void RegisterLazy(Type service, Func<object> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.services.AddSingleton(service, (provider) => factory());
        }
    }
}
