using Emos.Bike.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Emos.Bike.Web.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class BikePageModel : AbpPageModel
{
    protected BikePageModel()
    {
        LocalizationResourceType = typeof(BikeResource);
    }
}
