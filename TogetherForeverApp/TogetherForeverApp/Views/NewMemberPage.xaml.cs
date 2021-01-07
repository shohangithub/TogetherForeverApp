using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMemberPage : ContentPage
    {
        public NewMemberPage()
        {
            InitializeComponent();
            BindingContext = MemberPage._viewModel; 
        }
    }
}