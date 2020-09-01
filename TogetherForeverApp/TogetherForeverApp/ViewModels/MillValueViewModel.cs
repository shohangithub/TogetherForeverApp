using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels
{
    public class MillValueViewModel:BaseViewModel
    {
        public Command SetMillValue { get; }
        public MillValueViewModel()
        {
            SetMillValue = new Command(OnSetMillValue);
        }
        private async void OnSetMillValue(object obj)
        {
            
            //await Shell.Current.GoToAsync(nameof(SetMillValuePage));
        }
    }
}
