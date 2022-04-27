// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Playground.Cli.Tests
{
    internal class FakeSubscriptionResource : SubscriptionResource
    {
        private readonly ResourceIdentifier id;

        public FakeSubscriptionResource(ResourceIdentifier id)
        {
            this.id = id;
        }

        public override ResourceIdentifier Id => this.id;
    }
}
