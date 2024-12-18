using Volo.Abp.Modularity;

namespace yusuf.trello;

[DependsOn(
    typeof(trelloApplicationModule),
    typeof(trelloDomainTestModule)
    )]
public class trelloApplicationTestModule : AbpModule
{

}
