// See the LICENSE.TXT file in the project root for full license information.

namespace Azure.ResourceManager.Resources.Models
{
    public class TenantDeploymentTemplateData : DeploymentTemplateData
    {
        public TenantDeploymentTemplateData(params Resource[] resources)
            : base(resources)
        {
            this.Schema = "https://schema.management.azure.com/schemas/2019-08-01/tenantDeploymentTemplate.json#";
        }
    }
}
