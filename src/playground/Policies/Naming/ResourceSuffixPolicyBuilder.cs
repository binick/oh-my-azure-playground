// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies.Naming
{
    public class ResourceSuffixPolicyBuilder : PolicyBuilder
    {
        public static readonly string Name = "policy-end-with-naming";
        public static readonly string DispayName = "Require a suffix on resources, resource groups and subscriptions.";
        public static readonly string Description = "Enforces existence of a suffix.";

        public ResourceSuffixPolicyBuilder(ArmResource scope)
            : base(scope)
        {
        }

        public override Policy Build()
        {
            var policy = new Policy(
                this.Scope,
                ResourceSuffixPolicyBuilder.Name,
                ResourceSuffixPolicyBuilder.DispayName,
                ResourceSuffixPolicyBuilder.Description,
                new PolicyMetadata("General", "0.1.0", true, false),
                new PolicyRule(
                    new PolicyRuleAllOfOperator(
                        new PolicyRuleEqualsCondition("type", "[concat(parameters('prividerNamespace'), '/', parameters('entity'))]"),
                        new PolicyRuleEqualsCondition("name", "[concat('*', parameters('suffix'))]")),
                    new PolicyRuleEffect("[parameters('effect')]")));

            policy.Properties.Mode = "All";

            policy.Properties.Parameters.Add(key: "prividerNamespace", value: new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Resource provider namespace",
                    Description = "Identify the ARM resource provider"
                }
            });

            policy.Properties.Parameters.Add(key: "entity", value: new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Entity",
                    Description = "Name of the ARM entity"
                }
            });

            policy.Properties.Parameters.Add(key: "suffix", value: new ArmPolicyParameter
            {
                ParameterType = ArmPolicyParameterType.String,
                Metadata = new ParameterDefinitionsValueMetadata
                {
                    DisplayName = "Suffix",
                    Description = "Suffix that the resource must have, such as '-app'"
                }
            });

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
            // effectDefinition.AllowedValues.Add(BinaryData.FromString(PolicyRuleEffect.Audit.Effect));
            // effectDefinition.AllowedValues.Add(BinaryData.FromString(PolicyRuleEffect.Deny.Effect));
            policy.Properties.Parameters.Add(key: "effect", value: effectDefinition);

            return policy;
        }
    }
}
