using NoPoverty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Models;
using System.ComponentModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

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

        private void Tab1Clicked(object sender, EventArgs e)
        {
            stkTab1.IsVisible = true;
            stkTab2.IsVisible = false;
        }

        private void Tab2Clicked(object sender, EventArgs e)
        {
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = true;
        }

        async void SignUpButtonClicked(object sender, EventArgs e)
        {
            ToggleIndicator();

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
                ConfirmPassword = ConfirmPassword.Text,
            };

            //validation
            var signUpSucceeded = true;


            if (string.IsNullOrWhiteSpace(user.Firstname) && string.IsNullOrWhiteSpace(user.Lastname))
            {
                signUpSucceeded = false;
                await DisplayAlert("Name error", "Name cannot be blank or contain whitespaces", "OK");
                UserFname.Text = string.Empty;
                UserLname.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(user.Address))
            {
                signUpSucceeded = false;
                await DisplayAlert("Address error", "Address cannot be blank or contain whitespaces", "OK");
                UserAddress.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(user.Email) && !user.Email.Contains("@"))
            {
                signUpSucceeded = false;
                await DisplayAlert("Email format error", "Email must be in a typical email format", "OK");
                UserEmail.Text = string.Empty;
            }


            if (string.IsNullOrWhiteSpace(user.Username))
            {
                signUpSucceeded = false;
                await DisplayAlert("Username error", "Address cannot be blank or contain whitespaces", "OK");
                UserUsername.Text = string.Empty;
            }
            var person = await firebaseservice.GetUsers(user.Username);
            if (person != null)
            {
                await DisplayAlert("Error", "A person with that usernane already exist", "OK");
                signUpSucceeded = false;
                UserUsername.Text = string.Empty;
            }

            string errormsg;
            if (!ValidatePassword(user.Password, out errormsg))
            {
                signUpSucceeded = false;
                await DisplayAlert("Weak Password", errormsg, "OK");
                UserPassword.Text = string.Empty;
                ConfirmPassword.Text = string.Empty;


            }

            if (user.Password != user.ConfirmPassword)
            {
                signUpSucceeded = false;
                await DisplayAlert("Passwords mismatch", "Passwords don't match", "OK");
                ConfirmPassword.Text = string.Empty;
            }



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
                    ConfirmPassword.Text = string.Empty;

                    App.IsUserLoggedIn = true;
                    Global.logger = user;
                    // Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.FirstOrDefault());
                    // await Navigation.PopToRootAsync();
                    //await Navigation.PushAsync(new MainPage());  //back button works. bad code

                    Application.Current.MainPage = new MainPage();

                }
                else
                {
                    await DisplayAlert("Failed", "Signup Error", "OK");
                }
            }
            ToggleIndicator();

        }

        private void ToggleIndicator() => StackIndicator.IsVisible = !StackIndicator.IsVisible;

        private void ToggleIndicator2() => StackIndicator2.IsVisible = !StackIndicator2.IsVisible;
        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
