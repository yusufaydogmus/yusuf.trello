using AutoMapper;
using yusuf.trello.Boards.DTOs;
using yusuf.trello.Cards;
using yusuf.trello.Cards.DTOs;
using yusuf.trello.Lists;
using yusuf.trello.Lists.DTOs;

namespace yusuf.trello;

public class trelloApplicationAutoMapperProfile : Profile
{
    public trelloApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        //Board
        CreateMap<Boards.Board, SelectBoardDto>();
        CreateMap<Boards.Board,ListBoardDto>();
        CreateMap<CreateBoardDto, Boards.Board>();
        CreateMap<UpdateBoardDto,Boards.Board>();
        CreateMap<SelectBoardDto,CreateBoardDto>();
        CreateMap<SelectBoardDto, UpdateBoardDto>();

        //Liste
        CreateMap<Liste, SelectListeDto>()
            .ForMember(x => x.BoardName, y => y.MapFrom(z => z.Board.Name)).ReverseMap();
        CreateMap<Liste, ListListeDto>();

        CreateMap<CreateListeDto, Liste>();
        CreateMap<UpdateListeDto, Liste>();
        CreateMap<SelectListeDto, CreateListeDto>();
        CreateMap<SelectListeDto, UpdateListeDto>();

        //Card
        CreateMap<Card, SelectCardDto>();
           // .ForMember(x => x.ListeName, y => y.MapFrom(z => z.Liste.Name));
        CreateMap<Card, ListCardDto>();

        CreateMap<CreateCardDto, Card>();
        CreateMap<UpdateCardDto, Card>();
        CreateMap<SelectCardDto, CreateCardDto>();
        CreateMap<SelectCardDto, UpdateCardDto>();




    }
}
