using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using yusuf.trello.Common;

namespace yusuf.trello.Boards
{
    public interface IBoardRepository:ICommonRepository<Board>
    {
        Task<List<Board>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,Expression<Func<Board, TKey>> orderBy = null,
    params Expression<Func<Board, object>>[] includeProperties);
    }
}
