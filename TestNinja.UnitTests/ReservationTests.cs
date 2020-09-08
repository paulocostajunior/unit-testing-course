using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrenge
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            // Arrenge
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            // Arrenge
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.IsFalse(result);

        }
    }
}
