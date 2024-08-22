using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.DataAccessLayer.Abstracts.Interfaces
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingSetStatusApproved(int id);
        void BookingSetStatusCancelled(int id);

    }
}
