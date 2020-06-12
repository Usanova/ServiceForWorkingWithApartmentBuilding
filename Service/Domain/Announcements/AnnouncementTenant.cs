using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Announcements
{
    public sealed class AnnouncementTenant
    {
        public AnnouncementTenant(Guid tenantId)
        {
            AnnouncementTenantId = Guid.NewGuid();
            TenantId = tenantId;
        }

        public Guid AnnouncementTenantId { get; private set; }

        public Guid AnnouncementId { get; private set; }

        public Guid TenantId { get; private set; }
    }
}
