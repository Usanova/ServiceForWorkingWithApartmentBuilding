using Domain.Tenats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Tenats
{
    public sealed class BuildingService : IBuildingService
    {
        private readonly BuildingDbContext context;

        public BuildingService(BuildingDbContext context)
        {
            this.context = context;
        }

        public async Task<Building> Get(Guid buildingId, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .SingleOrDefaultAsync(b => b.BuildingId == buildingId, cancellationToken);
        }

        public async Task<Building> Get(string address, CancellationToken cancellationToken)
        {
            return await context.Buildings
                 .SingleOrDefaultAsync(b => b.Address == address, cancellationToken);
        }

        public async Task<IEnumerable<string>> GetAllAddresses(CancellationToken cancellationToken)
        {
            return await context.Buildings
                .Select(b => b.Address)
                .Distinct()
                .ToListAsync();
        }

        public async Task<string> GetNameOfManagmantCompany(Building building, CancellationToken cancellationToken)
        {
            return (await context.ManagementCompanies
                 .SingleOrDefaultAsync(mc => mc.ManagementCompanyId == building.ManagementCompanyId,
                 cancellationToken)).Name;
        }
    }
}
