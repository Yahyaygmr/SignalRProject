using AutoMapper;
using SignalRProject.DtoLayer.TestimonialDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class TestimonialMap : Profile
    {
        public TestimonialMap()
        {
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        }
    }
}
