// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public abstract class PolicyBuilder
    {
        protected PolicyBuilder()
        {
            this.EnforcementMode = EnforcementMode.DoNotEnforce;
        }

        protected EnforcementMode EnforcementMode { get; set; }

        public PolicyBuilder Enforce()
        {
            this.EnforcementMode = EnforcementMode.Default;
            return this;
        }

        public abstract Policy Build();
    }
}
