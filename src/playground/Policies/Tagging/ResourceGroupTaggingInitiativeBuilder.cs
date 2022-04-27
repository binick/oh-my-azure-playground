// See the LICENSE.TXT file in the project root for full license information.

using System.Collections.ObjectModel;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Tagging
{
    public class ResourceGroupTaggingInitiativeBuilder : InitiativeBuilder
    {
        public static readonly string Name = "policy-resource-group-tagging-initiative";
        public static readonly string DispayName = "Resource group should be tagged correctly";
        public static readonly string Description = "This policy enforce a standard tagging of resource groups";

        private bool useSuggestedTags = false;
        private bool useOtherCommonTags = false;
        private IEnumerable<KeyValuePair<string, string>> tags;

        public ResourceGroupTaggingInitiativeBuilder(ArmResource scope)
            : base(scope)
        {
            this.tags = new Collection<KeyValuePair<string, string>>();
        }

        public ResourceGroupTaggingInitiativeBuilder WithSuggestedTags()
        {
            this.useSuggestedTags = true;
            return this;
        }

        public ResourceGroupTaggingInitiativeBuilder WithOtherCommonTags()
        {
            this.useOtherCommonTags = true;
            return this;
        }

        public ResourceGroupTaggingInitiativeBuilder WithTag(string name, string? description = null)
        {
            this.tags = this.tags.Append(new (name, description ?? string.Empty));
            return this;
        }

        public ResourceGroupTaggingInitiativeBuilder WithTags(params KeyValuePair<string, string?>[] tags)
        {
            this.tags = this.tags.Concat(tags!);
            return this;
        }

        public override Initiative Build()
        {
            var policyDefintion = TenantPolicyDefinitionResource.CreateResourceIdentifier("96670d01-0a4d-4649-9c89-2d3abc0a5025");

            var suggestedTags = new Dictionary<string, string>
            {
                { "workload-name", "Name of the workload the resource supports." },
                { "data-classification", "Sensitivity of data hosted by this resource." },
                { "criticality", "Business impact of the resource or supported workload." },
                { "business-unit", "Top-level division of your company that owns the subscription or workload that the resource belongs to. In smaller organizations, this tag might represent a single corporate or shared top-level organizational element." },
                { "ops-commitment", "Level of operations support provided for this workload or resource." },
                { "ops-team", "Team accountable for day-to-day operations." }
            };

            var otherCommonTags = new Dictionary<string, string>
            {
                { "app-name", "Added granularity if the workload is subdivided across multiple applications or services." },
                { "approver", "Person responsible for approving costs related to this resource." },
                { "budget-amount", "Money approved for this application service or workload." },
                { "cost-center", "Accounting cost center associated with this resource." },
                { "dr", "Business criticality of the application workload or service." },
                { "end-date", "Date when the application workload or service is scheduled for retirement." },
                { "env", "Deployment environment of the application workload or service." },
                { "owner", "Owner of the application workload or service." },
                { "requester", "User who requested the creation of this application." },
                { "service-class", "Service level agreement level of the application workload or service." },
                { "start-date", "Date when the application workload or service was first deployed." }
            };

            if (!this.tags.Any() && !this.useOtherCommonTags && !this.useSuggestedTags)
            {
                this.tags = this.tags.Concat(suggestedTags).Concat(otherCommonTags);
            }
            else
            {
                if (this.useSuggestedTags)
                {
                    this.tags = this.tags.Concat(suggestedTags);
                }

                if (this.useOtherCommonTags)
                {
                    this.tags = this.tags.Concat(otherCommonTags);
                }
            }

            var references = new List<PolicyDefinitionReference>();

            foreach (var tag in this.tags)
            {
                var policy = new PolicyDefinitionReference(policyDefintion)
                {
                    PolicyDefinitionReferenceId = DeterministicGuid.Parse(policyDefintion!, tag.Key).ToString()
                };
                policy.Parameters.Add("tagName", new ArmPolicyParameterValue
                {
                    Value = BinaryData.FromString(tag.Value)
                });

                references.Add(policy);
            }

            return new Initiative(
                this.Scope,
                ResourceGroupTaggingInitiativeBuilder.Name,
                ResourceGroupTaggingInitiativeBuilder.DispayName,
                ResourceGroupTaggingInitiativeBuilder.Description,
                new PolicyMetadata("Tags", "0.1.0", true, false),
                references.First(),
                references.Skip(1).ToArray());
        }
    }
}
