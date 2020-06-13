using Domain.Buildings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Buildings
{
    public sealed class BuildingRepository : IBuildingRepository
    {
        private readonly BuildingDbContext context;
        public BuildingRepository(BuildingDbContext context)
        {
            this.context = context;
        }

        public async Task<Building> Get(string address, Guid managementCompanyId, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .SingleOrDefaultAsync(b => b.Address == address && b.ManagementCompanyId == managementCompanyId, cancellationToken);
        }

        public async Task<Building> Get(string address, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .SingleOrDefaultAsync(b => b.Address == address, cancellationToken);
        }

        public async Task<IEnumerable<Building>> GetBuildingsByManagementCompanyId(Guid managementCompanyId, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .Where(at => at.ManagementCompanyId == managementCompanyId)
                .ToListAsync(cancellationToken);
        }

        public async Task Save(Building building, CancellationToken cancellationToken)
        {
            if (context.Entry(building).State == EntityState.Detached)
                context.Buildings.Add(building);

            await context.SaveChangesAsync();
        }
    }
}
