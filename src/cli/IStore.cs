// See the LICENSE.TXT file in the project root for full license information.

namespace Playground.Cli
{
    internal interface IStore
    {
        Task SaveAsync(string path, ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default);
    }
}
