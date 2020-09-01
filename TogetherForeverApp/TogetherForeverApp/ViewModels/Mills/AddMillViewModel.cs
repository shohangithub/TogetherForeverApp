using System;
using System.Collections.Generic;
using TogetherForeverApp.Models;

namespace TogetherForeverApp.ViewModels.Mills
{
    public class AddMillViewModel:BaseViewModel
    {
        public List<Member> Members { get; set; }
        public EventHandler OnSelectedMemberCommand { get; }
        public AddMillViewModel()
        {
            var members =  new TogetherForeverApp.Services.MemberDataStore().GetMembers();
            Members = new List<Member>();
            Members.AddRange(members);
            OnSelectedMemberCommand = new EventHandler(BindingContext_Changed);

        }
        private void BindingContext_Changed(object sender, EventArgs e)
        {
            IsSetMember = true;
        }
    }
}
