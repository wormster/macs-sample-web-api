using Macs.WebApi.DataAccess.Entities;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> InsertAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindByKeyAsync(Guid id);
        Task<IEnumerable<TEntity>> QueryAsync(string query);
        void Update(TEntity entity);   
        Task SaveChangesAsync();
    }
}
