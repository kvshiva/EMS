using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMS.Services.TermServices;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EMS.Pages.TermPages
{
    public class TermInsertModel : PageModel
    {
        [BindProperty]
        public TermInsertDto input { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://localhost:44321/")
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/term", input);
            return (IActionResult)response;
            //catch
            //{
            //    return NotFound();
            //}
        }
    }
}
