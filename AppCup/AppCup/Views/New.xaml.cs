using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class New : ContentPage
    {
        public New()
        {
            InitializeComponent();
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

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Camera_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Message", "Photo Capture and Pick not supported","ok");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_test.jpg"
                });

                if (file == null)
                    return;
                await DisplayAlert("File Path", file.Path, "Ok");

                MyImage.Source = ImageSource.FromStream(() =>
                  {
                      var stream = file.GetStream();
                      return stream;
                  });
            }
        }
    }
}