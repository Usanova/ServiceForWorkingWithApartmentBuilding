using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingClient.Models
{
    public class CreateMeetingBinding
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
