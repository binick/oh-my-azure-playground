// See the LICENSE.TXT file in the project root for full license information.

using System.Security.Cryptography;
using System.Text;

namespace Azure.ResourceManager.Resources
{
    public sealed class DeterministicGuid
    {
        private readonly Guid guid;

        public DeterministicGuid(params string[] parts)
        {
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.Default.GetBytes(string.Concat(parts)));
            this.guid = new Guid(hash);
        }

        public static DeterministicGuid Parse(params string[] parts)
        {
            return new DeterministicGuid(parts);
        }

        public override string ToString()
        {
            return this.guid.ToString();
        }
    }
}
