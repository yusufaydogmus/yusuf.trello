using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using yusuf.trello.Lists.DTOs;

namespace yusuf.trello.Boards.DTOs;
public class ListBoardDto:EntityDto<Guid>
{
    public string Name { get; set; }
    public DateTime CreationTime { get; set; }


}
