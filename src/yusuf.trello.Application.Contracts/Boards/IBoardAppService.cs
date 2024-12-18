using System;
using System.Collections.Generic;
using System.Text;
using yusuf.trello.Boards.DTOs;
using yusuf.trello.Services;

namespace yusuf.trello.Board
{
    public interface IBoardAppService:ICrudAppService<SelectBoardDto,ListBoardDto,BoardParameterDto,CreateBoardDto,UpdateBoardDto>
    {
    }
}
