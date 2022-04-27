// See the LICENSE.TXT file in the project root for full license information.

using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Playground.Policies
{
    public abstract class Strategy
    {
        private readonly ArmResource scope;
        private readonly IEnumerable<Policy> policies;
        private readonly IEnumerable<Initiative> initiatives;
        private readonly IEnumerable<Assignment> assignments;

        protected Strategy(ArmResource scope, IReadOnlyCollection<Policy> policies, IReadOnlyCollection<Initiative> initiatives, IReadOnlyCollection<Assignment> assignments)
        {
            this.scope = scope;
            this.policies = policies;
            this.initiatives = initiatives;
            this.assignments = assignments;
        }

        public IEnumerable<Policy> Policies => this.policies;

        public IEnumerable<Initiative> Initiatives => this.initiatives;

        public IEnumerable<Assignment> Assignments => this.assignments;

        public DeploymentTemplateData ToSubscriptionDeployment()
        {
            // For the moment we approximate that all initiative depends from all policies and all assignments depends from all initiatives.
            foreach (var assignment in this.assignments)
            {
                foreach (var initiative in this.initiatives)
                {
                    assignment.AddDependency(this.scope is SubscriptionResource
                        ? SubscriptionPolicySetDefinitionResource.CreateResourceIdentifier(this.scope.Id, initiative.Name)
                        : ManagementGroupPolicySetDefinitionResource.CreateResourceIdentifier(this.scope.Id, initiative.Name));

                    foreach (var policyName in this.policies.Select(p => p.Name))
                    {
                        initiative.AddDependency(this.scope is SubscriptionResource
                            ? SubscriptionPolicyDefinitionResource.CreateResourceIdentifier(this.scope.Id, policyName)
                            : ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier(this.scope.Id, policyName));
                    }
                }
            }

            return new SubscriptionDeploymentTemplateData(((IEnumerable<Resource>)this.Policies)
                .Concat(this.initiatives)
                .Concat(this.assignments)
                .ToArray());
        }

        public DeploymentTemplateData ToManagementGroupDeployment()
        {
            // For the moment we approximate that all initiative depends from all policies and all assignments depends from all initiatives.
            foreach (var assignment in this.assignments)
            {
                foreach (var initiative in this.initiatives)
                {
                    assignment.AddDependency(this.scope is SubscriptionResource
                        ? SubscriptionPolicySetDefinitionResource.CreateResourceIdentifier(this.scope.Id, initiative.Name)
                        : ManagementGroupPolicySetDefinitionResource.CreateResourceIdentifier(this.scope.Id, initiative.Name));

                    foreach (var policyName in this.policies.Select(p => p.Name))
                    {
                        initiative.AddDependency(this.scope is SubscriptionResource
                            ? SubscriptionPolicyDefinitionResource.CreateResourceIdentifier(this.scope.Id, policyName)
                            : ManagementGroupPolicyDefinitionResource.CreateResourceIdentifier(this.scope.Id, policyName));
                    }
                }
            }

            return new ManagementGroupDeploymentData(((IEnumerable<Resource>)this.Policies)
                .Concat(this.initiatives)
                .Concat(this.assignments)
                .ToArray());
        }

        private async Task InternalDeployAsync(ArmDeploymentCollection deployments, CancellationToken cancellationToken = default)
        {
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
