// See the LICENSE.TXT file in the project root for full license information.

namespace Playground.Cli.Tests
{
    internal class MockStore : IStore
    {
        private readonly ICollection<KeyValuePair<string, BinaryData>> pairs;

        public MockStore()
        {
            this.pairs = new HashSet<KeyValuePair<string, BinaryData>>();
        }

        public IEnumerable<KeyValuePair<string, BinaryData>> SavedPairs => this.pairs;

        public Task SaveAsync(string path, ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default)
        {
            this.pairs.Add(new KeyValuePair<string, BinaryData>(path, BinaryData.FromBytes(data)));
            return Task.CompletedTask;
        }
    }
}
