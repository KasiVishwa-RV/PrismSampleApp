using PrismSampleApp.Model;
using PrismSampleApp.Repository.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismSampleApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private SQLiteAsyncConnection db;

        public GenericRepository()
        {
            var connection = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmployeeTable.db3");
            db = new SQLiteAsyncConnection(connection);
            db.CreateTableAsync<T>().Wait();
        }

        public AsyncTableQuery<T> AsQueryable() =>
            db.Table<T>();

        public async Task<List<T>> Get()
        {
            return await db.Table<T>().ToListAsync();
        }

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id) =>
             await db.FindAsync<T>(id);

        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await db.FindAsync<T>(predicate);

        public async Task<int> Insert(T entity)
        {
            return await db.InsertAsync(entity);
        }

        public async Task<int> Update(T entity) =>
             await db.UpdateAsync(entity);

        public async Task<int> Delete(T entity) =>
             await db.DeleteAsync(entity);
    }
}
