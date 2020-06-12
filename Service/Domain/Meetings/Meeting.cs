using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Meetings
{
    public sealed class Meeting
    {
        public Guid MeetingId { get; private set; }

        public string Name { get; private set; }

        public Guid OwnerId { get; private set; }
    }
}