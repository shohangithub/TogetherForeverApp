using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TogetherForeverApp.Models;
using TogetherForeverApp.Services;
using TogetherForeverApp.Views;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels.Mills
{
    public class MillViewModel : BaseViewModel
    {
        private Mill _selectedMill;

        public ObservableCollection<Mill> MillList { get; }
        public Command LoadMillsCommand { get; }
        public Command AddMillCommand { get; }
        public Command<Mill> MillTapped { get; }
        public MillViewModel()
        {
            Title = "Mill List";
            MillList = new ObservableCollection<Mill>();
            ExecuteLoadMillsCommand();
            LoadMillsCommand = new Command(async () => await ExecuteLoadMillsCommand());
            AddMillCommand = new Command(OnAddMill);
        }
        async Task ExecuteLoadMillsCommand()
        {
            IsBusy = true;

            try
            {
                MillList.Clear();
                var items = await new MillDataStore().GetItemsAsync(true);
               // var items = await MillStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    var member  = await new MemberDataStore().GetItemAsync();
                    item.MemberName = member.MemberName;
                    MillList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
        private async void OnAddMill(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddMillPage));
        }
    }
}
