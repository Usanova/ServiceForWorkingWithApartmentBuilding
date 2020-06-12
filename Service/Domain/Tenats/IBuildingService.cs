using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Tenats
{
    public interface IBuildingService
    {
        Task<Building> Get(Guid buildingId, CancellationToken cancellationToken);

        Task<Building> Get(string address, CancellationToken cancellationToken);

        Task<IEnumerable<string>> GetAllAddresses(CancellationToken cancellationToken);

        Task<string> GetNameOfManagmantCompany(Building building, CancellationToken cancellationToken);
    }
}
