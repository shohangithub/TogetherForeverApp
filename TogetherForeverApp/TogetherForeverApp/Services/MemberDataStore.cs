using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogetherForeverApp.Models;

namespace TogetherForeverApp.Services
{
    public class MemberDataStore : IDataStore<Member>
    {
        readonly List<Member> items;

        public MemberDataStore()
        {
            items = new List<Member>()
            {
                new Member { MemberId = Guid.NewGuid().ToString(), MemberName = "First item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid().ToString(), MemberName = "Second item", MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid().ToString(), MemberName = "Third item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid().ToString(), MemberName = "Fourth item", MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid().ToString(), MemberName = "Fifth item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid().ToString(), MemberName = "Sixth item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" }
            };
        }

        public async Task<bool> AddItemAsync(Member item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Member item)
        {
            var oldItem = items.Where((Member arg) => arg.MemberId == item.MemberId).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Member arg) => arg.MemberId == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Member> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.MemberId == id));
        }
        public async Task<Member> GetItemAsync()
        {
            return await Task.FromResult(items.FirstOrDefault());
        }

        public async Task<IEnumerable<Member>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public List<Member> GetMembers()
        {
            return  items.ToList();
        }
    }
}