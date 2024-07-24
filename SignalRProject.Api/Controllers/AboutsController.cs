using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.DtoLayer.AboutDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : BasesController
    {
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _serviceManager.aboutService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto dto)
        {
            var result = _mapper.Map<About>(dto);

            _serviceManager.aboutService.Add(result);

            return Ok("Hakkımda alanı eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            _serviceManager.aboutService.Delete(id);
            return Ok("Hakkımda alanı silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            var result = _mapper.Map<About>(dto);
            _serviceManager.aboutService.Update(result);
            return Ok("Hakkımda alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _serviceManager.aboutService.GetById(id);
            return Ok(value);
        }
    }
}
