using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp_Testing
{
    public class HotelTests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;

        [SetUp]
        public void SetUp()
        {
            room = new Room(2, 200);

            booking = new Booking(1, room, 20);

            hotel = new Hotel("Hotel", 5);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string expectedFullName = "Hotel";
            int expectedCategory = 5;

            Assert.AreEqual(expectedFullName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);

            Assert.IsEmpty(hotel.Rooms);
            Assert.IsEmpty(hotel.Bookings);
        }

        [Test]
        public void FullNamePropertyShouldWorkProperly()
        {
            string expectedFullName = "Hotel";
            Assert.AreEqual(expectedFullName, hotel.FullName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void FullNamePropertyShouldThrowExceptionIfNameIsNullOrWhiteSpace(string fullName)
        {
           Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 5));
        }

        [Test]
        public void CategoryProperlyShouldWorkProperly()
        {
            int expectedCategory = 5;
            Assert.AreEqual(expectedCategory, hotel.Category);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(7)]
        public void CategoryPropertyShouldThrowExceptionIfCategoryIsNegativeOrMoreThan5(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel", category));
        }

        [Test]
        public void TurnoverPropertyShouldBeZero()
        {
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void RoomsCollectionShouldBeEmptyAsDefault()
        {
            Assert.IsEmpty(hotel.Rooms);
        }

        [Test]
        public void BookingsShouldBeEmptyAsDefault()
        {
            Assert.IsEmpty(hotel.Bookings);
        }

        [Test]
        public void RoomsPropertyShouldWorkProperly()
        {
            hotel.AddRoom(room);

            CollectionAssert.Contains(hotel.Rooms, room);
        }

        [Test]
        public void AddRoomShouldWorkProperly()
        {
            hotel.AddRoom(room);

            CollectionAssert.Contains(hotel.Rooms, room);
        }

        [Test]
        public void BookRoomShouldWorkProperly()
        {
            List<Room> rooms = new List<Room>();

            var room = new Room(2, 50);
            var room1 = new Room(4, 80);
            var room2 = new Room(1, 30);
            rooms.Add(room);
            rooms.Add(room1);
            rooms.Add(room2);

            foreach(var item in rooms)
            {
                hotel.AddRoom(item);
            }

            hotel.BookRoom(2, 1, 3, 2000);
            //Assert.IsNotNull(hotel.BookRoom(2, 100, 3, 800));
            CollectionAssert.IsNotEmpty(hotel.Bookings);
            Assert.AreEqual(240.0, hotel.Turnover);
        }

        [Test]
        public void BookingRoomWithNotEnoughBedsReturnsNull()
        {
            List<Room> rooms = new List<Room>();

            var room = new Room(2, 50);
            var room1 = new Room(4, 80);
            var room2 = new Room(1, 30);
            rooms.Add(room);
            rooms.Add(room1);
            rooms.Add(room2);

            foreach (var item in rooms)
            {
                hotel.AddRoom(item);
            }

            hotel.BookRoom(4, 2, 3, 2000);


            CollectionAssert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void BookingRoomWithInsufficientBudegetReturnsNull()
        {
            List<Room> rooms = new List<Room>();

            var room = new Room(2, 50);
            var room1 = new Room(4, 80);
            var room2 = new Room(1, 30);
            rooms.Add(room);
            rooms.Add(room1);
            rooms.Add(room2);

            foreach (var item in rooms)
            {
                hotel.AddRoom(item);
            }

            hotel.BookRoom(2, 1, 3, 40);


            CollectionAssert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-22)]
        public void BookRoomShouldThrowEceptionIsAdultsAreNegativeOrZero(int adults)
        {
            List<Room> rooms = new List<Room>();

            var room = new Room(2, 50);
            var room1 = new Room(4, 80);
            var room2 = new Room(1, 30);
            rooms.Add(room);
            rooms.Add(room1);
            rooms.Add(room2);

            foreach (var item in rooms)
            {
                hotel.AddRoom(item);
            }

            //hotel.BookRoom(adults, 1, 3, 40);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 1, 3, 40));
        }

        [TestCase(-1)]
        [TestCase(-20)]
        public void BookRoomShouldThrowExceptionIfChildrensAreNegative(int childrens)
        {
            List<Room> rooms = new List<Room>();

            var room = new Room(2, 50);
            var room1 = new Room(4, 80);
            var room2 = new Room(1, 30);
            rooms.Add(room);
            rooms.Add(room1);
            rooms.Add(room2);

            foreach (var item in rooms)
            {
                hotel.AddRoom(item);
            }

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, childrens, 3, 40));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void BookRoomsShouldThrowExceptionIfResidenceDurationIsNegativeOrZero(int residenceDuration)
        {
            List<Room> rooms = new List<Room>();

            var room = new Room(2, 50);
            var room1 = new Room(4, 80);
            var room2 = new Room(1, 30);
            rooms.Add(room);
            rooms.Add(room1);
            rooms.Add(room2);

            foreach (var item in rooms)
            {
                hotel.AddRoom(item);
            }

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 1, residenceDuration, 40));
        }
    }
}
