using Domain.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Announcements.Query
{
    public sealed class GetListAnnouncement
    {
        private readonly IAnnouncementRepository repository;

        public GetListAnnouncement(IAnnouncementRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Page<AnnouncementReference>> Handler(Guid tenantId, int offset, int count, 
            CancellationToken cancellationToken)
        {
            var announcements = (await repository.GetAnnouncementsByTenatId(tenantId, offset, count, cancellationToken))
                .Select(a => new AnnouncementReference()
                {
                    Title = a.Title,
                    Content = a.Content
                })
                .ToList();

            return new Page<AnnouncementReference>
            {
                Count = announcements.Count,
                Offset = offset,
                Values = announcements
            };
        }
    }
}
