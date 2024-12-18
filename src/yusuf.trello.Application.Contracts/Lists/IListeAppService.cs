using System;
using System.Collections.Generic;
using System.Text;
using yusuf.trello.Lists.DTOs;
using yusuf.trello.Services;

namespace yusuf.trello.Lists
{
    public interface IListeAppService: ICrudAppService<SelectListeDto, ListListeDto, ListeParameterDto, CreateListeDto, UpdateListeDto>
    {
    }
}
