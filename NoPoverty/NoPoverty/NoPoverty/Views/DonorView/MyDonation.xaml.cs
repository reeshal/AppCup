using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Helper;
using NoPoverty.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NoPoverty.Views.DonorView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDonation : ContentPage
    {

        readonly FirebaseFood firebaseHelper = new FirebaseFood();
        public MyDonation()
        {
            InitializeComponent();
        }

        private async Task FetchAllMeals()
        {
            //var allBooks = await firebaseHelper.GetMealsByDonor(Global.currentRep.Username);
            //var allBooks = await firebaseHelper.GetAllMeal();

            //ListOfMeals.ItemsSource = allBooks;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await FetchAllMeals();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var meal = args.SelectedItem as Meal;
            if (meal == null)
                return;

            await Navigation.PushAsync(new MealDetails(meal));

            // Manually deselect item.
            ListOfMeals.SelectedItem = null;
        }
    }
}