// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace Playground.Policies.Naming
{
    public class ResourceNamingStrategyBuilder : StrategyBuilder
    {
        private readonly ResourceNamingInitiativeBuilder resourceNamingInitiativeBuilder;
        private Policy? abbereviationPolicy;

        public ResourceNamingStrategyBuilder(ArmResource scope)
            : base(scope)
        {
            this.resourceNamingInitiativeBuilder = new ResourceNamingInitiativeBuilder(scope);
        }

        public ResourceNamingStrategyBuilder UsePrefix()
        {
            if (this.abbereviationPolicy is not null)
            {
                throw new InvalidOperationException();
            }

            this.abbereviationPolicy = new ResourcePrefixPolicyBuilder(this.Scope).Build();
            this.resourceNamingInitiativeBuilder.UsePrefix();
            return this;
        }

        public ResourceNamingStrategyBuilder UseSuffix()
        {
            if (this.abbereviationPolicy is not null)
            {
                throw new InvalidOperationException();
            }

            this.abbereviationPolicy = new ResourceSuffixPolicyBuilder(this.Scope).Build();
            this.resourceNamingInitiativeBuilder.UseSuffix();
            return this;
        }

        public ResourceNamingStrategyBuilder UseSuffix(bool value)
        {
            return value
                ? this.UseSuffix()
                : this.UsePrefix();
        }

        public override Strategy Build()
        {
            if (this.abbereviationPolicy is null)
            {
                this.UsePrefix();
            }

            if (this.Scope is SubscriptionResource subscription)
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
                    (ManagementGroupResource)this.Scope,
                    this.abbereviationPolicy!,
                    this.resourceNamingInitiativeBuilder.Build(),
                    this.EnforcementMode);
            }
        }
    }
}
