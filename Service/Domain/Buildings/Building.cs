using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Buildings
{
    public sealed class Building
    {
        public Building(Guid managementCompanyId, string address)
        {
            BuildingId = Guid.NewGuid();
            ManagementCompanyId = managementCompanyId;
            Address = address;
        }

        public Guid BuildingId { get; private set; }

        public string Address { get; private set; }

        public Guid ManagementCompanyId { get; private set; }

        public string MeetId { get; private set; }
    }
}
