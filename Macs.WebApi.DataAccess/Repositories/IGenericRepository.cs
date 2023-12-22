using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<decimal> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        void Delete(int id);
        Task<int> DeleteAsync(T entity);
    }
}
