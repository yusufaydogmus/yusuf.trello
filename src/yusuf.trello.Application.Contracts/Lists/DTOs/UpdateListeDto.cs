using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Lists.DTOs
{
    public class UpdateListeDto:IEntityDto
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Guid? BoardId { get; set; }
    }
}
