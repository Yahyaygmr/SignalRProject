using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstracts.Generics;

namespace SignalRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController : ControllerBase
    {
        // _mapper ve _serviceManager Dependency Injection (DI) kullanılarak enjekte ediliyor
        protected IMapper _mapper => HttpContext.RequestServices.GetService<IMapper>();
        protected IServiceManager _serviceManager => HttpContext.RequestServices.GetService<IServiceManager>();
    }
}
