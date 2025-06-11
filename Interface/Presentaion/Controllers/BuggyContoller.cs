using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentaion.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BuggyContoller :ControllerBase
    {
        [HttpGet("NotFound")]
        public IActionResult GetNotFoundRequest()
        {
            return NotFound();
        }
        [HttpGet("ServerError")]
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
            return Ok();
        }
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest() 
        {
            return BadRequest();
        }
        [HttpGet("BadRequest/{id}")] //Validation Request
        public IActionResult GetBadRequest(int id) 
        {
            return BadRequest();
        }
        [HttpGet("Unauthorized")]
        public IActionResult GetUnauthorizedRequest()
        {
            return Unauthorized();
        }

    }
}
