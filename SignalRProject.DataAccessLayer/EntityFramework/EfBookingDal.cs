using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.DataAccessLayer.Concretes;
using SignalRProject.DataAccessLayer.Repositories;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly SignalRContext _context;
        public EfBookingDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void BookingSetStatusApproved(int id)
        {
            Booking? booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                booking.Description = "Rezervasyon Onaylandı";
                _context.SaveChanges();
            }
        }
        public void BookingSetStatusCancelled(int id)
        {
            Booking? booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                booking.Description = "Rezervasyon İptal Edildi";
                _context.SaveChanges();
            }
        }
    }
}
