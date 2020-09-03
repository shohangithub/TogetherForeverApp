using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TogetherForeverApp.Models;

namespace TogetherForeverApp.Services
{
    public class MillDataStore : IDataStore<Mill>
    {
        public List<Mill> items;

        public MillDataStore()
        {
            items = new List<Mill>()
            {
                new Mill { MillId = Guid.NewGuid().ToString(),MemberId="1",MillDate=DateTime.Now.Date,BreakFast=true,Lunch=true,Dinner=true },
                new Mill { MillId = Guid.NewGuid().ToString(),MemberId="2",MillDate=DateTime.Now.Date,BreakFast=false,Lunch=true,Dinner=true },
                new Mill { MillId = Guid.NewGuid().ToString(),MemberId="3",MillDate=DateTime.Now.Date,BreakFast=true,Lunch=true,Dinner=true },
                new Mill { MillId = Guid.NewGuid().ToString(),MemberId="4",MillDate=DateTime.Now.Date,BreakFast=true,Lunch=true,Dinner=true },
                new Mill { MillId = Guid.NewGuid().ToString(),MemberId="5",MillDate=DateTime.Now.Date,BreakFast=true,Lunch=true,Dinner=true },
                new Mill { MillId = Guid.NewGuid().ToString(),MemberId="6",MillDate=DateTime.Now.Date,BreakFast=true,Lunch=true,Dinner=true }
            };
        }
        public async Task<bool> AddItemAsync(Mill item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Mill item)
        {
            var oldItem = items.Where((Mill arg) => arg.MillId == item.MillId).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Mill arg) => arg.MillId == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Mill> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.MillId == id));
        }

        public async Task<IEnumerable<Mill>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}