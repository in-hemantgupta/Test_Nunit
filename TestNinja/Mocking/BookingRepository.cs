using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNinja.Mocking
{
    public class BookingRepository : IBookingRepository
    {
        UnitOfWork _UnitOfWork;
        public BookingRepository(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public IEnumerable<Booking> GetAllValidBookings(int bookingId)
        {
            var bookings = _UnitOfWork.Query<Booking>()
                    .Where( b => b.Id != bookingId && b.Status != "Cancelled");

            return bookings;
        }
    }
}
