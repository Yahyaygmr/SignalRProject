using AutoMapper;
using SignalRProject.DtoLayer.FeatureDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class FeatureMap : Profile
    {
        public FeatureMap()
        {
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        }
    }
}
