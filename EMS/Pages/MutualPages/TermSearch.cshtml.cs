using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMS.Services.TermServices;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EMS.Pages.TermPages
{
    public class TermSearchModel : PageModel
    {
        [BindProperty]
        public TermSearchDto Input { get; set; }
        public void OnGet()
        {

        }
        public string responseContent { get; set; }
        public List<TermSearchDto> result = new List<TermSearchDto>();
        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44321/");
            HttpResponseMessage response = new HttpResponseMessage();
            string query = "api/term";
            if (Input != null)
            {
                query += "?";
            }
            if (Input.Sem != null)
            {
                query += "sem=" + Input.Sem + "&";
            }
            if (Input.PId != null)
            {
                query += "pid=" + Input.PId + "&";
            }
            if (Input.CId != null)
            {
                query += "cid=" + Input.CId + "&";
            }
            if (Input.Id != null)
            {
                query += "id=" + Input.Id + "&";
            }
            query = query.Remove(query.Length - 1, 1); //deleting the last &
            response = await client.GetAsync(query);
            //try
            //{
            //deserialize JSON here.
            responseContent = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<TermSearchDto>>(responseContent);
            return Page();
            //}
            //catch
            //{
            //    return NotFound();
            //}
        }

        //using services directly (instead of calling API)
        //public void OnPost()
        //{
        //    TermService _service = new TermService();
        //    result = _service.Search(input);
        //}
    }
}
