// See the LICENSE.TXT file in the project root for full license information.

using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
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
        private ArmResource parent;

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
            this.parent = subscription;
            await this.InternalDeployAsync(subscription.GetArmDeployments(), cancellationToken);
        }

        public async Task DeployAsync(ManagementGroupResource managementGroup, CancellationToken cancellationToken = default)
        {
            this.parent = managementGroup;
            await this.InternalDeployAsync(managementGroup.GetArmDeployments(), cancellationToken);
        }

        private async Task InternalDeployAsync(ArmDeploymentCollection deployments, CancellationToken cancellationToken = default)
        {
            // For the moment we approximate that all initiative depends from all policies and all assignments depends from all initiatives.
            foreach (var assignment in this.assignments)
            {
                foreach (var initiative in this.initiatives)
                {
                    assignment.AddDependency(this.parent is SubscriptionResource
                        ? SubscriptionPolicySetDefinitionResource.CreateResourceIdentifier(this.parent.Id, initiative.Name)
                        : ManagementGroupPolicySetDefinitionResource.CreateResourceIdentifier(this.parent.Id, initiative.Name));

                    foreach (var policyName in this.policies.Select(p => p.Name))
                    {
                        initiative.AddDependency(this.parent is SubscriptionResource
                            ? SubscriptionPolicyDefinitionResource.CreateResourceIdentifier(this.parent.Id, policyName)
                            : ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier(this.parent.Id, policyName));
                    }
                }
            }

            var template = new SubscriptionDeploymentTemplateData(((IEnumerable<Resource>)this.Policies)
                .Concat(this.initiatives)
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
