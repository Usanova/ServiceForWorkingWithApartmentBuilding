using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    interface IMeetingRepository
    {
        Task Save(Meeting meeting, CancellationToken cancellationToken);
    }
}
