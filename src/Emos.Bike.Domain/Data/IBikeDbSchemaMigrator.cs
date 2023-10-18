using System.Threading.Tasks;

namespace Emos.Bike.Data;

public interface IBikeDbSchemaMigrator
{
    Task MigrateAsync();
}
