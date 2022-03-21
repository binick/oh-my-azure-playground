# Oh My Azure Playground.

This initiative was created to raise awareness for enterprise organizations coming to Azure. And also a bit to satisfy my neatness mania 🙂.

Typically when a big company approaches the cloud one of the main reasons of concern is cost management.
It's normal and healthy to start using the services exposed by the cloud being well aware of the fact that we could spend very high amounts of money, this fear is greater the bigger the size of the company.
The reaction to this awareness is often instinctive and goes to intervene imperatively defining who can do what and where. Basically, since we are talking about Azure, we are going to act on permissions for groups and users. [Azure RBAC](https://docs.microsoft.com/azure/role-based-access-control/overview) in practice.
The consequence of this reaction often leads to friction that delays time to market during the development process due to the lack of rights needed to create new resources or manage existing ones.
These delays are dependent on the type of organization and find maximum expansion in companies organized by areas of competence.

The intent of this repository is to address resource and cost management through a combination of [policies](https://docs.microsoft.com/azure/governance/policy/overview) and [budgets](https://docs.microsoft.com/azure/cost-management-billing/cost-management-billing-overview).

## Resource organization through policy standardization.

All policies are defined within the [standards](./standards/) folder.

Everything defined within it is ready to be used. The rules are divided by purpose, and there is always an entry point `main.bicep` inside.

#### [Naming](./standards/naming).

This set contains the preset follows the [recommended abbreviations for Azure resource types](https://docs.microsoft.com/azure/cloud-adoption-framework/ready/azure-best-practices/resource-abbreviations) and will add missing ones as agreed upon in the [proposal](./standards/naming/PROPOSAL.md) document. Any contribution in the proposition of abbreviations is more than welcome.

#### [Tagging](./standards/tagging).

This set contains the preset follows the [minimum suggested tags](https://docs.microsoft.com/azure/cloud-adoption-framework/ready/azure-best-practices/resource-tagging#minimum-suggested-tags) and the [other common tagging examples](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-tagging#other-common-tagging-examples).

#### [Locating](./standards/locating).

This set contains the assignments to enforce that all resources are defined within the allowed locations.
