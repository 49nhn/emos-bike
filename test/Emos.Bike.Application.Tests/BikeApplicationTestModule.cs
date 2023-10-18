using Volo.Abp.Modularity;

namespace Emos.Bike;

[DependsOn(
    typeof(BikeApplicationModule),
    typeof(BikeDomainTestModule)
    )]
public class BikeApplicationTestModule : AbpModule
{

}
