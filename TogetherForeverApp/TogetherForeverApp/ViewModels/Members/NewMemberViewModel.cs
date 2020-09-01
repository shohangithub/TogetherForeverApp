using System;
using System.Collections.Generic;
using System.Text;
using TogetherForeverApp.Models;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels.Members
{
    public class NewMemberViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        private Guid MemberId;
        private string MemberName;
        private string MemberEmail;
        private string MemberContact;
        private bool IsManager;
        private string Password;
        public NewMemberViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(MemberName)
                && !String.IsNullOrWhiteSpace(MemberEmail)
                && !String.IsNullOrWhiteSpace(MemberContact);
        }
        public string memberName
        {
            get => MemberName;
            set => SetProperty(ref MemberName, value);
        }
        public string memberEmail
        {
            get => MemberEmail;
            set => SetProperty(ref MemberEmail, value);
        }
        public string memberContact
        {
            get => MemberContact;
            set => SetProperty(ref MemberContact, value);
        }
        public bool isManager
        {
            get => IsManager;
            set => SetProperty(ref IsManager, value);
        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Member newMember = new Member()
            {
                MemberId = Guid.NewGuid().ToString(),
                MemberName = memberName,
                MemberEmail = memberEmail,
                MemberContact = memberContact,
                IsManager = isManager                                   
            };

            await MemberStore.AddItemAsync(newMember);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
