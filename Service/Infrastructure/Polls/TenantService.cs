using Domain.Polls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Polls
{
    public sealed class TenantService : ITenantService
    {
        private readonly TenantDbContext context;

        public TenantService(TenantDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Tenant>> GetTenantsByBuilding(Guid buildingId, CancellationToken cancellationToken)
        {
            return await context.Tenants
                .Where(t => t.BuildingId == buildingId)
                .ToListAsync(cancellationToken);
        }
    }
}
