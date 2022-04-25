// See the LICENSE.TXT file in the project root for full license information.

using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Models;
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

        public async Task DeployAsync(SubscriptionResource subscription, CancellationToken cancellationToken = default)
        {
            var policyDefinitionCollection = subscription.GetSubscriptionPolicyDefinitions();
            foreach (var policy in this.Policies)
            {
                var operation = await policyDefinitionCollection.CreateOrUpdateAsync(
                    WaitUntil.Started,
                    policy.Name,
                    policy.Properties,
                    cancellationToken);
                await operation.WaitForCompletionAsync(cancellationToken);
            }

            await this.InternalDeployAsync(subscription.GetArmDeployments(), cancellationToken);
        }

        public async Task DeployAsync(ManagementGroupResource managementGroup, CancellationToken cancellationToken = default)
        {
            var policyDefinitionCollection = managementGroup.GetManagementGroupPolicyDefinitions();
            foreach (var policy in this.Policies)
            {
                var operation = await policyDefinitionCollection.CreateOrUpdateAsync(
                    WaitUntil.Started,
                    policy.Name,
                    policy.Properties,
                    cancellationToken);
                await operation.WaitForCompletionAsync(cancellationToken);
            }

            await this.InternalDeployAsync(managementGroup.GetArmDeployments(), cancellationToken);
        }

        private async Task InternalDeployAsync(ArmDeploymentCollection deployments, CancellationToken cancellationToken = default)
        {
            var template = new SubscriptionDeploymentTemplateData(((IEnumerable<Resource>)this.initiatives)
                .Concat(this.assignments)
                .ToArray()).ToBinaryData();

            var operation = await deployments.CreateOrUpdateAsync(
                deploymentName: Guid.NewGuid().ToString(),
                content: new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
                {
                    Template = template,
                })
                {
                    Location = AzureLocation.WestEurope
                },
                waitUntil: WaitUntil.Started,
                cancellationToken: cancellationToken);

            await operation.WaitForCompletionAsync(cancellationToken);
        }
    }
}
