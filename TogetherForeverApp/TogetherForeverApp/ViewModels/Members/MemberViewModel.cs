using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TogetherForeverApp.Models;
using TogetherForeverApp.Views;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels.Members
{
    public class MemberViewModel : BaseViewModel
    {
        private Member _selectedMember;

        public ObservableCollection<Member> Members { get; }
        public Command LoadMembersCommand { get; }
        public Command AddMemberCommand { get; }
        public Command<Member> MemberTapped { get; }
        public MemberViewModel()
        {
            Title = "Members";
            Members = new ObservableCollection<Member>();
            LoadMembersCommand = new Command(async () => await ExecuteLoadMembersCommand());

            MemberTapped = new Command<Member>(OnItemSelected);

            AddMemberCommand = new Command(OnAddMember);
        }
        async Task ExecuteLoadMembersCommand()
        {
            IsBusy = true;

            try
            {
                Members.Clear();
                var items = await MemberStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Members.Add(item);
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
            SelectedItem = null;
        }
        public Member SelectedItem
        {
            get => _selectedMember;
            set
            {
                SetProperty(ref _selectedMember, value);
                OnItemSelected(value);
            }
        }
        private async void OnAddMember(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewMemberPage));
        }
        async void OnItemSelected(Member item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.MemberId}");
        }
    }
}
