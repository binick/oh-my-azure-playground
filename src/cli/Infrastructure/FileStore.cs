// See the LICENSE.TXT file in the project root for full license information.

namespace Playground.Cli.Infrastructure
{
    internal class FileStore : IStore
    {
        public Task SaveAsync(string path, ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
        {
            return File.WriteAllBytesAsync(path, data.ToArray(), cancellationToken);
        }
    }
}
