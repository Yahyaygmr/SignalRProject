using AutoMapper;
using SignalRProject.DtoLayer.BasketDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class BasketMap : Profile
    {
        public BasketMap()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
        }
    }
}
