// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources;

namespace Playground.Policies.Naming
{
    public class ResourceNamingStrategyBuilder : StrategyBuilder
    {
        private readonly ResourceNamingInitiativeBuilder resourceNamingInitiativeBuilder;
        private Policy? abbereviationPolicy;

        public ResourceNamingStrategyBuilder()
        {
            this.resourceNamingInitiativeBuilder = new ResourceNamingInitiativeBuilder();
        }

        public ResourceNamingStrategyBuilder UsePrefix()
        {
            if (this.abbereviationPolicy is not null)
            {
                throw new InvalidOperationException();
            }

            this.abbereviationPolicy = new ResourcePrefixPolicyBuilder().Build();
            this.resourceNamingInitiativeBuilder.UsePrefix();
            return this;
        }

        public ResourceNamingStrategyBuilder UseSuffix()
        {
            if (this.abbereviationPolicy is not null)
            {
                throw new InvalidOperationException();
            }

            this.abbereviationPolicy = new ResourceSuffixPolicyBuilder().Build();
            this.resourceNamingInitiativeBuilder.UseSuffix();
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
                this.resourceNamingInitiativeBuilder.Build(),
                this.EnforcementMode);
        }
    }
}
