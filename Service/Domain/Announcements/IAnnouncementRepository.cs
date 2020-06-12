using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Announcements
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAnnouncementsByTenatId(Guid tenantId, CancellationToken cancellationToken);

        Task<IEnumerable<Announcement>> GetAnnouncementsByTenatId(Guid tenantId, int offset, int count, 
            CancellationToken cancellationToken);

        Task Save(Announcement announcement, CancellationToken cancellationToken);
    }
}
