using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Tenats
{
    interface IMeetingRepository
    {
        Task Get(Guid MeetingId, CancellationToken cancellationToken);
        Task Save(Meeting meeting, CancellationToken cancellationToken);
    }
}