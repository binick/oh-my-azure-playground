// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Playground.Extensions
{
    internal static class PolicyExtensions
    {
        public static ResourceIdentifier ToResourceIdentifier(this string name, ArmResource parent)
        {
            switch (parent)
            {
                case SubscriptionResource _:
                    return SubscriptionPolicyDefinitionResource.CreateResourceIdentifier(parent.Id, name);
                case ManagementGroupPolicyDefinitionResource _:
                    return ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier(parent.Id, name);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
