using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using yusuf.trello.Lists;

namespace yusuf.trello.Cards;
public class Card:CreationAuditedEntity<Guid>
{
    public string Name { get; set; }
    public Guid ListeId { get; set; }
    public Liste Liste { get; set; }
    public string Description { get; set; }
    public int? Position { get; set; }

}
