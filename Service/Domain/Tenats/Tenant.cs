using System;

namespace Domain.Tenats
{
    public sealed class Tenant
    {
        public Tenant(string name, 
            string surname, 
            string password, 
            DateTime dateOfBirth, 
            Guid buildingId, 
            int entranceNumber, 
            int flatNumber)
        {
            TenantId = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Password = password;
            DateOfBirth = dateOfBirth;
            BuildingId = buildingId;
            EntranceNumber = entranceNumber;
            FlatNumber = flatNumber;
        }
        
        public void PutAvatar(byte[] avatar)
        {
            Avatar = avatar;
        }

        public Guid TenantId { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Password { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public Guid BuildingId { get; private set; }

        public int EntranceNumber { get; private set; }

        public int FlatNumber { get; private set; }

        public byte[] Avatar { get; set; }
    }
}
