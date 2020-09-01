using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TogetherForeverApp.Models;
using TogetherForeverApp.ViewModels.Members;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMemberPage : ContentPage
    {
        //public Member member { get; set; }
        public NewMemberPage()
        {
            InitializeComponent();
            BindingContext = new NewMemberViewModel();
        }
    }
}