using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Healox.PermissionServer.Sample.Web.Pages;

public class SignoutModel : PageModel
{
    public IActionResult OnGet()
    {
        return SignOut("Cookies", "oidc");
    }
}