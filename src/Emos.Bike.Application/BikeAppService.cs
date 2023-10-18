using Emos.Bike.Localization;
using Volo.Abp.Application.Services;

namespace Emos.Bike;

/* Inherit your application services from this class.
 */
public abstract class BikeAppService : ApplicationService
{
    protected BikeAppService()
    {
        LocalizationResource = typeof(BikeResource);
    }
}
