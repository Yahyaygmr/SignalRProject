using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class BookingManager : IBookingService
    {
        public DbSet<Booking> EntityTable => throw new NotImplementedException();

        public void Add(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
