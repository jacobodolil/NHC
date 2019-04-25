using Microsoft.EntityFrameworkCore;
using NHC.Claims.DataAccess.DataStoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NHC.Claims.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbSet<T> _dbSet;
        public Repository(SqlDataStoreContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetByIdAsync(object Id)
        {
            return await _dbSet.FindAsync(Id).ConfigureAwait(false);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(object Id)
        {
            var entityToDelete = await _dbSet.FindAsync(Id).ConfigureAwait(false);
            _dbSet.Remove(entityToDelete);
            return true;
        }
    }
}
