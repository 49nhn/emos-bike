using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Emos.Bike.Web;

[Dependency(ReplaceServices = true)]
public class BikeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bike";
}
