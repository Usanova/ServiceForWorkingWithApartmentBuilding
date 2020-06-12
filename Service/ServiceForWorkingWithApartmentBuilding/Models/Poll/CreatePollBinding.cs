using System;
using System.Collections.Generic;

namespace ServiceForWorkingWithApartmentBuilding.Models.Poll
{
    public sealed class CreatePollBinding
    {
        public string Question { get; set; }

        public Guid OwnerId { get; set; }

        public IEnumerable<string> Answers { get; set; }
    }
}
