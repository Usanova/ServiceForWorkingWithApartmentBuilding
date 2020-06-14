using Domain.Tenats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Tenats.Query
{
    public sealed class GetProfileViewById
    {
        private readonly ITenantRepository repository;
        private readonly IBuildingService buildingService;

        public GetProfileViewById(ITenantRepository repository, IBuildingService buildingService)
        {
            this.repository = repository;
            this.buildingService = buildingService;
        }

        public async Task<ProfileView> Handler(Guid tenatId, CancellationToken cancellationToken)
        {
            var tenant = await repository.Get(tenatId, cancellationToken);

            var building = await buildingService.Get(tenant.BuildingId, cancellationToken);

            return new ProfileView()
            {
                Id = tenant.TenantId,
                Name = tenant.Name,
                Surname = tenant.Surname,
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
