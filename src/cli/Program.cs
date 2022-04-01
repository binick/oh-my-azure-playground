using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Playground.Policies.Naming;
using Spectre.Console;

namespace Playground.Cli
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new ArmClient(new InteractiveBrowserCredential());
            var subscription = await client.GetDefaultSubscriptionAsync();

            //DeleteAllForSub(subscription);

            var startWithDefinitionPolicy = new ResourcePrefixPolicyBuilder().Build();
            var endWithDefinitionPolicy = new ResourceSuffixPolicyBuilder().Build();
            var startWithSetPolicyDefinition = new ResourceNamingInitiativeBuilder.Build();
            AnsiConsole.WriteLine(subscription?.Id.SubscriptionId);
            var policyCollection = subscription?.GetSubscriptionPolicyDefinitions();
            var r = await policyCollection.CreateOrUpdate(true, startWithDefinitionPolicy.PolicyName, startWithDefinitionPolicy).WaitForCompletionAsync();
            AnsiConsole.WriteLine(r.Value.Data.Name);
            r = await policyCollection.CreateOrUpdate(true, endWithDefinitionPolicy.PolicyName, endWithDefinitionPolicy).WaitForCompletionAsync();
            AnsiConsole.WriteLine(r.Value.Data.Name);
            var policySetCollection = subscription?.GetSubscriptionPolicySetDefinitions();
            var s = await policySetCollection.CreateOrUpdate(true, startWithSetPolicyDefinition.PolicySetName, startWithSetPolicyDefinition).WaitForCompletionAsync();
            AnsiConsole.WriteLine(s.Value.Data.Name);
        }

        private static void DeleteAllForSub(Subscription subscription)
        {
            var policyCollection = subscription.GetSubscriptionPolicyDefinitions();
            var policies = policyCollection.Where(p => p.Data.PolicyType.Value.Equals(PolicyType.Custom));
            var assignments = subscription.GetPolicyAssignments();

            foreach (var policy in policies)
            {
                foreach (var assignemnt in assignments.Where(a => a.Data.PolicyDefinitionId.Equals(policy.Data.Id)))
                {
                    assignemnt.Delete(true);
                }

                policy.Delete(true);
            }
        }
    }
}
