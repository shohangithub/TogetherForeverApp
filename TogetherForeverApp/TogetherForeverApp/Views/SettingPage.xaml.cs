using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogetherForeverApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        SettingViewModel  viewModel;
        public SettingPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SettingViewModel();
        }
    }
}