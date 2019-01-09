using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        Mock<IBookingRepository> _bookingRepo;
        Booking _existingBookings;
        [SetUp]
        public void SetUp()
        {
            _bookingRepo = new Mock<IBookingRepository>();

            _existingBookings = new Booking { ArrivalDate = DateTime.Today.AddDays(1), DepartureDate = DateTime.Today.AddDays(5), Id = 2, Reference = "a", Status = "Active" };

            _bookingRepo.Setup(b => b.GetAllValidBookings(1)).Returns(new List<Booking>() { _existingBookings });
        }


        [Test]
        public void OverlappingBookingsExist_BookingIsCancelled_ShouldReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Status = "Cancelled" }, _bookingRepo.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsOnSameDayAndEndsAfterExistingBooking_ShouldReturnOverlappedBookingId()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Id = 1, ArrivalDate = DateTime.Now.AddDays(1), DepartureDate = DateTime.Now.AddDays(6) }, _bookingRepo.Object);
            Assert.That(result, Is.EqualTo(_existingBookings.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeAndEndAfter_ShouldReturnOverlappedBookingId()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Id = 1, ArrivalDate = DateTime.Now.Date, DepartureDate = DateTime.Now.AddDays(6).Date }, _bookingRepo.Object);

            Assert.That(result, Is.EqualTo(_existingBookings.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsInTheMiddle_ShouldReturnOverlappedBookingId()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking { Id = 1, ArrivalDate = DateTime.Now.Date.AddDays(2), DepartureDate = DateTime.Now.AddDays(4).Date }, _bookingRepo.Object);

            Assert.That(result, Is.EqualTo(_existingBookings.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsInTheMiddleEndsAfter_ShouldReturnOverlappedBookingId()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Id = 1, ArrivalDate = DateTime.Now.Date.AddDays(2), DepartureDate = DateTime.Now.AddDays(7).Date }, _bookingRepo.Object);

            Assert.That(result, Is.EqualTo(_existingBookings.Reference));
        }


        [Test]
        public void OverlappingBookingsExist_BookingStartsAndEndsAfter_ShouldReturnEmpty()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Id = 1, ArrivalDate = DateTime.Now.Date.AddDays(7), DepartureDate = DateTime.Now.AddDays(9).Date }, _bookingRepo.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingNotCancelledNorOverlapped_ShouldReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking { }, _bookingRepo.Object);

            Assert.That(result, Is.Empty);
        }
    }
}
