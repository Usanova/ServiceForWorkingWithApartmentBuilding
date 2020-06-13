using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    public sealed class MeetingManager
    {
        private readonly IMeetingRepository repository;

        private readonly IBuildingService buildingService;

        public MeetingManager(IMeetingRepository meetingRepository, IBuildingService buildingService)
        {
            this.repository = meetingRepository;
            this.buildingService = buildingService;
        }

        public async Task<Guid> OpenForBuilding(string name, Guid ownerId, Guid buildingId, CancellationToken cancellationToken)
        {
            var meeting = new Meeting(name, ownerId);

            await buildingService.SetMeetId(meeting.GetId().ToString(), buildingId, cancellationToken);

            await repository.Save(meeting, cancellationToken);

            return meeting.MeetingId;
        }

        public async Task Close(Guid meetingId, CancellationToken cancellationToken)
        {
            var meeting = await repository.Get(meetingId, cancellationToken);
            meeting.Close();

            await repository.Save(meeting, cancellationToken);

            await buildingService.RemoveMeetId(meetingId, cancellationToken);
        }
    }
}
