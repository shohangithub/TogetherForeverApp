using System;
using System.Collections.ObjectModel;
using System.Linq;
using TogetherForeverApp.Models;
using TogetherForeverApp.ViewModels.Mills;
using TogetherForeverApp.Views;
using Xamarin.Forms;

namespace TogetherForeverApp.ViewModels.Costing
{
    public class CostViewModel : AddMillViewModel
    {
        public ObservableCollection<Cost> costList { get; set;}
        private Cost cost;
        private decimal summation;
        private DateTime DateFrom, DateTo;
        public DateTime dateFrom { get => DateFrom; set => SetProperty(ref DateFrom,value); }
        public DateTime dateTo { get => DateTo; set => SetProperty(ref DateTo, value); }
        public Cost Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }
        private Member selectedMember;
        public Member SelectedMember { get => selectedMember; set => SetProperty(ref selectedMember,value); }
        private DateTime selectedDate =DateTime.Now;
        public DateTime SelectedDate { get => selectedDate; set => SetProperty(ref selectedDate, value); }
        public decimal Summation
        {
            get => summation;
            set => SetProperty(ref summation, value);
        }
        public Command FindingCost { get; }
        public Command GotoSetCostView { get; }
        public Command AddCostCommand { get; }
        public Command BackToCostListView { get; }
        public CostViewModel()
        {
            IsBusy = true;
            cost = new Cost();
            costList = new ObservableCollection<Cost>();
            GetCostListAsync();
            FindingCost = new Command(() => this.FindCostList()); 
            GotoSetCostView = new Command(() =>this.SetCostView());
            AddCostCommand = new Command(() =>this.SetCost());
            BackToCostListView = new Command(() => this.CostListView());
            IsBusy = false;
        }

        public void GetCostListAsync()
        {
            costList.Add(new Cost { AddBy = Guid.NewGuid(), Amount = 500, CostBy = Guid.NewGuid(),CostByName = "Shohan",CostHead = "Bazar", CostId = Guid.NewGuid(), CostingDate = DateTime.Now });
            costList.Add(new Cost { AddBy = Guid.NewGuid(), Amount = 1000, CostBy = Guid.NewGuid(), CostByName = "Nayeem", CostHead = "Rice", CostId = Guid.NewGuid(), CostingDate = DateTime.Now });
            costList.Add(new Cost { AddBy = Guid.NewGuid(), Amount = 500, CostBy = Guid.NewGuid(), CostByName = "Shohan", CostHead = "Utility", CostId = Guid.NewGuid(), CostingDate = DateTime.Now });
            costList.Add(new Cost { AddBy = Guid.NewGuid(), Amount = 200, CostBy = Guid.NewGuid(), CostByName = "Mustaq", CostHead = "Others", CostId = Guid.NewGuid(), CostingDate = DateTime.Now });
            summation = costList.Sum(x =>(decimal?) x.Amount??0);
        } 
        public void FindCostList()
        {
            var findData = costList.Where(x => x.CostingDate >= dateFrom && x.CostingDate <= dateTo);
        }
        public async void SetCostView()
        {
            await Shell.Current.GoToAsync(nameof(AddCostPage));
        }
        private async void SetCost()
        {
            var member = SelectedMember;
            var date = SelectedDate;
            if (member != null)
            {
                Cost.CostByName = member.MemberName;
                Cost.CostBy = member.MemberId;
                Cost.AddBy = member.MemberId;
            }
            costList.Add(Cost);
            GetCostListAsync();
            // This will pop the current page off the navigation stack
            // await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync(nameof(CostingPage));
        }
        public async void CostListView()
        {
            await Shell.Current.GoToAsync(nameof(CostingPage));
        }

    }
}
