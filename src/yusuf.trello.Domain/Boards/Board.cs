using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using yusuf.trello.Lists;

namespace yusuf.trello.Boards
{
    public class Board : CreationAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public ICollection<Liste> Listes { get; set; }
    }
}
