using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Helper;
using NoPoverty.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StationeryList : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public StationeryList()
        {
            InitializeComponent();
        }
        private async Task FetchAllStationery()
        {
            var allStat = await firebaseHelper.GetAllStationery();

            ListOfStationery.ItemsSource = allStat;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await FetchAllStationery();
        }
    }
}