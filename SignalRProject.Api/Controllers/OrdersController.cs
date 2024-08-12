using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BasesController
    {
        [HttpGet("TotalOrderCount")]
        public ActionResult TotalOrderCount()
        {
            var values = _serviceManager.orderService.TotalOrderCount();
            return Ok(values);
        }

        [HttpGet("ActiveOrderCount")]
        public ActionResult ActiveOrderCount()
        {
            var values = _serviceManager.orderService.ActiveOrderCount();
            return Ok(values);
        }

        [HttpGet("LastOrderPrice")]
        public ActionResult LastOrderPrice()
        {
            var values = _serviceManager.orderService.LastOrderPrice();
            return Ok(values);
        }
    }
}
