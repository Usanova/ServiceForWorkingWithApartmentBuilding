using Domain.ManagementCompanies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.ManagementCompanies
{
    public interface IManagementCompanyRepository
    {
        Task<ManagementCompany> Get(Guid managementCompanyId, CancellationToken cancellationToken);

        Task<ManagementCompany> Get(string managementCompanyName, CancellationToken cancellationToken);

        Task<ManagementCompany> Get(string name, string password, CancellationToken cancellationToken);

        Task Save(ManagementCompany managementCompany);
    }
}
