// See the LICENSE.TXT file in the project root for full license information.

using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public abstract class Strategy
    {
        private readonly IEnumerable<Policy> policies;
        private readonly IEnumerable<Initiative> initiatives;
        private readonly IEnumerable<Assignment> assignments;

        protected Strategy(IReadOnlyCollection<Policy> policies, IReadOnlyCollection<Initiative> initiatives, IReadOnlyCollection<Assignment> assignments)
        {
            this.policies = policies;
            this.initiatives = initiatives;
            this.assignments = assignments;
        }

        public IEnumerable<Policy> Policies => this.policies;

        public IEnumerable<Initiative> Initiatives => this.initiatives;

        public IEnumerable<Assignment> Assignments => this.assignments;

        public async Task ApplyAsync(Subscription subscription, CancellationToken cancellationToken = default)
        {
            var policyCollection = subscription.GetSubscriptionPolicyDefinitions();
            foreach (var policy in this.Policies)
            {
                await policyCollection.CreateOrUpdateAsync(
                    policyDefinitionName: policy.PolicyName,
                    parameters: policy,
                    waitForCompletion: false);
            }

            var initiativeCollection = subscription.GetSubscriptionPolicySetDefinitions();
            foreach (var initiative in this.Initiatives)
            {
                await initiativeCollection.CreateOrUpdateAsync(
                    policySetDefinitionName: initiative.PolicySetName,
                    parameters: initiative,
                    waitForCompletion: false);
            }

            await this.InternalApplyAsync(subscription, cancellationToken);

            subscription.GetDeployments();
        }

        public async Task ApplyAsync(ManagementGroup managementGroup, CancellationToken cancellationToken = default)
        {
            var policyCollection = managementGroup.GetManagementGroupPolicyDefinitions();
            foreach (var policy in this.Policies)
            {
                await policyCollection.CreateOrUpdateAsync(
                    policyDefinitionName: policy.PolicyName,
                    parameters: policy,
                    waitForCompletion: false);
            }

            var initiativeCollection = managementGroup.GetManagementGroupPolicySetDefinitions();
            foreach (var initiative in this.Initiatives)
            {
                await initiativeCollection.CreateOrUpdateAsync(
                    policySetDefinitionName: initiative.PolicySetName,
                    parameters: initiative,
                    waitForCompletion: false);
            }

            await this.InternalApplyAsync(managementGroup, cancellationToken);
        }

        private async Task InternalApplyAsync(ArmResource targetScope, CancellationToken cancellationToken = default)
        {
            var assignamentCollection = targetScope.GetPolicyAssignments();
            foreach (var assignment in this.Assignments)
            {
                await assignamentCollection.CreateOrUpdateAsync(
                    policyAssignmentName: assignment.AssignmentName,
                    parameters: assignment,
                    waitForCompletion: false,
                    cancellationToken: cancellationToken);
            }
        }

        private async Task InternalDeployAsync(DeploymentCollection deployments, CancellationToken cancellationToken = default)
        {
            var operation = await deployments.CreateOrUpdateAsync(
                deploymentName: string.Empty,
                parameters: new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)),
                waitForCompletion: false);


        }
    }
}
