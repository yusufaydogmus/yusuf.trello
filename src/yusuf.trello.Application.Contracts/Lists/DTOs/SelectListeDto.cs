using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using yusuf.trello.Cards.DTOs;

namespace yusuf.trello.Lists.DTOs
{
    public class SelectListeDto:EntityDto<Guid>
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Guid BoardId { get; set; }
        public string BoardName { get; set;}
        public ICollection<SelectCardDto> Cards { get; set; }
    }
}
