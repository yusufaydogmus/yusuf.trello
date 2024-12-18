using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Lists.DTOs
{
    public class UpdateCardPositionParameterDto : IEntityDto
    {

        public Guid endListId { get; set; }
        public int start { get; set; }
        public int end { get; set; }
    }
}
