using AutoMapper;
using SignalRProject.DtoLayer.AboutDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class AboutMap : Profile
    {
        public AboutMap()
        {
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
