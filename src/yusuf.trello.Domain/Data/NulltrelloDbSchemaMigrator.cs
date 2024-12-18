using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace yusuf.trello.Data;

/* This is used if database provider does't define
 * ItrelloDbSchemaMigrator implementation.
 */
public class NulltrelloDbSchemaMigrator : ItrelloDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
