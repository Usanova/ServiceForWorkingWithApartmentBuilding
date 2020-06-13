using Domain.ManagementCompanies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ManagementCompanies.Query
{
    public sealed class GetManagementCompanyProfileView
    {
        private readonly IManagementCompanyRepository repository;

        public GetManagementCompanyProfileView(IManagementCompanyRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ManagementCompanyProfileView> Handler(string managementCompanyName, CancellationToken cancellationToken)
        {
            var managementCompany = await repository.Get(managementCompanyName, cancellationToken);

            return new ManagementCompanyProfileView()
            {
                Id = managementCompany.ManagementCompanyId,
                Name = managementCompany.Name,
                Info = managementCompany.Info,
                Avatar = managementCompany.Avatar
            };
        }
    }
}
