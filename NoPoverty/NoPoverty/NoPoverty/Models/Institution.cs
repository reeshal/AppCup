using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public class Institution
    {
        public Guid RepresentativeId { get; set; }
        public String Username { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String PhoneNo { get; set; }
        public String Gender { get; set; }
        public String Password { get; set; }
        public String InstitutionName { get; set; }
        public String DietaryRequirements { get; set; }
        public String InstitutionDetails { get; set; }

        //foto certificate
    }
}
