using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using yusuf.trello.Lists.DTOs;

namespace yusuf.trello.Boards.DTOs
{
    public class SelectBoardDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public  DateTime CreationTime { get; set; }

    }
}
