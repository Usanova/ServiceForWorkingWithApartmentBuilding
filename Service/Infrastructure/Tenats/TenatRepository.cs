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

        public async Task<Tenant> Get(Guid tenetId, CancellationToken cancellationToken)
        {
            return await context.Tenants
                .SingleOrDefaultAsync(t => t.TenatId == tenetId);
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

        public async Task Save(Tenant tenat)
        {
            if (context.Entry(tenat).State == EntityState.Detached)
                context.Tenants.Add(tenat);

            await context.SaveChangesAsync();
        }

        public async Task Delete(Tenant tenat)
        {
            context.Tenants.Remove(tenat);

            await context.SaveChangesAsync();
        }
    }
}
