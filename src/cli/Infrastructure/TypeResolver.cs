// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Infrastructure
{
    internal sealed class TypeResolver : ITypeResolver, IDisposable
    {
        private readonly IServiceProvider provider;
        private bool isAlreadyDisposed;

        public TypeResolver(IServiceProvider provider)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public object Resolve(Type? type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return this.provider.GetService(type) !;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.isAlreadyDisposed)
            {
                if (disposing && this.provider is IDisposable disposable)
                {
                    disposable.Dispose();
                }

                this.isAlreadyDisposed = true;
            }
        }
    }
}
