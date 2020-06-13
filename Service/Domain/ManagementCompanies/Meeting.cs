using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ManagementCompanies
{
    public sealed class Meeting
    {
        public Guid MeetingId { get; private set; }

        public Guid OwnerId { get; private set; }
    }
}
