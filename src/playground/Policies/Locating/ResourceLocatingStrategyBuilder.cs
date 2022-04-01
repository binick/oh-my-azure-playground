// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;

namespace Playground.Policies.Locating
{
    public sealed class ResourceLocatingStrategyBuilder : StrategyBuilder
    {
        private AzureLocation[] locations = null!;
        private bool strictMode = false;

        public ResourceLocatingStrategyBuilder()
        {
        }

        public ResourceLocatingStrategyBuilder AllowedLocations(params AzureLocation[] locations)
        {
            this.locations = locations;
            return this;
        }

        public ResourceLocatingStrategyBuilder WithStrictMode()
        {
            this.strictMode = true;
            return this;
        }

        public override Strategy Build()
        {
            return new ResourceLocatingStrategy(this.EnforcementMode, this.strictMode, this.locations);
        }
    }
}
