using Domain.Tenats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Tenats.Query
{
    public sealed class GetProfileView
    {
        private readonly ITenantRepository repository;
        private readonly IBuildingService buildingService;

        public GetProfileView(ITenantRepository repository, IBuildingService buildingService)
        {
            this.repository = repository;
            this.buildingService = buildingService;
        }

        public async Task<ProfileView> Handler(string name, string password, CancellationToken cancellationToken)
        {
            var tenant = await repository.Get(name, password, cancellationToken);

            var building = await buildingService.Get(tenant.BuildingId, cancellationToken);

            return new ProfileView()
            {
                Id = tenant.TenantId,
                Name = tenant.Name,
                Address = building.Address,
                EntranceNumber = tenant.EntranceNumber,
                FlatNumber = tenant.FlatNumber,
                Avatar = tenant.Avatar,
                NameManagmentCompany = await buildingService.GetNameOfManagmantCompany(building, cancellationToken),
                HasMeeting = building.MeetId
            };
        }
    }
}
