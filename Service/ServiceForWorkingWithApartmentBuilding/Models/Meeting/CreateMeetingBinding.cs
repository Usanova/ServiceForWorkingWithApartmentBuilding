using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Models.Meeting
{
    public class CreateMeetingBinding
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
