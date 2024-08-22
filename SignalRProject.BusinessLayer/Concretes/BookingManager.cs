using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.DataAccessLayer.EntityFramework;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            this.bookingDal = bookingDal;
        }

        public DbSet<Booking> EntityTable => bookingDal.EntityTable;

        public void Add(Booking entity)
        {
            bookingDal.Add(entity);
        }

        public int BookingCount()
        {
            return bookingDal.EntityTable.Count();
        }

        public void BookingSetStatusApproved(int id)
        {
            bookingDal.BookingSetStatusApproved(id);
        }

        public void BookingSetStatusCancelled(int id)
        {
            bookingDal.BookingSetStatusCancelled(id);
        }

        public void Delete(int id)
        {
            Booking? booking = bookingDal.GetById(id);
            if (booking != null)
            {
                bookingDal.Delete(booking);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Booking> GetAll()
        {
            return bookingDal.GetAll();
        }

        public Booking GetById(int id)
        {
            return bookingDal.GetById(id);
        }

        public void Update(Booking entity)
        {
            bookingDal.Update(entity);
        }
    }
}
