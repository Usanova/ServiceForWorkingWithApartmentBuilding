using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tenats
{
    public sealed class Meeting
    {
        public Guid MeetingId { get; private set; }

        public string Name { get; private set; }

        public Guid OwnerId { get; private set; }
    }
}
