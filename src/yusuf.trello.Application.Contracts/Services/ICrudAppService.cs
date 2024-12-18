using System;
using Volo.Abp.Application.Services;

namespace yusuf.trello.Services;
public interface ICrudAppService<TGetOutputDto,TGetListOutputDto,in TGetListInput,in TCreateInput, in TUpdateInput>:
   IReadOnlyAppService<TGetOutputDto, TGetListOutputDto, Guid, TGetListInput>
                                 , ICreateAppService<TGetOutputDto, TCreateInput>
                                 , IUpdateAppService<TGetOutputDto, Guid, TUpdateInput>
                                 , IDeleteAppService<Guid>
{

}
