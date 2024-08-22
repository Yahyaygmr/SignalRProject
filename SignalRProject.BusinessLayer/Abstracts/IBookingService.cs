using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface IBookingService : IGenericService<Booking>
    {
        int BookingCount();
        void BookingSetStatusApproved(int id);
        void BookingSetStatusCancelled(int id);
    }
}
