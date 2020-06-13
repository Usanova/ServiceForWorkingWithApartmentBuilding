using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Buildings
{
    public interface IBuildingRepository
    {
        Task<Building> Get(string address, Guid managementCompanyId, CancellationToken cancellationToken);

        Task<Building> Get(string address, CancellationToken cancellationToken);

        Task<IEnumerable<Building>> GetBuildingsByManagementCompanyId(Guid managementCompanyId, CancellationToken cancellationToken);

        Task Save(Building building, CancellationToken cancellationToken);
    }
}
