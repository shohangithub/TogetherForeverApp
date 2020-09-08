using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogetherForeverApp.ViewModels.Costing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CostingPage : ContentPage
    {
        public CostingPage()
        {
            InitializeComponent();
            BindingContext = new CostViewModel();
        }
    }
}