// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager.ManagementGroups;

namespace Playground.Cli.Tests
{
    internal class FakeManagementGroupResource : ManagementGroupResource
    {
        private readonly ResourceIdentifier id;

        public FakeManagementGroupResource(ResourceIdentifier id)
        {
            this.id = id;
        }

        public override ResourceIdentifier Id => this.id;
    }
}
