using NoPoverty.Helper;
using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealDetails : ContentPage
    {
        Meal currentmeal;
        Donor contactDonor;
        string donorname = "";
        FirebaseUsers fu = new FirebaseUsers();
        public MealDetails(Meal m)
        {
            InitializeComponent();
            currentmeal = m;
            donator.Text = m.Donator;
            title.Text = m.Title;
            description.Text = m.Description;
            qty.Text = m.Quantity;
            healthiness.Text = m.Healthiness;
            calorie.Text = m.Calorie;

            donorname = m.Donator;
        }
        
        private async void BtnReq_Click(object sender, EventArgs e)
        {
            contactDonor = await fu.GetDonor(donorname);
            //await Navigation.PushAsync(new RequestItem());
            //await Navigation.PushAsync(new NavigationPage(new RequestItem()));
            await Navigation.PushModalAsync(new NavigationPage(new RequestItem(contactDonor)));
        }
    }
}