using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Tenats
{
    public interface ITenantRepository
    {
        Task<Tenant> Get(Guid tenatId, CancellationToken cancellationToken);

        Task<Tenant> Get(string name, string surname, CancellationToken cancellationToken);

        Task<Tenant> Get(string name, string surname, string password, CancellationToken cancellationToken);

        Task Save(Tenant tenat);

        Task Delete(Tenant tenat);
    }
}
