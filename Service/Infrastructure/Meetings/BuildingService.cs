using Domain.Meetings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Meetings
{
    public sealed class BuildingService : IBuildingService
    {
        private readonly BuildingDbContext context;

        public BuildingService(BuildingDbContext context)
        {
            this.context = context;
        }

        public async Task SetMeetId(string meetId, Guid buildingId, CancellationToken cancellationToken)
        {
            var building = await context.Buildings
                .SingleOrDefaultAsync(b => b.BuildingId == buildingId);

            building.UpdateMeetId(meetId);

            context.SaveChanges();
        }

        public async Task RemoveMeetId(Guid meetingId, CancellationToken cancellationToken)
        {
            var building = await context.Buildings
                .SingleOrDefaultAsync(b => b.MeetId == meetingId.ToString());

            building.UpdateMeetId(null);

            context.SaveChanges();
        }

    }
}
