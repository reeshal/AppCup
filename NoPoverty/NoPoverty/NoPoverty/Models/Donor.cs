using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoPoverty.Models
{
    public class Donor
    {
        public Guid DonorId { get; set; }
        public String Username { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String PhoneNo { get; set; }

        public String Password { get; set; }

        public static implicit operator Donor(Task<Donor> v)
        {
            throw new NotImplementedException();
        }
    }
}
