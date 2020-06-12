using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Meetings
{
    public sealed class Building
    {
        public Guid BuildingId { get; private set; }
        public string MeetId { get; private set; }

        public void UpdateMeetId(string meetId)
        {
            MeetId = meetId;
        }
    }
}
