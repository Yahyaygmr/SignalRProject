﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.SocialMediaDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BasesController
    {
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _serviceManager.socialMediaService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto dto)
        {
            var result = _mapper.Map<SocialMedia>(dto);

            _serviceManager.socialMediaService.Add(result);

            return Ok("Sosyal Medya hesabı eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            _serviceManager.socialMediaService.Delete(id);
            return Ok("Sosyal Medya hesabı silindi.");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            var result = _mapper.Map<SocialMedia>(dto);
            _serviceManager.socialMediaService.Update(result);
            return Ok("Sosyal Medya hesabı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _serviceManager.socialMediaService.GetById(id);
            return Ok(value);
        }
    }
}