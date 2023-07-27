using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleGarage.Tests
{
    public  class GarageTest
    {
        [Test]
        public void GarageConstructor_ShouldSetCapacityAndInitializeVehiclesList()
        {
            // Arrange
            int expectedCapacity = 10;

            // Act
            Garage garage = new Garage(expectedCapacity);

            // Assert
            Assert.AreEqual(expectedCapacity, garage.Capacity);
            Assert.IsNotNull(garage.Vehicles);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [Test]
        public void CapacityPropertyShouldWorkProperly()
        {
            int expectedCapacity = 10;

            Garage garage = new(10);

            Assert.AreEqual(expectedCapacity, garage.Capacity);
        }

        [Test]
        public void AddMethodShouldReturnTrue()
        {
            Garage garage = new Garage(capacity: 2);

            Vehicle vehicle1 = new Vehicle ("cwcwcw", "cwcwc", "ABC123" );
            Vehicle vehicle2 = new Vehicle("cwcwcw", "cwcwc", "XYZ789");

            // Act
            bool isAdded1 = garage.AddVehicle(vehicle1);
            bool isAdded2 = garage.AddVehicle(vehicle2);

            // Assert
            Assert.IsTrue(isAdded1); // Vehicle1 should be added successfully
            Assert.IsTrue(isAdded2); // Vehicle2 should be added successfully

            Assert.AreEqual(2, garage.Vehicles.Count); // Garage should contain 2 vehicles
            CollectionAssert.Contains(garage.Vehicles, vehicle1); // Vehicle1 should be in the garage
            CollectionAssert.Contains(garage.Vehicles, vehicle2);
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_WhenGarageIsAtCapacity()
        {
            // Arrange
            Garage garage = new Garage(capacity: 1);

            Vehicle vehicle1 = new Vehicle ("wcwcw", "cwcwc","ABC123" );
            Vehicle vehicle2 = new Vehicle ("wcwc","wcw", "XYZ789" );

            // Act
            bool isAdded1 = garage.AddVehicle(vehicle1); // Adding the first vehicle (should be successful)
            bool isAdded2 = garage.AddVehicle(vehicle2); // Attempting to add the second vehicle (should fail)

            // Assert
            Assert.IsTrue(isAdded1); // Vehicle1 should be added successfully
            Assert.IsFalse(isAdded2); // Vehicle2 should not be added due to capacity constraint

            Assert.AreEqual(1, garage.Vehicles.Count); // Garage should contain only 1 vehicle
            CollectionAssert.Contains(garage.Vehicles, vehicle1); // Vehicle1 should be in the garage
            CollectionAssert.DoesNotContain(garage.Vehicles, vehicle2); // Vehicle2 should not be in the garage
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_WhenVehicleWithSameLicensePlateNumberExists()
        {
            // Arrange
            Garage garage = new Garage(capacity: 2);

            Vehicle vehicle1 = new Vehicle ("wdwdw","wcwc", "ABC123" );
            Vehicle vehicle2 = new Vehicle("wdwdw", "wcwc", "ABC123");  // Same license plate number as vehicle1

            // Act
            bool isAdded1 = garage.AddVehicle(vehicle1); // Adding the first vehicle (should be successful)
            bool isAdded2 = garage.AddVehicle(vehicle2); // Attempting to add the second vehicle (should fail)

            // Assert
            Assert.IsTrue(isAdded1); // Vehicle1 should be added successfully
            Assert.IsFalse(isAdded2); // Vehicle2 should not be added due to duplicate license plate number

            Assert.AreEqual(1, garage.Vehicles.Count); // Garage should contain only 1 vehicle
            CollectionAssert.Contains(garage.Vehicles, vehicle1); // Vehicle1 should be in the garage
            CollectionAssert.DoesNotContain(garage.Vehicles, vehicle2); // Vehicle2 should not be in the garage
        }

        [Test]
        public void ChargeVehicleShouldZeroIfNoVehicleIsChange()
        {
            Vehicle vehicle = new("Ford", "Mustang", "wuwhfhuwe");

            Garage garage = new(2);

            //garage.ChargeVehicles(60);

            int expectedResult = 0;

            Assert.AreEqual(expectedResult, garage.ChargeVehicles(60));
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void ChargeVehicleShouldSetBatteryLevelTo100(string brand, string model, string licenceNumber)
        {
            Vehicle vehicle = new(brand, model, licenceNumber);


            Garage garage = new(2);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle(licenceNumber, 80, false);
            //garage.ChargeVehicles(100);
            garage.ChargeVehicles(80);
            //int expectedResult = 0;

            Assert.AreEqual(100, vehicle.BatteryLevel);
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void ChargeMethodShouldIncreasetheCount(string brand, string model, string licenceNumber)
        {
            Vehicle vehicle = new(brand, model, licenceNumber);


            Garage garage = new(2);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle(licenceNumber, 80, false);
            //garage.ChargeVehicles(100);
            //garage.ChargeVehicles(80);
            //int expectedResult = 0;

            Assert.AreEqual(1, garage.ChargeVehicles(80));
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void DriveVehicleShouldDecreaseTheBatteryLevel(string brand, string model, string licenseNumber)
        {
            Vehicle vehicle = new(brand, model, licenseNumber);


            Garage garage = new(2);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle(licenseNumber, 80, false);

            int expectedResult = 20; ;

            Assert.AreEqual(expectedResult, vehicle.BatteryLevel);
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void DriveVehicleShouldSetIsDamageToTrueIfAccidentOCcured(string model, string brand, string licenseNumber)
        {
            Vehicle vehicle = new(brand, model, licenseNumber);


            Garage garage = new(2);

            garage.AddVehicle(vehicle);
            garage.DriveVehicle(licenseNumber, 80, true);

            Assert.IsTrue(vehicle.IsDamaged);
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void DriveMethodShouldStopIfVehicleIsDamaged(string brand, string model, string licenseNumber)
        {

            Vehicle vehicle = new(brand, model, licenseNumber);


            Garage garage = new(2);

            garage.AddVehicle(vehicle);
            garage.DriveVehicle(licenseNumber, 80, true);
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void DriveMethodShouldStopBatteryDrainageIsMoreThan100(string brand, string model, string licenseNumber)
        {

            Vehicle vehicle = new(brand, model, licenseNumber);


            Garage garage = new(2);

            garage.AddVehicle(vehicle);
            garage.DriveVehicle(licenseNumber, 200, false);
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        public void DriveMethodShouldStopIfBatteryDrainageIsMoreThanBatteryLevel(string brand, string model, string licenseNumber)
        {

            Vehicle vehicle = new(brand, model, licenseNumber);

            
            Garage garage = new(2);


            garage.AddVehicle(vehicle);
            garage.DriveVehicle(licenseNumber, 50, false);

            garage.DriveVehicle(licenseNumber, 100, false);
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        [TestCase("Mazda", "3", "wfw3fwf")]
        public void RepairVehiclesShouldWorkProperly(string brand, string model, string licenceNumber)
        {
            //Vehicle vehicle = new(brand, model, licenceNumber);
            Vehicle vehicle1 = new(brand, model, licenceNumber);

            Garage garage = new(3);

            //garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);

            garage.DriveVehicle(licenceNumber, 50, true);

            string expectedMessage = $"Vehicles repaired: {1}";

            Assert.AreEqual(expectedMessage, garage.RepairVehicles());
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        [TestCase("Mazda", "3", "wfw3fwf")]
        public void RepairVehiclesShouldReturnIfNoCarIsRepaired(string brand, string model, string licenceNumber)
        {
            //Vehicle vehicle = new(brand, model, licenceNumber);
            Vehicle vehicle1 = new(brand, model, licenceNumber);

            Garage garage = new(3);

            //garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);

            //garage.DriveVehicle(licenceNumber, 50, false);

            string expectedMessage = $"Vehicles repaired: {0}";

            Assert.AreEqual(expectedMessage, garage.RepairVehicles());
        }

        [TestCase("Ford", "Mustang", "wuwhfhuwe")]
        [TestCase("Mazda", "3", "wfw3fwf")]
        public void RepairVehicleSouldSetIsDamagedToFalse(string brand, string model, string licenceNumber)
        {
            //Vehicle vehicle = new(brand, model, licenceNumber);
            Vehicle vehicle1 = new(brand, model, licenceNumber);

            Garage garage = new(3);

            //garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);

            garage.DriveVehicle(licenceNumber, 50, false);

            //string expectedMessage = $"Vehicles repaired: {1}";

            Assert.IsFalse(vehicle1.IsDamaged);
        }

        public void RepairVehicleShouldIncreaseVehicleReparedCount(string brand, string model, string licenceNumber)
        {
            Vehicle vehicle = new("Ford", "Mustang", "wuwhfhuwe");
            Vehicle vehicle1 = new("Mazda", "3", "wfw3fwf");

            Garage garage = new(3);

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);

            garage.DriveVehicle("wuwhfhuwe", 50, true);
            garage.DriveVehicle("wfw3fwf", 50, true);

            string expectedMessage = $"Vehicles repaired: {1}";

            Assert.AreEqual(expectedMessage, garage.RepairVehicles());
        }
    }
}
