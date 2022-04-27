// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Playground.Extensions
{
    internal static class InitiativeExtensions
    {
        public static ResourceIdentifier ToResourceIdentifier(this string name, ArmResource parent)
        {
            switch (parent)
            {
                case SubscriptionResource _:
                    return SubscriptionPolicySetDefinitionResource.CreateResourceIdentifier(parent.Id, name);
                case ManagementGroupPolicyDefinitionResource _:
                    return ManagementGroupPolicySetDefinitionResource.CreateResourceIdentifier(parent.Id, name);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
