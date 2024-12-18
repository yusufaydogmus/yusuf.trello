using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Cards.DTOs
{
    public class SelectCardDto:EntityDto<Guid>
    {
        public string Name { get; set; }
        //public string? ListeName { get; set; }
        public Guid ListeId { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
    }
}
