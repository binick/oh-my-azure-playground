// See the LICENSE.TXT file in the project root for full license information.

namespace Azure.ResourceManager.Resources.Models
{
    public class SubscriptionDeploymentTemplateData : DeploymentTemplateData
    {
        public SubscriptionDeploymentTemplateData(params Resource[] resources)
            : base(resources)
        {
            this.Schema = "https://schema.management.azure.com/schemas/2018-05-01/subscriptionDeploymentTemplate.json#";
        }
    }
}
