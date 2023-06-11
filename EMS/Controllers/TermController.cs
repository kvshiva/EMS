using Microsoft.AspNetCore.Mvc;
using EMS.Services.TermServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EMS.Controllers
{

    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly TermService _services = new TermService();
        [HttpPost]
        [Route("api/term")]
        public ActionResult Insert([FromBody] TermInsertDto input)
        {
            //try
            //{
               _services.Insert(input);
               return Ok("Successfully Added!");
            //}
            //catch
            //{
            //    return BadRequest("Unknown Error!");
            //}
            
        }
        [HttpPost]
        [Route("api/term-select")]
        public ActionResult Select([FromBody] TermSelectDto input)
        {
            //try
            //{
            _services.Select(input);
            return Ok("Successfully Selected!");
            //}
            //catch
            //{
            //    return BadRequest("Unknown Error!");
            //}

        }
        [HttpGet]
        [Route("api/term")]
        public ActionResult Search([FromQuery] int? cid, [FromQuery] int? pid, [FromQuery] int? sem, [FromQuery] int? id)
        {
            TermSearchDto input = new()
            {
                CId = cid,
                PId = pid,
                Sem = sem,
                Id = id
            };
            //try
            //{
            return Ok(_services.Search(input));
            //}
            //catch
            //{
            //    return BadRequest("Unknown Error!");
            //}
        }
    }
}
