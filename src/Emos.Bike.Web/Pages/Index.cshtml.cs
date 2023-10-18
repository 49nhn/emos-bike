using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Emos.Bike.Web.Pages;

public class IndexModel : BikePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
