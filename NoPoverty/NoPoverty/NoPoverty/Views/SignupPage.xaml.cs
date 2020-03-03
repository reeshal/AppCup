using NoPoverty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        readonly FirebaseService firebaseservice = new FirebaseService();
        public SignupPage()
        {
            InitializeComponent();
        }
        private async void TapToLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }


        async void SignUpButtonClicked(object sender, EventArgs e)
        {
            Users user = new Users()
            {
                Username = UserUsername.Text,
                Firstname = UserFname.Text,
                Lastname = UserLname.Text,
                Address = UserAddress.Text,
                Email = UserEmail.Text,
                PhoneNo = UserContactNum.Text,
                Gender = "",
                Password = UserPassword.Text,
               
            };

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootpage = Navigation.NavigationStack.FirstOrDefault();
                if (rootpage != null)
                {
                    await firebaseservice.AddUsers(UserUsername.Text, UserFname.Text, UserLname.Text, UserAddress.Text, UserEmail.Text, UserContactNum.Text, "", UserPassword.Text);
                    UserUsername.Text = string.Empty;
                    UserFname.Text = string.Empty;
                    UserLname.Text = string.Empty;
                    UserAddress.Text = string.Empty;
                    UserEmail.Text = string.Empty;
                    UserContactNum.Text = string.Empty;
                    UserPassword.Text = string.Empty;

                    App.IsUserLoggedIn = true;
                   Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.FirstOrDefault());
                   //await Navigation.PopAsync();

                    await Navigation.PopToRootAsync();

                    //await Navigation.PushAsync(new MainPage());


                    //await DisplayAlert("Success", "Book Uploaded Successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Failed", "Signup Error", "OK");
                }
            }

        }

        bool AreDetailsValid(Users user)
        {
            return true;
            //return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}
