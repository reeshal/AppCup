using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Helper;
using NoPoverty.Models;
using NoPoverty.Views.DonorView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly FirebaseUsers fe = new FirebaseUsers();
        public static String LoginUser = "";
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
                await DisplayAlert("Empty Fields", "Please enter both credentials", "OK");

            else
            {
                if (LoginUser.Equals("Donor"))
                {
                    Donor user = await fe.GetDonor(Username);
                    if (user != null)
                    {
                        if (Username == user.Username && Password == user.Password)
                        {
                            App.IsUserLoggedIn = true;
                            Global.currentDonor = user;
                            // Navigation.InsertPageBefore(new MainPage(), this);
                            // await Navigation.PopAsync();
                            Application.Current.MainPage = new MainPageDonor();
                            //redirect to another =mainpaege
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
                else if (LoginUser.Equals("Institution"))
                {
                    Institution user = await fe.GetRepresentative(Username);
                    if (user != null)
                    {
                        if (Username == user.Username && Password == user.Password)
                        {
                            App.IsUserLoggedIn = true;
                            Global.currentRep = user;
                            // Navigation.InsertPageBefore(new MainPage(), this);
                            // await Navigation.PopAsync();
                            Application.Current.MainPage = new MainPage();
                            //redirect to another =mainpaege
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
                else
                {
                    await DisplayAlert("Choose user", "Please enter user type", "OK");
                }
            }
        }

        private void Donor_clicked(object sender, EventArgs e)
        {
            LoginUser = "Donor";
        }

        private void Rep_clicked(object sender, CheckedChangedEventArgs e)
        {
            LoginUser = "Institution";
        }

    }
}
