using yusuf.trello.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace yusuf.trello.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(trelloEntityFrameworkCoreModule),
    typeof(trelloApplicationContractsModule)
    )]
public class trelloDbMigratorModule : AbpModule
{
}
