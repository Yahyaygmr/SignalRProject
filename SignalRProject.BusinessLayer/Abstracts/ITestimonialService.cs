﻿using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        int TestimonialCount();
    }
}
