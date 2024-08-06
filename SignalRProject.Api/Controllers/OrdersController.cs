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
            var values = _serviceManager.orderService.EntityTable.Count();
            return Ok(values);
        }

        [HttpGet("ActiveOrderCount")]
        public ActionResult ActiveOrderCount()
        {
            var values = _serviceManager.orderService.EntityTable.Where(x => x.Description == "Müşteri Masada").Count();
            return Ok(values);
        }

        [HttpGet("LastOrderPrice")]
        public ActionResult LastOrderPrice()
        {
            var values = _serviceManager.orderService.EntityTable.OrderByDescending(x => x.OrderId).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
            return Ok(values);
        }
    }
}
