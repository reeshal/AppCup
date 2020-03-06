using Firebase.Storage;
using NoPoverty.Helper;
using NoPoverty.Models;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebase.Helper;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateRepProfile : ContentPage
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("xamarinfirebase-66859.appspot.com");
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        FirebaseUsers fu = new FirebaseUsers();
        public UpdateRepProfile()
        {
            InitializeComponent();
        }

        async void btnUpdate(object sender, EventArgs e)
        {
            var rep = fu.GetRepresentative(Global.currentRep.Username);
            /*
             *  fu.UpdateREp
             * */
        }

        private async void Button_Upload_Cer(object sender, EventArgs e)
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
    }
}