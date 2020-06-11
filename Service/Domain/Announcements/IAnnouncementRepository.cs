using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Announcements
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAnnouncementsByTenatId(Guid tenatId, CancellationToken cancellationToken);

        Task Save(Announcement announcement, CancellationToken cancellationToken);
    }
}
