using Domain.Tenats;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Task<Building> Get(Guid buildingId, CancellationToken cancellationToken)
        {
            return context.Buildings
                .SingleOrDefaultAsync(b => b.BuildingId == buildingId, cancellationToken);
        }

        public Task<Building> Get(string address, CancellationToken cancellationToken)
        {
            return context.Buildings
                 .SingleOrDefaultAsync(b => b.Address == address, cancellationToken);
        }
    }
}
