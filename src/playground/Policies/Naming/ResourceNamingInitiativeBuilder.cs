// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public class ResourceNamingInitiativeBuilder : InitiativeBuilder
    {
        public static readonly string Name = "policy-resource-naming-initiative";
        public static readonly string DispayName = "Resources should be named correctly";
        public static readonly string Description = "This policy enforce a standard naming for resources";

        private ResourceIdentifier policyDefinition;

        public ResourceNamingInitiativeBuilder(ResourceIdentifier policyDefinition)
        {
            this.policyDefinition = policyDefinition;
        }

        public ResourceNamingInitiativeBuilder UsePrefix()
        {
            if (this.policyDefinition is not null)
            {
                throw new InvalidOperationException();
            }

            this.policyDefinition = TenantPolicyDefinition.CreateResourceIdentifier("policy-start-with-naming");
            return this;
        }

        public ResourceNamingInitiativeBuilder UseSuffix()
        {
            if (this.policyDefinition is not null)
            {
                throw new InvalidOperationException();
            }

            this.policyDefinition = TenantPolicyDefinition.CreateResourceIdentifier("policy-end-with-naming");
            return this;
        }

        public override Initiative Build()
        {
            var json = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Assets", "abbreviations.json")));

            var policyCollection = ResourceNamingInitiativeBuilder.ParsePolicySetDefinition(json, this.policyDefinition);

            return new Initiative(
                Name,
                DispayName,
                Description,
                new PolicyMetadata("General", "0.1.0", true, false),
                policyCollection.First(),
                policyCollection.Skip(1).ToArray());
        }

        private static IEnumerable<PolicyDefinitionReference> ParsePolicySetDefinition(JsonDocument json, ResourceIdentifier policy)
        {
            foreach (var element in json.RootElement.EnumerateArray())
            {
                var abbreviation = element.GetProperty("abbreviation").GetString() !;

                var reference = new PolicyDefinitionReference(policy)
                {
                    PolicyDefinitionReferenceId = DeterministicGuid.Parse(policy!, abbreviation).ToString()
                };
                reference.Parameters.Add("providerNamespace", new ParameterValuesValue
                {
                    Value = element.GetProperty("providerNamespace").GetString()
                });
                reference.Parameters.Add("entity", new ParameterValuesValue
                {
                    Value = element.GetProperty("resourceType").GetString()
                });
                reference.Parameters.Add("prefix", new ParameterValuesValue
                {
                    Value = abbreviation
                });
                reference.Parameters.Add("effect", new ParameterValuesValue
                {
                    Value = "audit"
                });

                yield return reference;
            }
        }
    }
}
