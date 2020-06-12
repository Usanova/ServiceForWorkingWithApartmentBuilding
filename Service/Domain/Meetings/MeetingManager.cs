using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    public sealed class MeetingManager
    {
        private readonly IMeetingRepository meetingRepository;

        private readonly IBuildingService buildingService;

        public MeetingManager(IMeetingRepository meetingRepository, IBuildingService buildingService)
        {
            this.meetingRepository = meetingRepository;
            this.buildingService = buildingService;
        }

        public async Task OpenForBuilding(string name, Guid ownerId, Guid buildingId, CancellationToken cancellationToken)
        {
            var meeting = new Meeting(name, ownerId);

            await buildingService.SetMeetId(meeting.GetId().ToString(), buildingId, cancellationToken);

            await meetingRepository.Save(meeting, cancellationToken);
        }

        public async Task Close(Guid meetingId, CancellationToken cancellationToken)
        {
            await buildingService.RemoveMeetId(meetingId, cancellationToken);
        }
    }
}
