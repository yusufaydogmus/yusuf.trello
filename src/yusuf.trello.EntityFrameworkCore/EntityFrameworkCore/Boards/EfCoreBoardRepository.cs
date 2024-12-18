using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using yusuf.trello.Boards;
using yusuf.trello.EntityFrameworkCore.Commons;

namespace yusuf.trello.EntityFrameworkCore.Boards;
public class EfCoreBoardRepository : EfCoreCommonRepository<Board>, IBoardRepository
{
    public EfCoreBoardRepository(IDbContextProvider<trelloDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<Board>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<Board, TKey>> orderBy = null, params Expression<Func<Board, object>>[] includeProperties)
    {
        var queryable = await WithDetailsAsync(includeProperties);

        if (orderBy != null)
            queryable = queryable.OrderBy(orderBy);

        return await queryable
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
