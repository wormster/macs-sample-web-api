using Macs.WebApi.DataAccess.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        internal readonly DbContext context;
        internal readonly DbSet<TEntity> dbSet;
        public GenericRepository(DbContext context)
        {
             this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await FindByKeyAsync(id);
            dbSet.Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await context.Set<TEntity>().SingleAsync(entity => entity.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> results = await dbSet.AsNoTracking()
                .Where(predicate)
                .ToListAsync();

            return results;
        }

        public async Task<TEntity> FindByKeyAsync(Guid id)
        {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
