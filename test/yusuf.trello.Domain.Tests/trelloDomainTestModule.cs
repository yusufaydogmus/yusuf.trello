using yusuf.trello.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace yusuf.trello;

[DependsOn(
    typeof(trelloEntityFrameworkCoreTestModule)
    )]
public class trelloDomainTestModule : AbpModule
{

}
