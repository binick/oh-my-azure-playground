// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public class ResourceNamingInitiativeBuilder : InitiativeBuilder
    {
        public static readonly string Name = "policy-resource-naming-initiative";
        public static readonly string DispayName = "Resources should be named correctly";
        public static readonly string Description = "This policy enforce a standard naming for resources";

        private readonly IDictionary<string, string> specificPolicyParameters;
        private readonly ArmResource parent;
        private ResourceIdentifier policyDefinition = null!;

        public ResourceNamingInitiativeBuilder(ArmResource parent)
        {
            if (parent is not SubscriptionResource or ManagementGroupResource)
            {
                throw new InvalidOperationException(nameof(parent));
            }

            this.specificPolicyParameters = new Dictionary<string, string>();
            this.parent = parent;
        }

        public ResourceNamingInitiativeBuilder UsePrefix()
        {
            if (this.policyDefinition is not null)
            {
                throw new InvalidOperationException();
            }

            this.policyDefinition = this.parent is SubscriptionResource
                ? SubscriptionPolicyDefinitionResource.CreateResourceIdentifier(this.parent.Id, ResourcePrefixPolicyBuilder.Name)
                : ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier(this.parent.Id, ResourcePrefixPolicyBuilder.Name);
            this.specificPolicyParameters.Add("abbreviation", "prefix");
            return this;
        }

        public ResourceNamingInitiativeBuilder UseSuffix()
        {
            if (this.policyDefinition is not null)
            {
                throw new InvalidOperationException();
            }

            this.policyDefinition = this.parent is SubscriptionResource
                ? SubscriptionPolicyDefinitionResource.CreateResourceIdentifier(this.parent.Id, ResourceSuffixPolicyBuilder.Name)
                : ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier(this.parent.Id, ResourceSuffixPolicyBuilder.Name);
            this.specificPolicyParameters.Add("abbreviation", "suffix");
            return this;
        }

        public override Initiative Build()
        {
            if (this.policyDefinition is null)
            {
                this.UsePrefix();
            }

            var json = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Assets", "abbreviations.json")));

            var policyCollection = this.ParsePolicySetDefinition(json, this.policyDefinition!);

            return new Initiative(
                Name,
                DispayName,
                Description,
                new PolicyMetadata("General", "0.1.0", true, false),
                policyCollection.First(),
                policyCollection.Skip(1).ToArray());
        }

        private IEnumerable<PolicyDefinitionReference> ParsePolicySetDefinition(JsonDocument json, ResourceIdentifier policy)
        {
            foreach (var element in json.RootElement.EnumerateArray())
            {
                var abbreviation = element.GetProperty("abbreviation").GetString() !;

                if (element.TryGetProperty("hypenAllowed", out var withHypen) && withHypen.GetBoolean())
                {
                    abbreviation = policy.ToString().Split('/').Last().Equals(ResourcePrefixPolicyBuilder.Name, StringComparison.OrdinalIgnoreCase)
                        ? $"{abbreviation}-"
                        : $"-{abbreviation}";
                }

                var policyId = this.EscapeMalformedSubscriptionResourceIdentifier(policy);
                var reference = new PolicyDefinitionReference(policyId)
                {
                    PolicyDefinitionReferenceId = DeterministicGuid.Parse(policyId, abbreviation).ToString()
                };
                reference.Parameters.Add("providerNamespace", new ArmPolicyParameterValue
                {
                    Value = BinaryData.FromObjectAsJson(element.GetProperty("providerNamespace").GetString() !)
                });
                reference.Parameters.Add("entity", new ArmPolicyParameterValue
                {
                    Value = BinaryData.FromObjectAsJson(element.GetProperty("resourceType").GetString() !)
                });
                reference.Parameters.Add(this.specificPolicyParameters["abbreviation"], new ArmPolicyParameterValue
                {
                    Value = BinaryData.FromObjectAsJson(abbreviation)
                });
                reference.Parameters.Add("effect", new ArmPolicyParameterValue
                {
                    Value = BinaryData.FromObjectAsJson("audit")
                });

                yield return reference;
            }
        }

        private string EscapeMalformedSubscriptionResourceIdentifier(ResourceIdentifier resourceIdentifier)
        {
            return resourceIdentifier.ToString().Replace("/subscriptions//subscriptions", "/subscriptions");
        }
    }
}
