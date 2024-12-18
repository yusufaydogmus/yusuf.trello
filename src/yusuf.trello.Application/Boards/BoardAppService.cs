using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using yusuf.trello.Board;
using yusuf.trello.Boards.DTOs;

namespace yusuf.trello.Boards
{
    [AllowAnonymous]
    public class BoardAppService:trelloAppService,IBoardAppService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardAppService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<SelectBoardDto> CreateAsync(CreateBoardDto input)
        {
            var entity = ObjectMapper.Map<CreateBoardDto, Board>(input);
            await _boardRepository.InsertAsync(entity);
            return ObjectMapper.Map<Board,SelectBoardDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _boardRepository.DeleteAsync(id);
        }

        public async Task<SelectBoardDto> GetAsync(Guid id)
        {
            var entity = await _boardRepository.GetAsync(id,x=>x.Id==id,x=>x.Listes);
            var mappedDto = ObjectMapper.Map<Board, SelectBoardDto>(entity);
            return mappedDto;
        }

        public async Task<PagedResultDto<ListBoardDto>> GetListAsync(BoardParameterDto input)
        {

            var entities = await _boardRepository.GetPagedListAsync(input.SkipCount,input.MaxResultCount,x=>x.Id);


            var totalCount = await _boardRepository.CountAsync();

            return new PagedResultDto<ListBoardDto>
            (
                totalCount,
                ObjectMapper.Map<List<Board>, List<ListBoardDto>>(entities)
            );
        }

        public async Task<SelectBoardDto> UpdateAsync(Guid id, UpdateBoardDto input)
        {
            var entity = await _boardRepository.GetAsync(id, x => x.Id == id);
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _boardRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Board,SelectBoardDto>(mappedEntity);
        }
    }
}
