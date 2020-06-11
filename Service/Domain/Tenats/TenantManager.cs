using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Tenats
{
    public sealed class TenantManager
    {
        private readonly ITenantRepository repository;
        private readonly IBuildingService buildingService;

        public TenantManager(ITenantRepository repository, 
            IBuildingService buildingService)
        {
            this.repository = repository;
            this.buildingService = buildingService;
        }

        public async Task<Tenant> Create(string name,
            string surname,
            string paaword,
            DateTime dateOfBirth,
            string address,
            int entranceNumber,
            int flatNumber,
            CancellationToken cancellationToken)
        {
            var building = await buildingService.Get(address, cancellationToken);

            if (building == null)
                throw new BuildingWithSuchAddressNotRegisteredException(address);

            return new Tenant(name,
                surname,
                paaword,
                dateOfBirth,
                building.BuildingId,
                entranceNumber,
                flatNumber);
        }
    }

    public sealed class BuildingWithSuchAddressNotRegisteredException : Exception
    {
        public BuildingWithSuchAddressNotRegisteredException(string address) 
            : base($"Buildeng with address {address} not found") { }
    }
}
