using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            this.testimonialDal = testimonialDal;
        }

        public DbSet<Testimonial> EntityTable => testimonialDal.EntityTable;

        public void Add(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetAll()
        {
            return testimonialDal.GetAll();
        }

        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int TestimonialCount()
        {
            return testimonialDal.EntityTable.Count();
        }

        public void Update(Testimonial entity)
        {
            throw new NotImplementedException();
        }
    }
}
