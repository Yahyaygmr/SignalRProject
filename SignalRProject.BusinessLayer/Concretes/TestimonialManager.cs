using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class TestimonialManager : ITestimonialService
    {
        public DbSet<Testimonial> EntityTable => throw new NotImplementedException();

        public void Add(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetAll()
        {
            throw new NotImplementedException();
        }

        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Testimonial entity)
        {
            throw new NotImplementedException();
        }
    }
}
