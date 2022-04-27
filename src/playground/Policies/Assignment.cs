// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Assignment : Resource<PolicyAssignmentData>
    {
        public Assignment(ArmResource scope, string name, string displayName, ResourceIdentifier policyDefinition, AssignmentMetadata metadata, EnforcementMode enforcementMode)
            : this(scope, name, displayName, policyDefinition, enforcementMode)
        {
            this.Properties.Metadata = metadata.ToBinaryData();
        }

        public Assignment(ArmResource scope, string name, string displayName, ResourceIdentifier policyDefinition, EnforcementMode enforcementMode)
            : base("Microsoft.Authorization/policyAssignments", name, "2021-06-01")
        {
            this.Scope = scope;
            this.Properties = new PolicyAssignmentData();
            this.Properties.DisplayName = displayName;
            this.Properties.Description = "This policy assignment was automatically created by oh-my-azure-playground";
            this.Properties.EnforcementMode = enforcementMode;
            this.Properties.PolicyDefinitionId = this.EscapeMalformedSubscriptionResourceIdentifier(policyDefinition);
        }

        public ArmResource Scope { get; }

        private string EscapeMalformedSubscriptionResourceIdentifier(ResourceIdentifier resourceIdentifier)
        {
            return resourceIdentifier.ToString().Replace("/subscriptions//subscriptions", "/subscriptions");
        }
    }
}
