using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Cards.DTOs
{
    public class CardParameterDto: PagedResultRequestDto, IEntityDto
    {
        public Guid ListeId { get; set; }
    }
}
