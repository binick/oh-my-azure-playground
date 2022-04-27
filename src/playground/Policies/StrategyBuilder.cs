// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public abstract class StrategyBuilder
    {
        private readonly ICollection<Policy> policies;
        private readonly ICollection<Initiative> initiatives;
        private readonly ICollection<Assignment> assignments;

        protected StrategyBuilder(ArmResource scope)
        {
            this.policies = new HashSet<Policy>();
            this.initiatives = new HashSet<Initiative>();
            this.assignments = new HashSet<Assignment>();
            this.EnforcementMode = EnforcementMode.DoNotEnforce;
            this.Scope = scope;
        }

        protected IEnumerable<Policy> Policies => this.policies;

        protected IEnumerable<Initiative> Initiatives => this.initiatives;

        protected IEnumerable<Assignment> Assignments => this.assignments;

        protected EnforcementMode EnforcementMode { get; private set; }

        protected ArmResource Scope { get; }

        public abstract Strategy Build();

        public StrategyBuilder Enforce()
        {
            this.EnforcementMode = EnforcementMode.Enforced;
            return this;
        }

        protected StrategyBuilder AddPolicy(Policy policy)
        {
            this.policies.Add(policy);
            return this;
        }

        protected StrategyBuilder AddInitiative(Initiative initiative)
        {
            this.initiatives.Add(initiative);
            return this;
        }
    }
}
