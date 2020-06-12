using Domain.Tenats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Tenats
{
    public sealed class TenantRepository : ITenantRepository
    {
        private readonly TenantDbContext context;

        public TenantRepository(TenantDbContext context)
        {
            this.context = context;
        }

        public async Task<Tenant> Get(Guid tenantId, CancellationToken cancellationToken)
        {
            return await context.Tenants
                .SingleOrDefaultAsync(t => t.TenantId == tenantId);
        }

        public async Task<Tenant> Get(string name, string password, CancellationToken cancellationToken)
        {
            return await context.Tenants
                 .FirstOrDefaultAsync(t => t.Name == name && t.Password == password);
        }

        public async Task<Tenant> Get(string name, string surname, string password, CancellationToken cancellationToken)
        {
            return await context.Tenants
                 .SingleOrDefaultAsync(t => t.Name == name && t.Surname == surname && t.Password == password);
        }

        public async Task Save(Tenant tenant)
        {
            if (context.Entry(tenant).State == EntityState.Detached)
                context.Tenants.Add(tenant);

            await context.SaveChangesAsync();
        }

        public async Task Delete(Tenant tenant)
        {
            context.Tenants.Remove(tenant);

            await context.SaveChangesAsync();
        }
    }
}
