using System;

namespace Domain.Tenats
{
    public sealed class Building
    {
        public Guid BuildingId { get; private set; }

        public string Address { get; private set; }

        public Guid ManagementCompanyId { get; private set; }

        public string MeetId { get; private set; }
    }
}
