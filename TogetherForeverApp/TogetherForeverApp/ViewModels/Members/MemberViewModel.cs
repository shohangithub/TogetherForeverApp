using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using TogetherForeverApp.Databases;
using TogetherForeverApp.Models;
using TogetherForeverApp.Services;
using TogetherForeverApp.Views;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels.Members
{
    public class MemberViewModel : BaseViewModel
    {
        public ObservableCollection<Member> Members { get; }
        private Member Member;

        public Member member
        {
            get => Member;
            set => SetProperty(ref Member, value);
        }


        private Member _selectedMember;

        #region Command Properties
        public Command LoadMembersCommand { get; }
        public Command AddMemberCommand { get; }
        public Command<Member> MemberTapped { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        private Database<Member> database;
        public MemberViewModel()
        {
            Member = new Member();
            database = new Database<Member>(App.dbConnection);
           
            Title = "Members";
            Members = new ObservableCollection<Member>();
           
            this.ExecuteLoadMembersCommand();
           
            LoadMembersCommand = new Command(async () => await ExecuteLoadMembersCommand());
            MemberTapped = new Command<Member>(OnItemSelected);
            AddMemberCommand = new Command(OnAddMember);
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private async Task ExecuteLoadMembersCommand()
        {
            IsBusy = true;
            try
            {
                var items = await database.AsQueryable().ToListAsync(); //Database.GetItemsAsync();
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


        //private bool ValidateSave()
        //{
        //    return !String.IsNullOrWhiteSpace(member.MemberName)
        //        && !String.IsNullOrWhiteSpace(member.MemberEmail)
        //        && !String.IsNullOrWhiteSpace(member.MemberContact);
        //}
       
        private async void OnCancel()
        {
           
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            await database.CreateTable<Member>();

            if (Member.MemberId == Guid.Empty)
            {
                Member.MemberId = Guid.NewGuid();
                await database.Insert(Member);
                Members.Add(Member);
            }
            else
            {
                if (Members.Contains(Member))
                {
                    Members.Remove(Member);
                    await database.Update(Member);
                    Members.Add(Member);
                }

            }
            Member = new Member();
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public async Task OnPut(Member member)
        {
            Member = member;
            await Shell.Current.GoToAsync(nameof(NewMemberPage));
        }
        public async Task OnDelete(Member member)
        {
            await database.Delete(member);
            Members.Remove(member);
        }
    }
}
