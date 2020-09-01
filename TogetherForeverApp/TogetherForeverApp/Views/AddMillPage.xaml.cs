using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogetherForeverApp.ViewModels.Mills;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMillPage : ContentPage
    {
        AddMillViewModel viewModel;
        public AddMillPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddMillViewModel();
            pickerX.SelectedIndexChanged += new EventHandler(viewModel.OnSelectedMemberCommand);
        }
    }
}