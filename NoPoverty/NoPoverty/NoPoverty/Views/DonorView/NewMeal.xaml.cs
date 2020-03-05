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
using Plugin.DownloadManager;
using Firebase.Storage;
using XamarinFirebase.Helper;

namespace NoPoverty.Views.DonorView
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class NewMeal : ContentPage
    {
        FirebaseFood ff = new FirebaseFood();
        FirebaseCalendar fc = new FirebaseCalendar();

        MainPageViewModel calendarbind = new MainPageViewModel();

        Institution currentIns;
        
        FirebaseStorage firebaseStorage = new FirebaseStorage("xamarinfirebase-66859.appspot.com");
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        public NewMeal(Institution ins)
        {
            InitializeComponent();
            currentIns = ins;
        }

        async void btnaddMeal(object sender, EventArgs e)
        {
             calendarbind.AddEvent2(DateTimeInput.Text, Global.currentDonor.Username, Description.Text);
            await fc.AddCalendar(DateTimeInput.Text, Global.currentDonor.Username, Description.Text,currentIns.InstitutionName);

            await ff.AddMeal(FoodTitle.Text, FoodDesc.Text, Global.currentDonor.Username, FoodCalo.Text, FoodHealthiness.Text, FoodQty.Text,currentIns.InstitutionName , "");
            
            FoodTitle.Text = ""; 
            FoodDesc.Text = "";
            FoodCalo.Text = ""; 
            FoodHealthiness.Text = ""; 
            FoodQty.Text = "";
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

        private async void BtnDownload_Clicked(object sender, EventArgs e)
        {
            string path = await firebaseStorageHelper.GetFile("readfile.pdf");
            if (path != null)
            {
                lbl.Text = path;
                var downloadManager = CrossDownloadManager.Current;
                var file = downloadManager.CreateDownloadFile(path);
                downloadManager.Start(file);
            }
        }
    }
}