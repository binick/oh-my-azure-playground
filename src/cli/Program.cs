// See the LICENSE.TXT file in the project root for full license information.

using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Playground.Policies.Naming;

namespace Playground.Cli
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new ArmClient(new InteractiveBrowserCredential());
            var subscription = await client.GetDefaultSubscriptionAsync();

            // DeleteAllForSub(subscription);
            await new ResourceNamingStrategyBuilder(subscription).Build().DeployAsync(subscription);
        }

        private static void DeleteAllForSub(SubscriptionResource subscription)
        {
            var policyCollection = subscription.GetSubscriptionPolicyDefinitions();
            var policies = policyCollection.Where(p => p.Data.PolicyType.Value.Equals(PolicyType.Custom));
            var assignments = subscription.GetPolicyAssignments();

            foreach (var policy in policies)
            {
                foreach (var assignemnt in assignments.Where(a => a.Data.PolicyDefinitionId.Equals(policy.Data.Id)))
                {
                    assignemnt.Delete(WaitUntil.Completed);
                }

                policy.Delete(WaitUntil.Completed);
            }
        }
    }
}
