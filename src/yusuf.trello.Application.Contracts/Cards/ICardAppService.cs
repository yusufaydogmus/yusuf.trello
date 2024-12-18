using System;
using System.Collections.Generic;
using System.Text;
using yusuf.trello.Cards.DTOs;
using yusuf.trello.Services;

namespace yusuf.trello.Cards
{
    public interface ICardAppService:ICrudAppService<SelectCardDto, ListCardDto, CardParameterDto, CreateCardDto, UpdateCardDto>
    {
    }
}
