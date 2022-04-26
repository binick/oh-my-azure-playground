// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;
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

            policy.Properties.Mode = "All";

            var providerNamespaceDefinition = new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Resource provider namespace",
                    Description = "Identify the ARM resource provider"
                }
            };
            policy.Properties.Parameters.Add(key: "providerNamespace", value: providerNamespaceDefinition);

            var entityDefinition = new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Entity",
                    Description = "Name of the ARM entity"
                }
            };
            policy.Properties.Parameters.Add(key: "entity", value: entityDefinition);

            var prefixDefinition = new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Prefix",
                    Description = "Prefix that the resource must have, such as 'app-'"
                }
            };
            policy.Properties.Parameters.Add(key: "prefix", value: prefixDefinition);

            var effectDefinition = new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Effect",
                    Description = "Enable or disable the execution of the policy"
                }
            };

            // Todo: seems the allowed values cause a serialization exception.
            // effectDefinition.AllowedValues.Add(BinaryData.FromString(PolicyRuleEffect.Audit));
            // effectDefinition.AllowedValues.Add(BinaryData.FromString(PolicyRuleEffect.Deny));

            policy.Properties.Parameters.Add(key: "effect", value: effectDefinition);

            return policy;
        }
    }
}
