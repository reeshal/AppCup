using NoPoverty.Helper;
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
using NoPoverty.Views.DonorView;


namespace NoPoverty.Views.DonorView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstitutionList : ContentPage
    {
        readonly FirebaseUsers fu = new FirebaseUsers();
        public InstitutionList()
        {
            InitializeComponent();
        }
        private async Task FetchAllInstitutions()
        {
            var allIns = await fu.GetAllRepresentatives();

            ListOfInst.ItemsSource = allIns;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await FetchAllInstitutions();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var ins = args.SelectedItem as Institution;
            if (ins == null)
                return;


            await Navigation.PushAsync(new NewMeal(ins));

            // Manually deselect item.
            ListOfInst.SelectedItem = null;
        }

    }
}