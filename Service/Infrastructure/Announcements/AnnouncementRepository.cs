using Domain.Announcements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Announcements
{
    public sealed class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly AnnouncementDbContext context;

        public AnnouncementRepository(AnnouncementDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsByTenatId(Guid tenantId, CancellationToken cancellationToken)
        {
            var announcementTenants = context.AnnouncementTenant
                .Where(at => at.TenantId == tenantId)
                .Select(at => at.AnnouncementId);

            return await context.Announcements
                .Where(a => announcementTenants.Contains(a.AnnouncementId))
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsByTenatId(Guid tenantId, int offset, int count, 
            CancellationToken cancellationToken)
        {
            var announcementTenants = context.AnnouncementTenant
                 .Where(at => at.TenantId == tenantId)
                 .Select(at => at.AnnouncementId);

            return await context.Announcements
                .Where(a => announcementTenants.Contains(a.AnnouncementId))
                .OrderByDescending(a => a.CreateDate)
                .Skip(offset)
                .Take(count)
                .ToListAsync(cancellationToken);
        }

        public async Task Save(Announcement announcement, CancellationToken cancellationToken)
        {
            if (context.Entry(announcement).State == EntityState.Detached)
                context.Announcements.Add(announcement);

            await context.SaveChangesAsync();
        }
    }
}
