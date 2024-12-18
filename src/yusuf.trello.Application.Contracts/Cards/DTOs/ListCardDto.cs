using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Cards.DTOs
{
    public class ListCardDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Position { get; set; }

    }
}
