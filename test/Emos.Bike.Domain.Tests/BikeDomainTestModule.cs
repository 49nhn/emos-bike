using Emos.Bike.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Emos.Bike;

[DependsOn(
    typeof(BikeEntityFrameworkCoreTestModule)
    )]
public class BikeDomainTestModule : AbpModule
{

}
