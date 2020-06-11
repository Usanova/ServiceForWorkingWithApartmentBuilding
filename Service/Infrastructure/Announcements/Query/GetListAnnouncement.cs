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

        public async Task<IEnumerable<AnnouncementReference>> Handler(Guid tenatId, CancellationToken cancellationToken)
        {
            return (await repository.GetAnnouncementsByTenatId(tenatId, cancellationToken))
                .Select(a => new AnnouncementReference()
                {
                    Title = a.Title,
                    Content = a.Content
                });
        }
    }
}
