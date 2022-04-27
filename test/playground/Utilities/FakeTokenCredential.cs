// See the LICENSE.TXT file in the project root for full license information.

using Azure.Core;

namespace Playground.Tests
{
    internal class FakeTokenCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddHours(1));
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return ValueTask.FromResult(this.GetToken(requestContext, cancellationToken));
        }
    }
}
