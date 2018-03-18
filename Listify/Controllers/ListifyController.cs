using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Listify.Controllers
{
    [Route("api/[controller]")]
    public class ListifyController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get(int start, int end, int index)
        {
            try
            {
                var list = new JustInTimeList(start, end);
                return Ok(list[index]);
            }
            catch (IndexOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        
    }
}
