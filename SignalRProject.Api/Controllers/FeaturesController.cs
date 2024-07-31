using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.FeatureDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : BasesController
    {
        [HttpGet("FeatureList")]
        public IActionResult FeatureList()
        {
            var values = _serviceManager.featureService.GetAll();
            return Ok(values);
        }
        [HttpPost("CreateFeature")]
        public IActionResult CreateFeature(CreateFeatureDto dto)
        {
            var result = _mapper.Map<Feature>(dto);

            _serviceManager.featureService.Add(result);

            return Ok("Feature Alanı eklendi.");
        }
        [HttpDelete("DeleteFeature/{id}")]
        public IActionResult DeleteFeature(int id)
        {
            _serviceManager.featureService.Delete(id);
            return Ok("Feature Alanı silindi.");
        }
        [HttpPut("UpdateFeature")]
        public IActionResult UpdateFeature(UpdateFeatureDto dto)
        {
            var result = _mapper.Map<Feature>(dto);
            _serviceManager.featureService.Update(result);
            return Ok("Feature Alanı güncellendi");
        }
        [HttpGet("GetFeature/{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _serviceManager.featureService.GetById(id);
            return Ok(value);
        }
    }
}
