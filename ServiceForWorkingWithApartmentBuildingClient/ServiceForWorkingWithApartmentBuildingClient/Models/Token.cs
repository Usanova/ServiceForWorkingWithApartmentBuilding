using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingClient.Models
{
    public sealed class Token
    {
        public string access_token { get; set; }

        public string username { get; set; }
    }
}
