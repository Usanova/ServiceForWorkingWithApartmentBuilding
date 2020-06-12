using System;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class PollTenant
    {
        public Guid PollTenantId { get; private set; }

        public Guid PollId { get; private set; }

        public Guid TenantId { get; private set; }
    }
}
