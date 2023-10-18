using Emos.Bike.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Emos.Bike.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BikeController : AbpControllerBase
{
    protected BikeController()
    {
        LocalizationResource = typeof(BikeResource);
    }
}
