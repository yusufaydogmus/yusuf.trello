using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using yusuf.trello.EntityFrameworkCore.Commons;
using yusuf.trello.Lists;

namespace yusuf.trello.EntityFrameworkCore.Lists
{
    public class EFCoreListeRepository : EfCoreCommonRepository<Liste>, IListeRepository
    {
        public EFCoreListeRepository(IDbContextProvider<trelloDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
