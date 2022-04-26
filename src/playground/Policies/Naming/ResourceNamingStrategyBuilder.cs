// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace Playground.Policies.Naming
{
    public class ResourceNamingStrategyBuilder : StrategyBuilder
    {
        private readonly ResourceNamingInitiativeBuilder resourceNamingInitiativeBuilder;
        private readonly ArmResource parent;
        private Policy? abbereviationPolicy;

        public ResourceNamingStrategyBuilder(ArmResource parent)
        {
            this.resourceNamingInitiativeBuilder = new ResourceNamingInitiativeBuilder(parent);
            this.parent = parent;
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

            if (this.parent is SubscriptionResource subscription)
            {
                return new ResourceNamingStrategy(
                    subscription,
                    this.abbereviationPolicy!,
                    this.resourceNamingInitiativeBuilder.Build(),
                    this.EnforcementMode);
            }
            else
            {
                return new ResourceNamingStrategy(
                    (ManagementGroupResource)this.parent,
                    this.abbereviationPolicy!,
                    this.resourceNamingInitiativeBuilder.Build(),
                    this.EnforcementMode);
            }

        }
    }
}
