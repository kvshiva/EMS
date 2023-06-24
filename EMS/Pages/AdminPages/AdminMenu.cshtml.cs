using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace EMS.Pages.AdminPages
{
    [Authorize("IsAdmin")]
    public class AdminMenuModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
