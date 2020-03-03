using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using NoPoverty.Models;

namespace NoPoverty.Helper
{
    class FirebaseHelper
    {
        private readonly string Child1 = "Books";
        private readonly string Child2 = "Stationery";
        readonly FirebaseClient firebase = new FirebaseClient("https://nopoverty-66859.firebaseio.com/");

        public async Task<List<Books>> GetAllBooks()
        {
            return (await firebase
                .Child(Child1)
                .OnceAsync<Books>()).Select(item => new Books
                {
                    BookId=item.Object.BookId,
                    Title = item.Object.Title,
                    Description = item.Object.Description,
                    Donator=item.Object.Donator,
                    Receiver = item.Object.Receiver,
                    PickupTime = item.Object.PickupTime,
                    ImageUrl=item.Object.ImageUrl,
                    Quantity = item.Object.Quantity
                }).ToList();
        }
        /*
        public async Task<List<Books>> GetBooksByUser(Users current)
        {
            string currentDonator = current.Username;
            return (await firebase
                .Child(Child1)
                .OnceAsync<Books>()).Where(a => a.Object.Donator == currentDonator).FirstOrDefault().Select(item => new Books
                {
                    BookId = item.Object.BookId,
                    Title = item.Object.Title,
                    Description = item.Object.Description,
                    Donator = item.Object.Donator,
                    Receiver = item.Object.Receiver,
                    PickupTime = item.Object.PickupTime,
                    ImageUrl = item.Object.ImageUrl,
                    Quantity = item.Object.Quantity
                }).ToList();
        }*/
        public async Task<List<Stationery>> GetAllStationery()
        {
            return (await firebase
                .Child(Child2)
                .OnceAsync<Stationery>()).Select(item => new Stationery
                {
                    StationeryId = item.Object.StationeryId,
                    Title = item.Object.Title,
                    Description = item.Object.Description,
                    Donator = item.Object.Donator,
                    Receiver = item.Object.Receiver,
                    PickupTime = item.Object.PickupTime,
                    Quantity=item.Object.Quantity,
                    ImageUrl = item.Object.ImageUrl
                }).ToList();
        }

        //receriver is not added . it is updated later on when a request got it
        public async Task AddBook(string Title, string Description, string PickupTime, string Donator, string ImageUrl, string Qty)
        {
            await firebase
                .Child(Child1)
                .PostAsync(new Books() { BookId = Guid.NewGuid(), Title = Title, Description = Description, Quantity = Qty,Donator = Donator, Receiver="", PickupTime=PickupTime, ImageUrl="" });
        }
        public async Task AddStationery(string Title, string Description, string PickupTime, string Donator, string ImageUrl, string Qty)
        {
            await firebase
                .Child(Child2)
                .PostAsync(new Stationery() { StationeryId = Guid.NewGuid(), Title = Title, Description = Description, Quantity=Qty, Donator = Donator, Receiver = "", PickupTime = PickupTime, ImageUrl = "" });
        }


        public async Task<Books> GetBookById(Guid bookId)
        {
            var allBooks = await GetAllBooks();
            await firebase
                .Child(Child1)
                .OnceAsync<Books>();
            return allBooks.FirstOrDefault(a => a.BookId == bookId);
        }
        /*
        public async Task UpdateBook(Guid bookId, string receiver)
        {
            var toUpdatePerson = (await firebase
                .Child(Child1)
                .OnceAsync<Books>()).FirstOrDefault(a => a.Object.BookId == bookId);

            await firebase
                .Child(Child1)
                .Child(toUpdatePerson.Key)
                .PutAsync(new Books() { PersonId = personId, Name = name, Phone = phone });
        }*/

        public async Task DeleteBook(Guid bookId)
        {
            var toDeleteBook = (await firebase
              .Child(Child1)
              .OnceAsync<Books>()).Where(a => a.Object.BookId == bookId).FirstOrDefault();
            await firebase.Child(Child1).Child(toDeleteBook.Key).DeleteAsync();

        }
        public async Task DeleteStationery(Guid stationeryId)
        {
            var toDeleteStat = (await firebase
              .Child(Child2)
              .OnceAsync<Stationery>()).Where(a => a.Object.StationeryId == stationeryId).FirstOrDefault();
            await firebase.Child(Child1).Child(toDeleteStat.Key).DeleteAsync();

        }
    }
}
