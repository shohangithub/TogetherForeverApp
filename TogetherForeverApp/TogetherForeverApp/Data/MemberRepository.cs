using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TogetherForeverApp.Models;

namespace TogetherForeverApp.Data
{
    public class MemberRepository 
    {
        private SQLiteAsyncConnection connection;
        public async Task AddorUpdate(Member member)
        {
            //if(member.MemberId != Guid.Empty)
            //{
            //    _= await connection.UpdateAsync(member);
            //}
            //else
            //{
            //    member.MemberId = Guid.NewGuid();
            //    _= await connection.InsertAsync(member);
            //}
        }

        public Task<List<Member>> GetMembers()
        {
            return connection.Table<Member>().ToListAsync();
        }

        public async Task Initialize()
        {
            if (connection != null) return;
            connection = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "AppData.db3"));
           await connection.CreateTableAsync<Member>();
        }
    }
}
