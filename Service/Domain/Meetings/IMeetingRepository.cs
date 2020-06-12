using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    public interface IMeetingRepository
    {
        Task<Meeting> Get(Guid MeetingId, CancellationToken cancellationToken);
        Task Save(Meeting meeting, CancellationToken cancellationToken);

        
    }
}