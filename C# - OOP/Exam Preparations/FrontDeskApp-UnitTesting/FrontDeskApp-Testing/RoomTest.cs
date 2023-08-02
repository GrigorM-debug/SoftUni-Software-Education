using FrontDeskApp;
using NUnit.Framework;

namespace FrontDeskApp_Testing
{
    public class RoomTest
    {
        private Room room;

        [SetUp]
        public void Setup()
        {
            room = new Room(2, 200);
        }

        [Test]
        public void ConstructorShouldInitializeValuesProperly()
        {
            int expectedBedCapcity = 2;
            double expectedpricePerNight = 200;

            Assert.AreEqual(expectedBedCapcity, room.BedCapacity);
            Assert.AreEqual(expectedpricePerNight, room.PricePerNight);
        }

        [Test]
        public void BedCapacityPropertyShouldWorkProperly()
        {
            int expectedBedCapcity = 2;
            Assert.AreEqual(expectedBedCapcity, room.BedCapacity);
        }

        [Test]
        public void PricePerNightProperlyShouldWorkProperly()
        {
            double expectedpricePerNight = 200;
            Assert.AreEqual(expectedpricePerNight, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-22)]
        public void BedCapacityPropertyShouldThrowExceptionIfValueIsZeroOrNegative(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(bedCapacity, 200));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-22)]
        public void PricePerNightShouldThrowExceptionIfValueIsZeroorNegative(double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(2, pricePerNight));
        }
    }
}