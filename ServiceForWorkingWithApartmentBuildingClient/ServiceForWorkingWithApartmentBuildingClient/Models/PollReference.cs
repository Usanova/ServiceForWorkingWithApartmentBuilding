using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingClient.Models
{
    public sealed class PollReference
    {
        public Guid PollId { get; set; }

        public string Question { get; set; }
    }
}
