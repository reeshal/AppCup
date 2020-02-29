using NoPoverty.Helper;
using NoPoverty.Models;
using NoPoverty.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{

    public partial class BooksList : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public BooksList()
        {
            InitializeComponent();
            
        }
        private async Task FetchAllBooks()
        {
            var allBooks = await firebaseHelper.GetAllBooks();

            ListOfBooks.ItemsSource = allBooks;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await FetchAllBooks();
        }

    }
}