using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace yusuf.trello.Boards.DTOs
{
    public class UpdateBoardDto:IEntityDto
    {
        public string Name { get; set; }

    }
}
