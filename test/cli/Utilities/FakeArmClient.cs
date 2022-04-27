// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace Playground.Cli.Tests
{
    internal class FakeArmClient : ArmClient
    {
        public FakeArmClient()
        {
        }

        public override ManagementGroupResource GetManagementGroupResource(ResourceIdentifier id)
        {
            return new FakeManagementGroupResource(id);
        }

        public override SubscriptionResource GetSubscriptionResource(ResourceIdentifier id)
        {
            return new FakeSubscriptionResource(id);
        }
    }
}
