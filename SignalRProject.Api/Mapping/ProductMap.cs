using AutoMapper;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
