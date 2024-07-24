using AutoMapper;
using SignalRProject.DtoLayer.SocialMediaDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class SocialMediaMap : Profile
    {
        public SocialMediaMap()
        {
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
        }
    }
}
