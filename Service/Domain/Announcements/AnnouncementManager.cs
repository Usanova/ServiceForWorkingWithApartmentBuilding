using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Announcements
{
    public sealed class AnnouncementManager
    {
        private readonly IAnnouncementRepository repository;
        private readonly ITenantService tenantService;

        public AnnouncementManager(IAnnouncementRepository repository, ITenantService tenantService)
        {
            this.repository = repository;
            this.tenantService = tenantService;
        }

        public async Task CreateByBuilding(string title, string content, Guid buildingId, CancellationToken cancellationToken)
        {
            var announcement = new Announcement(title, content);

            var tenants = await tenantService.GetTenantsByBuilding(buildingId, cancellationToken);

            foreach(var tenant in tenants)
            {
                announcement.AddTenant(tenant.TenantId);
            }

            await repository.Save(announcement, cancellationToken);
        }
    }
}
