using Domain.ManagementCompanies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ManagementCompanies
{
    public sealed class ManagementCompanyRepository : IManagementCompanyRepository
    {
        private readonly ManagementCompanyDbContext context;

        public ManagementCompanyRepository(ManagementCompanyDbContext context)
        {
            this.context = context;
        }

        public async Task<ManagementCompany> Get(Guid managementCompanyId, CancellationToken cancellationToken)
        {
            return await context.ManagementCompanies
                .SingleOrDefaultAsync(m => m.ManagementCompanyId == managementCompanyId, cancellationToken);
        }

        public async Task<ManagementCompany> Get(string managementCompanyName, CancellationToken cancellationToken)
        {
            return await context.ManagementCompanies
                .SingleOrDefaultAsync(m => m.Name == managementCompanyName, cancellationToken);
        }

        public async Task<ManagementCompany> Get(string name, string password, CancellationToken cancellationToken)
        {
            return await context.ManagementCompanies
                 .SingleOrDefaultAsync(m => m.Name == name && m.Password == password, cancellationToken);
        }

        public async Task Save(ManagementCompany managementCompany)
        {
            if (context.Entry(managementCompany).State == EntityState.Detached)
                context.ManagementCompanies.Add(managementCompany);

            await context.SaveChangesAsync();
        }
    }
}
