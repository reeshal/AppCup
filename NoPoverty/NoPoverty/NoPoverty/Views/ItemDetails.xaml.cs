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
    public partial class ItemDetails : ContentPage
    {
        Books currentbook;
        Stationery currentstat;
        public ItemDetails(Books b)
        {
            InitializeComponent();
            currentbook = b;
            donator.Text = b.Donator;
            title.Text = b.Title;
            description.Text = b.Description;
            pickuptime.Text = b.PickupTime;
            qty.Text = b.Quantity;
        }

        public ItemDetails(Stationery s)
        {
            InitializeComponent();
            currentstat = s;
            donator.Text = s.Donator;
            title.Text = s.Title;
            description.Text = s.Description;
            pickuptime.Text = s.PickupTime;
            qty.Text = s.Quantity;
        }

        private async void BtnReq_Click(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RequestItem());
            //await Navigation.PushAsync(new NavigationPage(new RequestItem()));
            await Navigation.PushModalAsync(new NavigationPage(new RequestItem()));
        }

    }
}