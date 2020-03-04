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
    public partial class MyProfile : ContentPage
    {
        public MyProfile()
        {
            InitializeComponent();
            UserName.Text = Global.logger.Username;
            Location.Text = Global.logger.Address;
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RequestItem());
            //await Navigation.PushAsync(new NavigationPage(new RequestItem()));
            await Navigation.PushModalAsync(new NavigationPage(new EditProfile()));
        }
    }
}