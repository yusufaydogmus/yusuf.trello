using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using yusuf.trello.Common;

namespace yusuf.trello.EntityFrameworkCore.Commons
{
    public class EfCoreCommonRepository<TEntity> : EfCoreRepository<trelloDbContext, TEntity, Guid>, ICommonRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        public EfCoreCommonRepository(IDbContextProvider<trelloDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }


        public async Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = await WithDetailsAsync(includeProperties);

            TEntity entity;

            if (predicate != null)
            {
                entity = await queryable.FirstOrDefaultAsync(predicate);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(TEntity), id);
                return entity;
            }

            entity = await queryable.FirstOrDefaultAsync();
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id);
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
       params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = await WithDetailsAsync(includeProperties);

            if (predicate != null)
                return await queryable.FirstOrDefaultAsync(predicate);

            return await queryable.FirstOrDefaultAsync();
        }


        public async Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null)
        {
            var queryable = await WithDetailsAsync();

            TEntity entity;

            if (predicate != null)
            {
                entity = await queryable.FirstOrDefaultAsync(predicate);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(TEntity), id);
                return entity;
            }

            entity = await queryable.FirstOrDefaultAsync();
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id);
            return entity;
        }


        public async Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,
         Expression<Func<TEntity, bool>> predicate = null,
         Expression<Func<TEntity, TKey>> orderBy = null,
         params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = await WithDetailsAsync(includeProperties);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                queryable = queryable.OrderBy(orderBy);

            return await queryable
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,
          Expression<Func<TEntity, bool>> predicate = null,
          Expression<Func<TEntity, TKey>> orderBy = null)
        {
            var queryable = await WithDetailsAsync();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                queryable = queryable.OrderBy(orderBy);

            return await queryable
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
