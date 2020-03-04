using NoPoverty.Helper;
using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views.DonorView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMeal : ContentPage
    {
        FirebaseFood ff = new FirebaseFood();
        public NewMeal()
        {
            InitializeComponent();
        }

        async void btnaddMeal(object sender, EventArgs e)
        {
            await ff.AddMeal(FoodTitle.Text, FoodDesc.Text, Global.currentDonor.Username, FoodCalo.Text, FoodHealthiness.Text, FoodQty.Text, "");
            await DisplayAlert("Success", "Meal Uploaded Successfully", "OK");
        }
    }
}