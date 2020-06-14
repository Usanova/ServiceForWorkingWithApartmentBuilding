using Domain.Tenats;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Tenats.Query
{
    public sealed class GetProfileViewByName
    {
        private readonly ITenantRepository repository;
        private readonly IBuildingService buildingService;

        public GetProfileViewByName(ITenantRepository repository, IBuildingService buildingService)
        {
            this.repository = repository;
            this.buildingService = buildingService;
        }

        public async Task<ProfileView> Handler(string name, string surname, string password, CancellationToken cancellationToken)
        {
            var tenant = await repository.Get(name, surname, password, cancellationToken);

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
