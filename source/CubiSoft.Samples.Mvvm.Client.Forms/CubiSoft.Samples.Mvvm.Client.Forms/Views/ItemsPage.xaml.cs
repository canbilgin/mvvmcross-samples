using System;
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;
using CubiSoft.Samples.Mvvm.Client.Forms.Models;
using CubiSoft.Samples.Mvvm.Client.Forms.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using Xamarin.Forms;

namespace CubiSoft.Samples.Mvvm.Client.Forms.Views
{
    public partial class HubPagePage : MvxContentPage<HubPageViewModel>
    {
        public HubPagePage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            //// Manually deselect item
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
            //    viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
