using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Models;
using NoPoverty.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly FirebaseService firebaseservice = new FirebaseService();
        public LoginPage()
        {
            InitializeComponent();
            App.IsUserLoggedIn = false;

        }

        private async void TapToSignup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        async void Login_Clicked(object sender, EventArgs e)
        {
            var user = new Users
            {
                Username = LoginUsername.Text,
                Password = LoginPassword.Text
            };

            var isVaild = AreCredentialsCorrect(user);
            if (isVaild)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();

                //await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Wrong credentials", "Incorrect Password", "OK");
                LoginPassword.Text = string.Empty;
            }


        }

        bool AreCredentialsCorrect(Users user)
        {
            //return true;
            return (firebaseservice.GetUsers(user.Username) == user.Username);
          
            //return user.Username == Constants.Username && user.Password == Constants.Password;

        }
    }
}
