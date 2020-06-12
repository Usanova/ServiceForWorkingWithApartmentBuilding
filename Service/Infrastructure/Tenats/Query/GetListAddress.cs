using Domain.Tenats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Tenats.Query
{
    public sealed class GetListAddress
    {
        private readonly IBuildingService buildingService;

        public GetListAddress(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        public async Task<IEnumerable<AddressView>> Handler(CancellationToken cancellationToken)
        {
            return (await buildingService.GetAllAddresses(cancellationToken))
                .Select(address => new AddressView()
                {
                    Address = address
                });
        }
    }
}
