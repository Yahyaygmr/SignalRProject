using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.NotificationDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BasesController
    {
        [HttpGet("[action]")]
        public IActionResult NotificationList()
        {
            var values = _serviceManager.notificationService.GetAll();
            return Ok(values);
        }
        [HttpPost("[action]")]
        public IActionResult CreateNotification(CreateNotificationDto dto)
        {
            var result = _mapper.Map<Notification>(dto);

            _serviceManager.notificationService.Add(result);

            return Ok("Rezervasyon işlemi eklendi.");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _serviceManager.notificationService.Delete(id);
            return Ok("Rezervasyon işlemi silindi.");
        }
        [HttpPut("[action]")]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            var result = _mapper.Map<Notification>(dto);
            _serviceManager.notificationService.Update(result);
            return Ok("Rezervasyon işlemi güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _serviceManager.notificationService.GetById(id);
            return Ok(value);
        }

        //[HttpGet("[action]")]
        //public IActionResult NotificationCount()
        //{
        //    var values = _serviceManager.notificationService.NotificationCount();
        //    return Ok(values);
        //}
    }
}
