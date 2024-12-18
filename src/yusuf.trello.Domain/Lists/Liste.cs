using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using yusuf.trello.Boards;
using yusuf.trello.Cards;

namespace yusuf.trello.Lists;
public class Liste:CreationAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public int Position { get; set; }
    public Guid BoardId { get; set; }
    public Board Board { get; set; }

    public virtual ICollection<Card> Cards { get; set; }
}
