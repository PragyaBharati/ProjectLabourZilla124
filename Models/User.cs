using System;
using System.Collections.Generic;

#nullable disable

namespace LabourZillaZoneee.Models
{
    public partial class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityAddress { get; set; }
        public string StateC { get; set; }
        public string Lcontact { get; set; }
        public string PasswordC { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleU { get; set; }
    }
}
