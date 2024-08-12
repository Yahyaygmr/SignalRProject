using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.DtoLayer.FeatureDtos;
using SignalRProject.EntityLayer.Entities;
using System.Reflection.Metadata.Ecma335;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : BasesController
    {
        [HttpGet("[action]")]
        public IActionResult FeatureList() => Ok(_serviceManager.featureService.GetAll());

        [HttpPost("[action]")]
        public IActionResult CreateFeature(CreateFeatureDto dto)
        {
            var result = _mapper.Map<Feature>(dto);

            _serviceManager.featureService.Add(result);

            return Ok("Feature Alanı eklendi.");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteFeature(int id)
        {
            _serviceManager.featureService.Delete(id);
            return Ok("Feature Alanı silindi.");
        }
        [HttpPut("[action]")]
        public IActionResult UpdateFeature(UpdateFeatureDto dto)
        {
            var result = _mapper.Map<Feature>(dto);
            _serviceManager.featureService.Update(result);
            return Ok("Feature Alanı güncellendi");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _serviceManager.featureService.GetById(id);
            return Ok(value);
        }

        [HttpGet("[action]")]
        public IActionResult FeatureCount()
        {
            var values = _serviceManager.featureService.FeatureCount();
            return Ok(values);
        }
    }
}
