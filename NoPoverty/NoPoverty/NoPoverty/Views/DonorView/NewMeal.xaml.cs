using NoPoverty.Helper;
using NoPoverty.Models;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views.DonorView
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class NewMeal : ContentPage
    {
        FirebaseFood ff = new FirebaseFood();
        MainPageViewModel calendarbind = new MainPageViewModel();
        public NewMeal(Institution ins)
        {
            InitializeComponent();
        }

        async void btnaddMeal(object sender, EventArgs e)
        {
            await ff.AddMeal(FoodTitle.Text, FoodDesc.Text, Global.currentDonor.Username, FoodCalo.Text, FoodHealthiness.Text, FoodQty.Text, "");

            
            calendarbind.AddEvent2(DateTimeInput.Text, Global.currentDonor.Username, Description.Text);

            await DisplayAlert("Success", "Meal Uploaded Successfully", "OK");

            //FoodTitle.Text = string.Empty;
            //FoodDesc.Text = string.Empty;
            //FoodCalo.Text = string.Empty;
            //FoodHealthiness.Text = string.Empty;
            //FoodQty.Text = string.Empty;
            //DateTimeInput.Text = string.Empty;
            //Description.Text = string.Empty;
        }



        private void ViewCert(object sender, EventArgs e)
        {
            
        }

        
    }
}