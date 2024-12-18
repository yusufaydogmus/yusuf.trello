using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using yusuf.trello.Cards;
using yusuf.trello.EntityFrameworkCore.Commons;

namespace yusuf.trello.EntityFrameworkCore.Cards
{
    public class EfCoreCardRepository : EfCoreCommonRepository<Card>, ICardRepository
    {
        public EfCoreCardRepository(IDbContextProvider<trelloDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
