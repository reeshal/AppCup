using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Helper;
using NoPoverty.Models;
using NoPoverty.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealsList : ContentPage
    {
        readonly FirebaseFood firebaseHelper = new FirebaseFood();

        public MealsList()
        {
            InitializeComponent();
        }
        private async Task FetchAllMeals()
        {
            var allmeals = await firebaseHelper.GetAllMeal();
            //var allBooks = await firebaseHelper.GetAllMeal();
            //ListView sortedmeals = new ListView { ItemsSource = allmeals.Where(w => w.InstitutionName.Contains(Global.currentRep.InstitutionName)) };
            ListOfMeals.ItemsSource = allmeals;
           // ListOfMeals.ItemsSource =  (ListView)sortedmeals;
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