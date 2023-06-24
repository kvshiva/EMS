using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace EMS.Pages.StudentPages
{
    [Authorize("IsStudent")]
    public class StudentMenuModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
