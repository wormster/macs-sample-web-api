using Microsoft.Data.SqlClient;
using NPoco;
using System.Data.SqlClient;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private string connectionString;
        public GenericRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDatabase Connection => new Database(connectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);

        public async Task<decimal> AddAsync(T entity)
        {
            using IDatabase db = Connection;
            var result = await db.InsertAsync(entity);

            return (decimal)result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using IDatabase db = Connection;
            return await db.SingleByIdAsync<T>(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            using IDatabase db = Connection;
            return await db.SingleByIdAsync<T>(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using IDatabase db = Connection;
            var all = await db.FetchAsync<T>();
            return all;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            using IDatabase db = Connection;
            var result = await db.DeleteAsync(entity);
            return result;
        }

        public void Delete(int id)
        {
            using IDatabase db = Connection;
            db.Delete<T>(id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            using IDatabase db = Connection;
            var result = await db.UpdateAsync(entity);

            return result;
        }
    }
}
