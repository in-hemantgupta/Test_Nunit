using NUnit.Framework;
using Testing_Nunit.Fundamentals;


namespace Test_Nunit.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        //[TestMethod]
        //public void CanBeCancelledBy_Scenario_ExpectedBehavior()
        //{
        //}


        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //arrange
            var reservation = new Reservation();
            //act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnsFalse()
        {
            //arrange
            var reservation = new Reservation();
            //act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });
            //assert
            Assert.IsFalse(result);
        }
        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //arrange
            var reservation = new Reservation();
            //act
            var user = new User { };
            reservation.MadeBy = user;
            var result = reservation.CanBeCancelledBy(user);
            //assert
            Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_AnoutherUserCancelling_ReturnsTrue()
        {
            //arrange
            var reservation = new Reservation();
            //act
            var user = new User { };
            reservation.MadeBy = user;
            var result = reservation.CanBeCancelledBy(new User { });
            //assert
            Assert.That(result, Is.False);
        }
    }
}
