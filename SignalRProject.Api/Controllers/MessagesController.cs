using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : BasesController
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok();
        }
    }
}
