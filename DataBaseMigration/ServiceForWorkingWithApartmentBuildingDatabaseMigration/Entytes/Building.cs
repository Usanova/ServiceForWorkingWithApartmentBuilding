using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class Building
    {
        public Guid BuildingId { get; private set; }

        public string Address { get; private set; }

        public Guid ManagementCompanyId { get; private set; }
    }
}
