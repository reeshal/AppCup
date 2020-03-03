﻿using Firebase.Database;
using Firebase.Database.Query;
using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPoverty.Services
{
    public class FirebaseService
    {
        private readonly string ChildName = "Users";

        readonly FirebaseClient firebase = new FirebaseClient("https://nopoverty-66859.firebaseio.com/");

        private async Task<List<Users>> GetAllUsers()
        {
            return (await firebase
                .Child(ChildName)
                .OnceAsync<Users>()).Select(item => new Users
                {
                    Username = item.Object.Username,
                    UserId = item.Object.UserId,
                    Firstname = item.Object.Firstname,
                    Lastname = item.Object.Lastname,
                    Address = item.Object.Address,
                    Email = item.Object.Email,
                    PhoneNo = item.Object.PhoneNo,
                    Number = item.Object.Number,
                    Gender = item.Object.Gender,
                    Password = item.Object.Password
                }).ToList();
        }

        public async Task AddUsers(string username, string firstname, string lastname, string address, string email, string phoneno, string number, string gender, string password)
        {
            await firebase
                .Child(ChildName)
                .PostAsync(new Users() { UserId = Guid.NewGuid(), Username = username, Firstname = firstname, Lastname = lastname, Address = address, Email = email, PhoneNo = phoneno, Number = number, Gender = gender, Password = password });
        }

        private async Task<Users> GetUsers(Guid UsersId)
        {
            var allUsers = await GetAllUsers();
            await firebase
                .Child(ChildName)
                .OnceAsync<Users>();
            return allUsers.FirstOrDefault(a => a.UserId == UsersId);
        }

        private async Task<Users> GetUsers(string username)
        {
            var allUsers = await GetAllUsers();
            await firebase
                .Child(ChildName)
                .OnceAsync<Users>();
            return allUsers.FirstOrDefault(a => a.Username == username);
        }

        public async Task UpdateUsers(Guid UsersId, string username, string firstname, string lastname, string address, string email, string phoneno, string number, string gender, string password)
        {
            var toUpdateUsers = (await firebase
                .Child(ChildName)
                .OnceAsync<Users>()).FirstOrDefault(a => a.Object.UserId == UsersId);

            await firebase
                .Child(ChildName)
                .Child(toUpdateUsers.Key)
                .PutAsync(new Users() { UserId = UsersId, Username = username, Firstname = firstname, Lastname = lastname, Address = address, Email = email, PhoneNo = phoneno, Number = number, Gender = gender, Password = password });
        }

        public async Task DeleteUsers(Guid UsersId)
        {
            var toDeleteUsers = (await firebase
                .Child(ChildName)
                .OnceAsync<Users>()).FirstOrDefault(a => a.Object.UserId == UsersId);
            await firebase.Child(ChildName).Child(toDeleteUsers.Key).DeleteAsync();
        }
    }
}
