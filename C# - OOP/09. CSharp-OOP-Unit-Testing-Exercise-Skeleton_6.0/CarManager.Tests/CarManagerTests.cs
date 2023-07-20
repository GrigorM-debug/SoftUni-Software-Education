namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Net.Http.Headers;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CarContructorShouldInitializeCorrectly()
        {
            Car car = new Car("Ford", "Mustang", 5, 40);

            string expectedMake = "Ford";
            string expectedModel = "Mustang";
            double expectedFuelConsumption = 5;
            double expectedFuelCapacity = 40;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model); 
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]  
        public void CarShouldBeCreatedWithZeroAmountOfFuel()
        {
            Car car = new Car("Ford", "Mustang", 5, 40);

            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConsructorShouldThrowExceptionIfCarMakeIsNullOrEmpty(string make)
        {
            string expectedMessage = "Make cannot be null or empty!";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car(make, "Mustang", 5, 40));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConsructorShouldThrowExceptionIfCarModelIsNullOrEmpty(string model)
        {
            string expectedMessage = "Model cannot be null or empty!";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Ford", model, 5, 40));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-29)]
        public void CarConsructorShouldThrowExceptionIfCarFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            string expectedMessage = "Fuel consumption cannot be zero or negative!";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Ford", "Ford", fuelConsumption, 40));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void CarConsructorShouldThrowExceptionIfCarFuelAmountISNegaive()
        {
            Car car = new Car("Ford", "Ford", 7.5, 50.0);

                                Assert.Throws<InvalidOperationException>(()
            => car.Drive(12), "Fuel amount cannot be negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-29)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            string expectedMessage = "Fuel capacity cannot be zero or negative!";

            ArgumentException x = Assert.Throws<ArgumentException>(() => new Car("Ford", "Mustang", 7.5, fuelCapacity));

            Assert.AreEqual(expectedMessage, x.Message);
        }

        [Test]
        public void RefuelMethodShouldIncreaseCarFuelAmount()
        {
            Car car = new Car("Ford", "Ford", 7.5, 50.0);

            double expctedResult = 40;

            car.Refuel(40);

            Assert.AreEqual(expctedResult, car.FuelAmount);
        }

        [Test]
        public void FuelAmountShouldBeLessThanFuelConsumption()
        {
            Car car = new Car("Ford", "Ford", 7.5, 50.0);

            int expectedResult = 50;

            car.Refuel(65);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveMethodShouldDecreaseFuelAmount()
        {
            Car car = new Car("Ford", "Ford", 7.5, 50.0);

            double expctedResult = 9.25;

            car.Refuel(10);
            car.Drive(10);

            double actualResult = car.FuelAmount;

            Assert.AreEqual(expctedResult, actualResult);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfYouDontHaveEnoughFuel() {
            string expedtedMessage = "You don't have enough fuel to drive!";

            Car car = new Car("Ford", "Ford", 7.5, 50.0);

            car.Refuel(10);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => car.Drive(300));

            Assert.AreEqual(expedtedMessage, ex.Message);
        }
    }
}
//I didn't found any mistake. I don't know why this code gives 90/100 points;