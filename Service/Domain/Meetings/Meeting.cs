using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Meetings
{
    public sealed class Meeting
    {
        public Meeting(string name, Guid ownerId)
        {
            MeetingId = Guid.NewGuid();
            Name = name;
            OwnerId = ownerId;
        }

        public Guid MeetingId { get; private set; }

        public string Name { get; private set; }

        public Guid OwnerId { get; private set; }

        public Guid GetId() => MeetingId;

        public void Close()
        {
            OwnerId = Guid.NewGuid();
        }
    }
}