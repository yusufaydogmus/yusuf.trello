using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using yusuf.trello.Boards;
using yusuf.trello.Cards;
using yusuf.trello.Lists.DTOs;

namespace yusuf.trello.Lists
{
    public class ListeAppService : trelloAppService, IListeAppService
    {
        private readonly IListeRepository _listeRepository;

        public ListeAppService(IListeRepository listeRepository)
        {
            _listeRepository = listeRepository;
        }

        public async Task<SelectListeDto> CreateAsync(CreateListeDto input)
        {
            var entity = ObjectMapper.Map<CreateListeDto, Liste>(input);

            // Tüm listelerin pozisyonlarını sırala ve en yükseğini al
            var queryable = await  _listeRepository.WithDetailsAsync();
         
            var maxPosition =  queryable.Where(x => x.BoardId == input.BoardId)
                .OrderByDescending(x => x.Position)
                .Select(x => x.Position).FirstOrDefault();


            // En yüksek pozisyonun bir fazlasını kullanarak yeni listenin pozisyonunu ayarla
            entity.Position = maxPosition + 1;

            await _listeRepository.InsertAsync(entity);

            return ObjectMapper.Map<Liste, SelectListeDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _listeRepository.DeleteAsync(id);
            //liste silinince listenin sahip olduğu pozisyondan 1 fazla olanlar 1 eksilmeli

        }

        public async Task<SelectListeDto> GetAsync(Guid id)
        {
            var entity = await _listeRepository.GetAsync(id, x => x.Id == id,x=>x.Cards);

            return ObjectMapper.Map<Liste,SelectListeDto>(entity);
        }

        public async Task<PagedResultDto<ListListeDto>> GetListAsync(ListeParameterDto input)
        {
            var entities = await _listeRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,
                x => x.BoardId == input.BoardId,x=>x.Position,x=>x.Cards.OrderBy(c=>c.Position));
          
            var totalCount = await _listeRepository.CountAsync(x => x.BoardId == input.BoardId);

            return new PagedResultDto<ListListeDto>(
                totalCount,
                ObjectMapper.Map<List<Liste>,List<ListListeDto>>(entities));
        }

        public async Task<SelectListeDto> UpdateAsync(Guid id, UpdateListeDto input)
        {
            var entity = await _listeRepository.GetAsync(id, x => x.Id == id);

            var mappedEntity = ObjectMapper.Map(input, entity);
            await _listeRepository.UpdateAsync(mappedEntity);

            return ObjectMapper.Map<Liste, SelectListeDto>(mappedEntity);
        }
        public async Task<SelectListeDto> UpdateCardPositionsAsync(Guid id, UpdateCardPositionParameterDto input)
        {

            var startList = await _listeRepository.GetAsync(id, x => x.Id == id,x=>x.Cards);
            var endList = await _listeRepository.GetAsync(input.endListId,x=>x.Id==input.endListId,x=>x.Cards);
            int end = input.end;
            int start = input.start;
            var cardToMove = startList.Cards.FirstOrDefault(x => x.Position == start);

            if(cardToMove != null)
            {
                startList.Cards.Remove(cardToMove);

                // Hedef listeye kartı ekleyin ve pozisyonunu güncelleyin
                cardToMove.Position = input.end;
                foreach (var card in startList.Cards.Where(x => x.Position > input.start))
                {
                    card.Position--;
                }
                foreach (var card in endList.Cards.Where(x => x.Position >= input.end))
                {
                    card.Position++;
                }
                endList.Cards.Add(cardToMove);
                // Veritabanını güncelleyin
                await _listeRepository.UpdateAsync(startList);
                await _listeRepository.UpdateAsync(endList);

                return ObjectMapper.Map<Liste, SelectListeDto>(startList);
            }
            else
            {
                // Hata işleme kodu buraya eklenebilir
                // Kart bulunamazsa veya başka bir hata oluştuysa nasıl işlem yapılacağını belirleyebilirsiniz.
                throw new Exception("Kart bulunamadı veya başka bir hata oluştu.");
            }
        }

            
            

            //var mappedEntity = ObjectMapper.Map(input, startList);
            //await _listeRepository.UpdateAsync(mappedEntity);

            //return ObjectMapper.Map<Liste, SelectListeDto>(mappedEntity);
        
    }
}
