using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMS.Services.TermServices;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace EMS.Pages.StudentPages
{
    public class SelectModel : PageModel
    {
        [BindProperty]
        public TermSelectDto input { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://localhost:44321/")
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/term-select", input);
            return (IActionResult)response;
            //catch
            //{
            //    return NotFound();
            //}
        }
    }
}
