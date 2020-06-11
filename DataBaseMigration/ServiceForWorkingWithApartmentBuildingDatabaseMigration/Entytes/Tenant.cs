using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class Tenant
    {
        public Guid TenatId { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Password { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public Guid BuildingId { get; private set; }

        public int EntranceNumber { get; private set; }

        public int FlatNumber { get; private set; }

        public byte[] Avatar { get; set; }
    }
}
