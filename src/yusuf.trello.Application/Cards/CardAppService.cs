using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using yusuf.trello.Boards;
using yusuf.trello.Cards.DTOs;
using yusuf.trello.Lists;
using yusuf.trello.Lists.DTOs;

namespace yusuf.trello.Cards
{
    public class CardAppService : trelloAppService, ICardAppService
    {
        private readonly ICardRepository _cardRepository;

        public CardAppService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<SelectCardDto> CreateAsync(CreateCardDto input)
        {
            var entity = ObjectMapper.Map<CreateCardDto, Card>(input);

            // Tüm listelerin pozisyonlarını sırala ve en yükseğini al
            var queryable = await _cardRepository.WithDetailsAsync();

            var maxPosition = queryable.Where(x => x.ListeId == input.ListeId)
                .OrderByDescending(x => x.Position)
                .Select(x => x.Position).FirstOrDefault();
            if (maxPosition==null) maxPosition=0;

            // En yüksek pozisyonun bir fazlasını kullanarak yeni listenin pozisyonunu ayarla
            entity.Position = maxPosition + 1;

            await _cardRepository.InsertAsync(entity);

            return ObjectMapper.Map<Card, SelectCardDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _cardRepository.DeleteAsync(id);
        }

        public async Task<SelectCardDto> GetAsync(Guid id)
        {
            var entity = await _cardRepository.GetAsync(id, x => x.Id == id);
            var mappedDto = ObjectMapper.Map<Card, SelectCardDto>(entity);
            return mappedDto;
        }

        public async Task<PagedResultDto<ListCardDto>> GetListAsync(CardParameterDto input)
        {
            var entites = await _cardRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, 
                x => x.ListeId == input.ListeId,
                x=>x.Position);

    

            var totalCount = await _cardRepository.CountAsync(x => x.ListeId == input.ListeId);

            return new PagedResultDto<ListCardDto>(
                totalCount,
                ObjectMapper.Map<List<Card>, List<ListCardDto>>(entites)
                );
         
        }

        public async Task<SelectCardDto> UpdateAsync(Guid id, UpdateCardDto input)
        {
            var entity = await _cardRepository.GetAsync(id, x => x.Id == id);

            var mappedEntity = ObjectMapper.Map(input, entity);
            await _cardRepository.UpdateAsync(mappedEntity);

            return ObjectMapper.Map<Card,SelectCardDto>(mappedEntity);
        }

        
    }
}
