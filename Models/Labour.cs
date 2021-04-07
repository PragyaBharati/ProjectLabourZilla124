using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LabourZillaZoneee.Models
{
    public partial class Labour
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pswd { get; set; }
        public string Cnfrmpswd { get; set; }
        public string Profession { get; set; }
        public string CityAddress { get; set; }
        public string StateL { get; set; }
        public int? DailyWages { get; set; }
        public DateTime? TimeDate { get; set; }
        public string Available { get; set; }
        public string Lcontact { get; set; }
        public string Ppic { get; set; }
        [NotMapped]
        public IFormFile PPicFile { get; set; }
        public string RoleL { get; set; }
        
    }
}
