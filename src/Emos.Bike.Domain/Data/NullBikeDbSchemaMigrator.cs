using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Emos.Bike.Data;

/* This is used if database provider does't define
 * IBikeDbSchemaMigrator implementation.
 */
public class NullBikeDbSchemaMigrator : IBikeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
