using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Emos.Bike;

[Dependency(ReplaceServices = true)]
public class BikeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bike";
}
