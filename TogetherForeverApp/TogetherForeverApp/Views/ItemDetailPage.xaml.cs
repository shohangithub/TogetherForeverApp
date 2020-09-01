using System.ComponentModel;
using Xamarin.Forms;
using TogetherForeverApp.ViewModels;

namespace TogetherForeverApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}