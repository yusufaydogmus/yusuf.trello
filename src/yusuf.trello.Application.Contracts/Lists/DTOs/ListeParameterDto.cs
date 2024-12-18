using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Lists.DTOs
{
    public class ListeParameterDto:PagedResultRequestDto,IEntityDto
    {
        public Guid BoardId { get; set; }
    }
}
