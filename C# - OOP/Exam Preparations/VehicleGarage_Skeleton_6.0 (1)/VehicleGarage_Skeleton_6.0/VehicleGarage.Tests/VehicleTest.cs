using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class VehicleTest
    {
        [TestCase("Ford", "Mustang", "X5228KH")]
        [TestCase("Mazda", "3", "H4556WH")]
        public void ConstructorShouldInitializeConrrectly(string brand, string model, string licenseplateNumber)
        {
            Vehicle vehicle = new(brand, model, licenseplateNumber);


            Assert.AreEqual(brand, vehicle.Brand);
            Assert.AreEqual(model, vehicle.Model);
            Assert.AreEqual(licenseplateNumber, vehicle.LicensePlateNumber);
        }

        [TestCase("Ford", "Mustang", "X5228KH")]
        [TestCase("Mazda", "3", "H4556WH")]
        public void BrandShouldBeInializeProperly(string brand, string model, string licenseplateNumber)
        {
            Vehicle vehicle = new(brand, model, licenseplateNumber);

            string expectedResult = brand;

            Assert.AreEqual(brand, vehicle.Brand);
        }

        [TestCase("Ford", "Mustang", "X5228KH")]
        [TestCase("Mazda", "3", "H4556WH")]
        public void ModelShouldInitializeProperly(string brand, string model, string licenseplateNumber)
        {
            Vehicle vehicle = new(brand, model, licenseplateNumber);

            Assert.AreEqual(model, vehicle.Model);
        }

        [TestCase("Ford", "Mustang", "X5228KH")]
        [TestCase("Mazda", "3", "H4556WH")]
        public void LicensePlateNumberShouldInitializeProperly(string brand, string model, string licenseplateNumber)
        {
            Vehicle vehicle = new(brand, model, licenseplateNumber);

            Assert.AreEqual(licenseplateNumber, vehicle.LicensePlateNumber);
        }

        [TestCase("Ford", "Mustang", "X5228KH")]
        [TestCase("Mazda", "3", "H4556WH")]
        public void BatteryLevelShouldBeSteTo100Percent(string brand, string model, string licenseplateNumber)
        {
            Vehicle vehicle = new(brand, model, licenseplateNumber);

            int expectedResult = 100;

            Assert.AreEqual(expectedResult, vehicle.BatteryLevel);
        }

        [TestCase("Ford", "Mustang", "X5228KH")]
        [TestCase("Mazda", "3", "H4556WH")]
        public void IsDamagedShouldBeInitializeAsFalse(string brand, string model, string licenseplateNumber)
        {
            Vehicle vehicle = new(brand, model, licenseplateNumber);


            Assert.IsFalse(vehicle.IsDamaged);  
        }
    }
}