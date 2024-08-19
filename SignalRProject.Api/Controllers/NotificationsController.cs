﻿using Microsoft.AspNetCore.Http;
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
            result.Status = false;
            _serviceManager.notificationService.Add(result);

            return Ok("Bildirim eklendi.");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _serviceManager.notificationService.Delete(id);
            return Ok("Bildirim silindi.");
        }
        [HttpPut("[action]")]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            var result = _mapper.Map<Notification>(dto);
            _serviceManager.notificationService.Update(result);
            return Ok("Bildirim güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _serviceManager.notificationService.GetById(id);
            var result = _mapper.Map<GetNotificationByIdDto>(value);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult NotificationCount()
        {
            var values = _serviceManager.notificationService.NotificationCountByStatus(false);
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetNotificationsByStatusFalse()
        {
            var values = _serviceManager.notificationService.GetNotificationsByStatus(false);
            return Ok(values);
        }
    }
}