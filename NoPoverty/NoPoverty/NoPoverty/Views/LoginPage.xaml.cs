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

            string Username = LoginUsername.Text;
            string Password = LoginPassword.Text;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                await DisplayAlert("Empty Values", "Please enter both credentials", "OK");

            else
            {
                Users user = await firebaseservice.GetUsers(Username);
                if (user != null)
                {
                    if (Username == user.Username && Password == user.Password)
                    {
                        App.IsUserLoggedIn = true;
                        Global.logger = user;
                        // Navigation.InsertPageBefore(new MainPage(), this);
                        // await Navigation.PopAsync();
                        Application.Current.MainPage = new MainPage();

                    }
                    else
                    {
                        await DisplayAlert("Login Fail", "Please enter correct password", "OK");
                        LoginPassword.Text = string.Empty;
                    }
                }
                else
                {
                    await DisplayAlert("Login Fail", "User not found", "OK");
                }
            }
        }
            
    }
}
