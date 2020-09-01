using TogetherForeverApp.ViewModels.Members;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberPage : ContentPage
    {
        MemberViewModel _viewModel;
        public MemberPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MemberViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}