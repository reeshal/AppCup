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
using NoPoverty.Helper;
using NoPoverty.Views.DonorView;
using XamarinFirebase.Helper;
using Firebase.Storage;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        readonly FirebaseUsers fb = new FirebaseUsers();

        FirebaseStorage firebaseStorage = new FirebaseStorage("xamarinfirebase-66859.appspot.com");
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();
        public SignupPage()
        {
            InitializeComponent();
        }
        private async void Button_Upload(object sender, EventArgs e)
        {
            try
            {

                FileData file = await CrossFilePicker.Current.PickFile();

                await firebaseStorageHelper.UploadFile(file.GetStream(), file.FileName);


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }

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
        private void ToggleIndicator() => StackIndicator.IsVisible = !StackIndicator.IsVisible;
        private void ToggleIndicator2() => StackIndicator2.IsVisible = !StackIndicator2.IsVisible;

        //button add Donor
        async void SignUpDonorButtonClicked(object sender, EventArgs e)
        {
            ToggleIndicator();
            string confirmPassword = ConfirmPassword.Text;
            Donor user = new Donor()
            {
                Username = UserUsername.Text,
                Firstname = UserFname.Text,
                Lastname = UserLname.Text,
                Address = UserAddress.Text,
                Email = UserEmail.Text,
                PhoneNo = UserContactNum.Text,
                Password = UserPassword.Text             
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
            var person = await fb.GetDonor(user.Username);
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

            if (user.Password != confirmPassword)
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
                    await fb.AddDonor(UserUsername.Text, UserFname.Text, UserLname.Text, UserAddress.Text, UserEmail.Text, UserContactNum.Text, UserPassword.Text);
                    App.IsUserLoggedIn = true;
                    Global.currentDonor = user;
                    Global.currentRep = null;
                    // Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.FirstOrDefault());
                    // await Navigation.PopToRootAsync();
                    //await Navigation.PushAsync(new MainPage());  //back button works. bad code
                    Application.Current.MainPage = new MainPageDonor();

                }
                else
                {
                    await DisplayAlert("Failed", "Signup Error", "OK");
                }
            }
            ToggleIndicator();

        }

        //button add Representative
        async void SignUpRepButtonClicked(object sender, EventArgs e)
        {
            ToggleIndicator();
            string confirmPassword = RepresentativeConfirmPassword.Text;
            Institution user = new Institution()
            {
                Username = RepresentativeUsername.Text,
                Firstname = RepresentativeFname.Text,
                Lastname = RepresentativeLname.Text,
                Address = RepresentativeAddress.Text,
                Email = RepresentativeEmail.Text,
                PhoneNo = RepresentativePhoneNum.Text,
                Password = RepresentativePassword.Text,
                InstitutionName = institutionName.Text,
                DietaryRequirements = DietaryReq.Text,
                InstitutionDetails=insDetails.Text
            };

            //validation
            var signUpSucceeded = true;

            
            if (string.IsNullOrWhiteSpace(user.Firstname) && string.IsNullOrWhiteSpace(user.Lastname))
            {
                signUpSucceeded = false;
                await DisplayAlert("Name error", "Name cannot be blank or contain whitespaces", "OK");
                RepresentativeFname.Text = string.Empty;
                RepresentativeLname.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(user.Address))
            {
                signUpSucceeded = false;
                await DisplayAlert("Address error", "Address cannot be blank or contain whitespaces", "OK");
                RepresentativeAddress.Text = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(user.Email) && !user.Email.Contains("@"))
            {
                signUpSucceeded = false;
                await DisplayAlert("Email format error", "Email must be in a typical email format", "OK");
                RepresentativeEmail.Text = string.Empty;
            }


            if (string.IsNullOrWhiteSpace(user.Username))
            {
                signUpSucceeded = false;
                await DisplayAlert("Username error", "Address cannot be blank or contain whitespaces", "OK");
                RepresentativeUsername.Text = string.Empty;
            }
            var person = await fb.GetDonor(user.Username);
            if (person != null)
            {
                await DisplayAlert("Error", "A person with that usernane already exist", "OK");
                signUpSucceeded = false;
                RepresentativeUsername.Text = string.Empty;
            }

            string errormsg;
            if (!ValidatePassword(user.Password, out errormsg))
            {
                signUpSucceeded = false;
                await DisplayAlert("Weak Password", errormsg, "OK");
                RepresentativePassword.Text = string.Empty;
                RepresentativeConfirmPassword.Text = string.Empty;
            }

            if (user.Password != confirmPassword)
            {
                signUpSucceeded = false;
                await DisplayAlert("Passwords mismatch", "Passwords don't match", "OK");
                RepresentativeConfirmPassword.Text = string.Empty;
            }
             
            if (signUpSucceeded)
            {
                var rootpage = Navigation.NavigationStack.FirstOrDefault();
                if (rootpage != null)
                {
                    await fb.AddRepresentative(RepresentativeUsername.Text, RepresentativeFname.Text, RepresentativeLname.Text, RepresentativeAddress.Text, RepresentativeEmail.Text, RepresentativePhoneNum.Text, RepresentativePassword.Text, institutionName.Text, DietaryReq.Text, insDetails.Text);

                    App.IsUserLoggedIn = true;
                    Global.currentRep = user;
                    Global.currentDonor = null;
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
            ToggleIndicator2();

        }
        
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
