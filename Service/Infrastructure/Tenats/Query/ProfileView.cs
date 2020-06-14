using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Tenats.Query
{
    public sealed class ProfileView
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public int EntranceNumber { get; set; }

        public int FlatNumber { get; set; }

        public string NameManagmentCompany { get; set; }

        public string HasMeeting { get; set; }

        public byte[] Avatar { get; set; }
    }
}
