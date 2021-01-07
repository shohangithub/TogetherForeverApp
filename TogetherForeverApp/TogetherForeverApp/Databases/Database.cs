using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TogetherForeverApp.Data;
using TogetherForeverApp.Models;

namespace TogetherForeverApp.Databases
{
    public class Database<T> : IDatabase<T> where T : class, new()
    {

        private SQLiteAsyncConnection db;

        public Database(SQLiteAsyncConnection db)
        {
            this.db = db;
        }
        
        public async Task<bool> CreateTable<T>()
        {

            var cmd = await db.CreateTableAsync(typeof(T), CreateFlags.None);
            return true;
        }
        public AsyncTableQuery<T> AsQueryable() => db.Table<T>();

        public async Task<List<T>> Get() => await db.Table<T>().ToListAsync();

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id) => await db.FindAsync<T>(id);

        public async Task<T> Get(Expression<Func<T, bool>> predicate) => await db.FindAsync<T>(predicate);

        public async Task<int> Insert(T entity) => await db.InsertAsync(entity);

        public async Task<int> Update(T entity) => await db.UpdateAsync(entity);

        public async Task<int> Delete(T entity) => await db.DeleteAsync(entity);
    }

















    //readonly SQLiteAsyncConnection _database;

    //    public Database(string dbPath)
    //    {
    //        _database = new SQLiteAsyncConnection(dbPath);
    //        _database.CreateTablesAsync<Mill,Member>().Wait();
    //       // _database.CreateTableAsync<MemberX>().Wait();
    //    }

    //    //public Database(string dbPath)
    //    //{
    //    //    _database = new SQLiteAsyncConnection(dbPath);
    //    //    _database.CreateTableAsync<Member>().Wait();
    //    //}
    //    public Task<List<T>> GetPeopleAsync() 
    //    {
    //        return _database.Table<typeof(T)>().ToListAsync();
    //    }
    //    public Task<int> SaveMemberAsync(Member person)
    //    {
    //        return _database.InsertAsync(person);
    //    }
    //    public async Task<List<Member>> GetItemsAsync()
    //    {
    //        return await _database.Table<Member>().ToListAsync();
    //    }
    //    public Task<List<Member>> GetItemsNotDoneAsync()
    //    {
    //        // SQL queries are also possible
    //        return _database.QueryAsync<Member>("SELECT * FROM [Member] WHERE [MemberId] = 0");
    //    }
    //    public Task<Member> GetItemAsync(Guid id)
    //    {
    //        return _database.Table<Member>().Where(i => i.MemberId == id).FirstOrDefaultAsync();
    //    }
    //    public async Task<int> SaveItemAsync(Member item)
    //    {


    //       var xxx = await _database.InsertAsync(item);


    //        var xx = await _database.Table<Member>().ToListAsync();

    //        return xxx;
    //        //if (item.MemberId != Guid.Empty)
    //        //{
    //        //    return _database.UpdateAsync(item);
    //        //}
    //        //else
    //        //{
    //        //    item.MemberId = Guid.NewGuid();
    //        //    return _database.InsertAsync(item);
    //        //}
    //    }
    //    public Task<int> DeleteItemAsync(Member item)
    //    {
    //        return _database.DeleteAsync(item);
    //    }

        
    //}
}
