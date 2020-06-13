using Domain.ManagementCompanies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ManagementCompanies
{
    public sealed class MeetingService : IMeetingService
    {
        private readonly MeetingDbContext context;

        public MeetingService(MeetingDbContext context)
        {
            this.context = context;
        }

        public async Task<Meeting> Get(Guid ownerId, CancellationToken cancellationToken)
        {
            return await context.Meetings
                .SingleOrDefaultAsync(m => m.OwnerId == ownerId, cancellationToken);
        }
    }
}
