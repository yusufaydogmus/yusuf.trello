using System.Threading.Tasks;

namespace yusuf.trello.Data;

public interface ItrelloDbSchemaMigrator
{
    Task MigrateAsync();
}
