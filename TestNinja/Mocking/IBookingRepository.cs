using System.Collections.Generic;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllValidBookings(int bookingId);
    }
}