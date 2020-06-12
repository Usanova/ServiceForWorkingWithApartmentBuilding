using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Tenats
{
    public interface ITenantRepository
    {
        Task<Tenant> Get(Guid tenantId, CancellationToken cancellationToken);

        Task<Tenant> Get(string name, string password, CancellationToken cancellationToken);

        Task<Tenant> Get(string name, string surname, string password, CancellationToken cancellationToken);

        Task Save(Tenant tenant);

        Task Delete(Tenant tenant);
    }
}
