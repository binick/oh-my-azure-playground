// See the LICENSE.TXT file in the project root for full license information.

using Spectre.Console.Cli;

namespace Playground.Cli.Tests
{
    internal class StubRemainingArguments : IRemainingArguments
    {
        public StubRemainingArguments()
            : this(new Dictionary<string, string?>(), new HashSet<string>())
        {
        }

        public StubRemainingArguments(IDictionary<string, string?> parsed, ICollection<string> raw)
        {
            this.Parsed = parsed.ToLookup(p => p.Key, p => p.Value);
            this.Raw = new List<string>(raw);
        }

        public ILookup<string, string?> Parsed { get; }

        public IReadOnlyList<string> Raw { get; }
    }
}
