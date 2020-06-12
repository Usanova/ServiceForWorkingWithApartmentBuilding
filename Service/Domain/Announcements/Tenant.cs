using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Announcements
{
    public class Tenant
    {
        public Guid TenantId { get; set; }

        public Guid BuildingId { get; set; }
    }
}
