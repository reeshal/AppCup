using Firebase.Database;
using Firebase.Database.Query;
using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPoverty.Helper
{
    public class FirebaseUsers
    {
        private readonly string Child1 = "Donor";
        private readonly string Child2 = "Institution";

        readonly FirebaseClient firebase = new FirebaseClient("https://nopoverty-66859.firebaseio.com/");
        public async Task<List<Donor>> GetAllDonors()
        {
            return (await firebase
                .Child(Child1)
                .OnceAsync<Donor>()).Select(item => new Donor
                {
                    Username = item.Object.Username,
                    DonorId = item.Object.DonorId,
                    Firstname = item.Object.Firstname,
                    Lastname = item.Object.Lastname,
                    Address = item.Object.Address,
                    Email = item.Object.Email,
                    PhoneNo = item.Object.PhoneNo,
                    Password = item.Object.Password
                }).ToList();
        }
        public async Task<List<Institution>> GetAllRepresentatives()
        {
            return (await firebase
                .Child(Child2)
                .OnceAsync<Institution>()).Select(item => new Institution
                {
                    Username = item.Object.Username,
                    RepresentativeId = item.Object.RepresentativeId,
                    Firstname = item.Object.Firstname,
                    Lastname = item.Object.Lastname,
                    Address = item.Object.Address,
                    Email = item.Object.Email,
                    PhoneNo = item.Object.PhoneNo,
                    Password = item.Object.Password,
                    InstitutionName= item.Object.InstitutionName,
                    DietaryRequirements=item.Object.DietaryRequirements

                }).ToList();
        }

        public async Task AddDonor(string username, string firstname, string lastname, string address, string email, string phoneno, string gender, string password)
        {
            await firebase
                .Child(Child1)
                .PostAsync(new Donor() { DonorId = Guid.NewGuid(), Username = username, Firstname = firstname, Lastname = lastname, Address = address, Email = email, PhoneNo = phoneno, Gender = gender, Password = password });
        }
        public async Task AddRepresentative(string username, string firstname, string lastname, string address, string email, string phoneno, string gender, string password, string institutionName, string dietaryReq)
        {
            await firebase
                .Child(Child2)
                .PostAsync(new Institution() { RepresentativeId = Guid.NewGuid(), Username = username, Firstname = firstname, Lastname = lastname, Address = address, Email = email, PhoneNo = phoneno, Gender = gender, Password = password, InstitutionName=institutionName, DietaryRequirements=dietaryReq});
        }

        public async Task<Donor> GetDonor(string username)
        {
            var allDonor = await GetAllDonors();
            await firebase
                .Child(Child1)
                .OnceAsync<Donor>();
            return allDonor.FirstOrDefault(a => a.Username == username);
        }

        public async Task<Institution> GetRepresentative(string username)
        {
            var allRep = await GetAllRepresentatives();
            await firebase
                .Child(Child2)
                .OnceAsync<Institution>();
            return allRep.FirstOrDefault(a => a.Username == username);
        }
    }
}
