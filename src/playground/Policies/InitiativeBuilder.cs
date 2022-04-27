// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public abstract class InitiativeBuilder
    {
        protected InitiativeBuilder(ArmResource scope)
        {
            this.EnforcementMode = EnforcementMode.DoNotEnforce;
            this.Scope = scope;
        }

        protected EnforcementMode EnforcementMode { get; set; }

        protected ArmResource Scope { get; }

        public InitiativeBuilder Enforce()
        {
            this.EnforcementMode = EnforcementMode.Enforced;
            return this;
        }

        public abstract Initiative Build();
    }
}
