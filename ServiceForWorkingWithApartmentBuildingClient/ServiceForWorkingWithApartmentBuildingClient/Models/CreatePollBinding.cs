using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingClient.Models
{
    public sealed class CreatePollBinding
    {
        public string Question { get; set; }

        public Guid OwnerId { get; set; }

        public IEnumerable<string> Answers { get; set; }
    }
}
