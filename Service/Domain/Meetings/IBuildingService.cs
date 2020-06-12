using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    public interface IBuildingService
    {
        Task SetMeetId(string meetId, Guid buildingId, CancellationToken cancellationToken);
        Task RemoveMeetId(Guid buildingId, CancellationToken cancellationToken);
    }
}
