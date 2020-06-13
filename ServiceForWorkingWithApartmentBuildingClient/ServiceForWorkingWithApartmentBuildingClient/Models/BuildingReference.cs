using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingClient.Models
{
    public sealed class BuildingReference
    {
        public Guid BuildingId { get; set; }

        public string Address { get; set; }
    }
}
