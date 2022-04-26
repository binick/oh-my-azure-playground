// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public class Assignment : Resource<PolicyAssignmentData>
    {
        public Assignment(string name, string displayName, ResourceIdentifier policyDefinition, AssignmentMetadata metadata, EnforcementMode enforcementMode)
            : this(name, displayName, policyDefinition, enforcementMode)
        {
            this.Properties.Metadata = metadata.ToBinaryData();
        }

        public Assignment(string name, string displayName, ResourceIdentifier policyDefinition, EnforcementMode enforcementMode)
            : base("Microsoft.Authorization/policyAssignments", name, "2021-06-01")
        {
            this.Properties = new PolicyAssignmentData();
            this.Properties.DisplayName = displayName;
            this.Properties.Description = "This policy assignment was automatically created by oh-my-azure-playground";
            this.Properties.EnforcementMode = enforcementMode;
            this.Properties.PolicyDefinitionId = this.EscapeMalformedSubscriptionResourceIdentifier(policyDefinition);
        }

        private string EscapeMalformedSubscriptionResourceIdentifier(ResourceIdentifier resourceIdentifier)
        {
            return resourceIdentifier.ToString().Replace("/subscriptions//subscriptions", "/subscriptions");
        }
    }
}
