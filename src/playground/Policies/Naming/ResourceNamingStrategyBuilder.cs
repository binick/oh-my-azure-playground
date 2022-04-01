// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;

namespace Playground.Policies.Naming
{
    internal class ResourceNamingStrategyBuilder : StrategyBuilder
    {
        private Policy? abbereviationPolicy;

        public ResourceNamingStrategyBuilder()
        {
        }

        public ResourceNamingStrategyBuilder UsePrefix()
        {
            if (this.abbereviationPolicy is not null)
            {
                throw new InvalidOperationException();
            }

            this.abbereviationPolicy = new ResourcePrefixPolicyBuilder().Build();
            return this;
        }

        public ResourceNamingStrategyBuilder UseSuffix()
        {
            if (this.abbereviationPolicy is not null)
            {
                throw new InvalidOperationException();
            }

            this.abbereviationPolicy = new ResourceSuffixPolicyBuilder().Build();
            return this;
        }

        public override Strategy Build()
        {
            if (this.abbereviationPolicy is null)
            {
                this.UsePrefix();
            }

            return new ResourceNamingStrategy(
                this.abbereviationPolicy!,
                new ResourceNamingInitiativeBuilder(TenantPolicyDefinition.CreateResourceIdentifier(this.abbereviationPolicy!.PolicyName)).Build(),
                this.EnforcementMode);
        }
    }
}
