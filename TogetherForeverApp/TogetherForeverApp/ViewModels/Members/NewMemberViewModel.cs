using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using TogetherForeverApp.Databases;
using TogetherForeverApp.Models;
using TogetherForeverApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private Database<Member> database;
        public NewMemberViewModel()
        {
            database = new Database<Member>(App.dbConnection);
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
                MemberId = Guid.NewGuid(),
                MemberName = MemberName,
                MemberEmail = MemberEmail,
                MemberContact = MemberContact,
                IsManager = IsManager
            };

           
             await database.CreateTable<Member>();
            
             await database.Insert(newMember);
          
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
