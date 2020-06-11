using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class PollTenant
    {
        public Guid PollId { get; private set; }

        public Guid TenantId { get; private set; }
    }
}
