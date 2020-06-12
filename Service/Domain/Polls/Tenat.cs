using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Polls
{
    public class Tenant
    {
        public Guid TenantId { get; private set; }

        public Guid BuildingId { get; private set; }
    }
}
