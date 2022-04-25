// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager.Resources.Models;
using Playground.Policies;

namespace Playground.Tests
{
    public class DummyPolicy : Policy
    {
        public DummyPolicy()
            : base(
                  "Dummy",
                  "Dummy testing policy",
                  "Dummy policy for testing",
                  new PolicyMetadata(
                      "test",
                      "0.1.0",
                      true,
                      false),
                  new PolicyRule(
                      new PolicyRuleNotOperator(
                          new PolicyRuleLikeCondition("result", "succeded")),
                      new PolicyRuleEffect("refact")))
        {
        }

        public DummyPolicy(PolicyRule policyRule)
            : base(
                  "Dummy",
                  "Dummy testing policy",
                  "Dummy policy for testing",
                  new PolicyMetadata(
                      "test",
                      "0.1.0",
                      true,
                      false),
                  policyRule)
        {
        }
    }
}
