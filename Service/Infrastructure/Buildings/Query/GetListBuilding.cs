using Domain.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Buildings.Query
{
    public sealed class GetListBuilding
    {
        private readonly IBuildingRepository repository;

        public GetListBuilding(IBuildingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BuildingReference>> Handler(Guid managementCompanyId, CancellationToken cancellationToken)
        {
            return (await repository.GetBuildingsByManagementCompanyId(managementCompanyId, cancellationToken))
                .Select(b => new BuildingReference()
                {
                    BuildingId = b.BuildingId,
                    Address = b.Address
                });
        }
    }
}
