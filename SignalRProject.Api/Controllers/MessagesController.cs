using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.MessageDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : BasesController
    {
        [HttpGet("[action]")]
        public IActionResult MessageList()
        {
            var values = _serviceManager.messageService.GetAll();
            var result = _mapper.Map<List<ResultMessageDto>>(values);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public IActionResult CreateMessage(CreateMessageDto dto)
        {
            var result = _mapper.Map<Message>(dto);
            result.Status = false;
            result.SendDate = DateTime.Now;
            _serviceManager.messageService.Add(result);

            return Ok("Mesaj eklendi.");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _serviceManager.messageService.Delete(id);
            return Ok("Mesaj silindi.");
        }
        [HttpPut("[action]")]
        public IActionResult UpdateMessage(UpdateMessageDto dto)
        {
            var result = _mapper.Map<Message>(dto);
            _serviceManager.messageService.Update(result);
            return Ok("Mesaj güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _serviceManager.messageService.GetById(id);
            var result = _mapper.Map<GetMessageByIdDto>(value);
            return Ok(result);
        }

        //[HttpGet("[action]")]
        //public IActionResult MessageCount()
        //{
        //    var values = _serviceManager.messageService.MessageCountByStatus(false);
        //    return Ok(values);
        //}
        //[HttpGet("[action]")]
        //public IActionResult GetMessagesByStatusFalse()
        //{
        //    var values = _serviceManager.messageService.GetMessagesByStatus(false);
        //    return Ok(values);
        //}
        //[HttpGet("[action]/{id}")]
        //public IActionResult MessageStatusChangeToFalse(int id)
        //{
        //    _serviceManager.messageService.MessageChangeToFalse(id);
        //    return Ok("Mesaj Okunmadı Olarak İşaretlendi");
        //}
        //[HttpGet("[action]/{id}")]
        //public IActionResult MessageStatusChangeToTrue(int id)
        //{
        //    _serviceManager.messageService.MessageChangeToTrue(id);
        //    return Ok("Mesaj Okundu Olarak İşaretlendi");
        //}
    }
}
