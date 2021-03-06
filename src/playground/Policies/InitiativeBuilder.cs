// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public abstract class InitiativeBuilder
    {
        protected InitiativeBuilder()
        {
            this.EnforcementMode = EnforcementMode.DoNotEnforce;
        }

        protected EnforcementMode EnforcementMode { get; set; }

        public InitiativeBuilder Enforce()
        {
            this.EnforcementMode = EnforcementMode.Enforced;
            return this;
        }

        public abstract Initiative Build();
    }
}
