using Domain.Meetings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Meetings
{
    public sealed class MeetingRepository : IMeetingRepository
    {
        private readonly MeetingDbContext context;

        public MeetingRepository(MeetingDbContext context)
        {
            this.context = context;
        }

        public async Task<Meeting> Get(Guid meetingId, CancellationToken cancellationToken)
        {
            return await context.Meetings
                .SingleOrDefaultAsync(m => m.MeetingId == meetingId);
        }

        public async Task Save(Meeting meeting, CancellationToken cancellationToken)
        {
            if (context.Entry(meeting).State == EntityState.Detached)
                context.Meetings.Add(meeting);

            await context.SaveChangesAsync();
        }
    }
}
