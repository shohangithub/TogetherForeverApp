using TogetherForeverApp.Models;
using TogetherForeverApp.Views;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        MillValue mill = new MillValue();
        public MillValue Mill
        {
            get { return mill; }
            set { SetProperty(ref mill, value); }
        }
        public Command SetMillValue { get;}
        public Command GotoMillValue { get;}

        public SettingViewModel()
        {
            GotoMillValue = new Command(GotoSetMillValue);
            SetMillValue = new Command(OnSetMillValue);
        }  
        private async void GotoSetMillValue(object obj)
        {
            await Shell.Current.GoToAsync(nameof(SetMillValuePage));
        }
        private async void OnSetMillValue(object obj)
        {
            var x = Mill;
            await Shell.Current.GoToAsync(nameof(SetMillValuePage));
        }
    }
}
