using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Polls
{   
    public sealed class PollTenant
    {
        public PollTenant(Guid tenantId)
        {
            TenantId = tenantId;
        }

        public Guid PollTenantId { get; private set; }

        public Guid PollId { get; private set; }

        public Guid TenantId { get; private set; }
    }
}
