using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : BasesController
    {
        [HttpGet("[action]")]
        public IActionResult MenuTableCount()
        {
            int value = _serviceManager.menuTableService.MenuTableCount();
            return Ok(value);
        }
    }
}
