using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Cards.DTOs
{
    public class UpdateCardDto:IEntityDto
    {

        public string Name { get; set; }
        public Guid? ListeId { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
    }
}
