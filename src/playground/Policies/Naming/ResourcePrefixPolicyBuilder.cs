// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public class ResourcePrefixPolicyBuilder : PolicyBuilder
    {
        public static readonly string Name = "policy-start-with-naming";
        public static readonly string DispayName = "Require a prefix on resources, resource groups and subscriptions.";
        public static readonly string Description = "Enforces existence of a prefix.";

        public ResourcePrefixPolicyBuilder()
        {
        }

        public override Policy Build()
        {
            var policy = new Policy(
                ResourcePrefixPolicyBuilder.Name,
                ResourcePrefixPolicyBuilder.DispayName,
                ResourcePrefixPolicyBuilder.Description,
                new PolicyMetadata("General", "0.1.0", true, false),
                new PolicyRule(
                    new PolicyRuleAllOfOperator(
                        new PolicyRuleEqualsCondition("type", "[concat(parameters('providerNamespace'), '/', parameters('entity'))]"),
                        new PolicyRuleEqualsCondition("name", "[concat(parameters('prefix'), '*')]")),
                    new PolicyRuleEffect("[parameters('effect')]")));

            policy.Mode = "All";

            policy.Parameters.Add(key: "providerNamespace", value: new ParameterDefinitionsValue
            {
                Type = ParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Resource provider namespace",
                    Description = "Identify the ARM resource provider"
                }
            });

            policy.Parameters.Add(key: "entity", value: new ParameterDefinitionsValue
            {
                Type = ParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Entity",
                    Description = "Name of the ARM entity"
                }
            });

            policy.Parameters.Add(key: "prefix", value: new ParameterDefinitionsValue
            {
                Type = ParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Prefix",
                    Description = "Prefix that the resource must have, such as 'app-'"
                }
            });

            var effectDefinition = new ParameterDefinitionsValue
            {
                Type = ParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Effect",
                    Description = "Enable or disable the execution of the policy"
                }
            };
            effectDefinition.AllowedValues.Add(PolicyRuleEffect.Audit.Effect);
            effectDefinition.AllowedValues.Add(PolicyRuleEffect.Deny.Effect);

            policy.Parameters.Add(key: "effect", value: effectDefinition);

            return policy;
        }
    }
}
