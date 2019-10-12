using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookWarehouse.Domain
{
    public interface IAsyncRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> FindByKeyAsync(TKey id);

        IEnumerable<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> AllAsync();

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);
    }
}
