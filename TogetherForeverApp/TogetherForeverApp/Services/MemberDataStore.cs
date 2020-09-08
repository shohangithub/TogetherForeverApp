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
                new Member { MemberId = Guid.NewGuid(), MemberName = "First item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid(), MemberName = "Second item", MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid(), MemberName = "Third item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid(), MemberName = "Fourth item", MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid(), MemberName = "Fifth item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" },
                new Member { MemberId = Guid.NewGuid(), MemberName = "Sixth item",  MemberEmail="This is an item description.",MemberContact="01854263181",IsManager=false,Password="" }
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
            var guidId = Guid.Parse(id);
            var oldItem = items.Where((Member arg) => arg.MemberId == guidId).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Member> GetItemAsync(string id)
        {
            var guidId = Guid.Parse(id);
            return await Task.FromResult(items.FirstOrDefault(s => s.MemberId == guidId));
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