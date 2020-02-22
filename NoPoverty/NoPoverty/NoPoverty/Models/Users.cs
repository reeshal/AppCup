using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    class Users
    {
        public String Username { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String Number { get; set; }
        public String Gender { get; set; }
        public String Password { get; set; }

        public Users(string username, string firstname, string lastname, string address, string email, string number, string gender, string password)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Email = email;
            Number = number;
            Gender = gender;
            Password = password;
        }

        //profile pic


    }
}
