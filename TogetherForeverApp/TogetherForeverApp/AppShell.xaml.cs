using System;
using System.Collections.Generic;
using TogetherForeverApp.ViewModels;
using TogetherForeverApp.Views;
using Xamarin.Forms;

namespace TogetherForeverApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewMemberPage), typeof(NewMemberPage));
            Routing.RegisterRoute(nameof(AddMillPage), typeof(AddMillPage));
            Routing.RegisterRoute(nameof(SetMillValuePage), typeof(SetMillValuePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
