using System;
using System.Collections.Generic;
using TogetherForeverApp.Models;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels.Mills
{
    public class AddMillViewModel:BaseViewModel
    {
        public List<Member> Members { get; set; }
        public Mill mill;
        public Mill Mill
        {
            get => mill;
            set => SetProperty(ref mill, value);
        }
        public EventHandler OnSelectedMemberCommand { get; }
        public Command OnAddMillCommand { get; }
        public AddMillViewModel()
        {
            var members =  new TogetherForeverApp.Services.MemberDataStore().GetMembers();
            Members = new List<Member>();
            mill = new Mill();
            Members.AddRange(members);
            OnSelectedMemberCommand = new EventHandler(BindingContext_Changed);
            OnAddMillCommand = new Command(() => this.SetMill());

        }
        private void BindingContext_Changed(object sender, EventArgs e)
        {
            IsSetMember = true;
        }
        private async void SetMill()
        {
            var x = Mill;
            new TogetherForeverApp.Services.MillDataStore().items.Add(Mill);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
