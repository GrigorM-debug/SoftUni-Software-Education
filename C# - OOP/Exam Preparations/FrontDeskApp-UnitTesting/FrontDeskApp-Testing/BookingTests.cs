using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp_Testing
{
    public class BookingTests
    {
        private Room room;
        private Booking booking;
        [SetUp]
        public void SetUp()
        {
            room = new Room(2, 200);

            booking = new Booking(1, room, 20);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Assert.AreEqual(1, booking.BookingNumber);
            Assert.AreEqual(room, booking.Room);
            Assert.AreEqual(20, booking.ResidenceDuration);
        }

        [Test]
        public void BookingNumberPropertyShouldWorkProperly()
        {
            Assert.AreEqual(1, booking.BookingNumber);
        }

        [Test]
        public void RoomPropertyShouldWorkProperly()
        {
            Assert.AreEqual(room, booking.Room);
        }

        [Test]
        public void ResidenceDurationPropertyShouldWorkProperly()
        {
            Assert.AreEqual(20, booking.ResidenceDuration);
        }
    }
}
