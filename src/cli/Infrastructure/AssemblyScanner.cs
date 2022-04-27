// See the LICENSE.TXT file in the project root for full license information.

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Cli.Infrastructure
{
    internal class AssemblyScanner
    {
        private readonly IEnumerable<Assembly> assemblies;
        private readonly IServiceProvider provider;

        public AssemblyScanner(IEnumerable<Assembly> assembliesToScan, IServiceProvider provider)
        {
            this.assemblies = assembliesToScan;
            this.provider = provider;
        }

        public IEnumerable<T> Scan<T>()
        {
            var type = typeof(T);
            return this.assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(t => type.IsAssignableFrom(t) && !t.Equals(type))
                .Select(t => ActivatorUtilities.CreateInstance(this.provider, t))
                .Where(i => i is not null)
                .Cast<T>();
        }
    }
}
