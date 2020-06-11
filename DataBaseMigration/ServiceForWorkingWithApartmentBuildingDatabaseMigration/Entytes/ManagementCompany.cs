using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class ManagementCompany
    {
        public Guid ManagementCompanyId { get; private set; }

        public string Name { get; private set; }

        public ICollection<Building> Buildings { get; private set; }
    }
}
