using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Announcements
{
    public sealed class Announcement
    {
        public Announcement(string title, string content)
        {
            AnnouncementId = Guid.NewGuid();
            Title = title;
            Content = content;
            CreateDate = DateTime.UtcNow;
            AnnouncementTenant_ = new List<AnnouncementTenant>();
        }

        public Guid AnnouncementId { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public DateTime CreateDate { get; private set; }

        List<AnnouncementTenant> AnnouncementTenant_ { get; set; }

        public ICollection<AnnouncementTenant> AnnouncementTenant => AnnouncementTenant_;

        public void AddTenant(Guid tenantId)
        {
            AnnouncementTenant_.Add(new AnnouncementTenant(tenantId));
        }
    }
}
