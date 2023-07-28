using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var factory = new Factory("Ivan", 20);

            string expectedName = "Ivan";
            int expectedCapacity = 20;  

            Assert.AreEqual(expectedName, factory.Name);    
            Assert.AreEqual(expectedCapacity, factory.Capacity);
            Assert.NotNull(factory.Robots);
            Assert.NotNull(factory.Supplements);
        }

        [Test]
        public void NamePropertySetterShouldSetTheValueCorrectly()
        {
            var factory = new Factory("Ivan", 20);

            string expectedName = "Ivan";

            Assert.AreEqual(expectedName, factory.Name);
        }

        [Test]
        public void CapacitySetterShouldSettheValueProperly()
        {
            var factory = new Factory("Ivan", 20);

            int expectedCapacity = 20;

            Assert.AreEqual(expectedCapacity, factory.Capacity);    
        }

        [Test]
        public void ProducedRobotShouldAddRobotsToInnerCollection()
        {
            var factory = new Factory("Ivan", 20);

            Robot expectedRobot = new("Terminator", 1000.2341, 24);

            string expectedMessage = $"Produced --> Robot model: {expectedRobot.Model} IS: {expectedRobot.InterfaceStandard}, Price: {expectedRobot.Price:f2}";

            string actualMessage = factory.ProduceRobot("Terminator", 1000.2341, 24);

            Robot actualRobot = factory.Robots.Single();

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void ProduceRobotShouldNotAddRobotToInnerCollectionWhenCapacityLimitIsReached()
        {
            var factory = new Factory("Ivan", 20);
            string expectedMessage = $"The factory is unable to produce more robots for this production day!";

            factory.Capacity = 0;

            string actualMessage = factory.ProduceRobot("Terminator", 1000.2341, 24);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void ProduceSupplemenShouldAddSuplementToInnerCollection()
        {
            var factory = new Factory("Ivan", 20);

            Supplement expectedSupplement = new("Laser", 25);

            string expectedMessage = $"Supplement: {expectedSupplement.Name} IS: {expectedSupplement.InterfaceStandard}";

            string actualMessage = factory.ProduceSupplement(expectedSupplement.Name, expectedSupplement.InterfaceStandard);

            Supplement actualSupplement = factory.Supplements.Single();

            Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UpgradeRobotShouldAddSupplementAndReturnTrue()
        {
            var factory = new Factory("Ivan", 20);

            Robot robot = new("Terminator", 1000.2341, 25);

            Supplement expectedSupplement = new("Laser", 25);

            bool actualResult = factory.UpgradeRobot(robot, expectedSupplement);

            Supplement actualSuplement = robot.Supplements.Single();

            Assert.True(actualResult);
            Assert.AreEqual(expectedSupplement.Name, actualSuplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSuplement.InterfaceStandard);
        }

        [TestCase]
        public void UpgradeRobotShouldNotAddSupplementAndReturnFalseWhenSupplementAlreadyAdded()
        {
            var factory = new Factory("Ivan", 20);
            Robot robot = new("Terminator", 1000.2341, 25);

            Supplement expectedSupplement = new("Laser", 25);

            _ = factory.UpgradeRobot(robot, expectedSupplement);
            bool expectedResult = factory.UpgradeRobot(robot, expectedSupplement);

            Assert.False(expectedResult);
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [TestCase]
        public void UpgradeRobotShouldNotAddSupplementAndReturnFalseWhenInterfaceStandardsDoesNotMatch()
        {
            var factory = new Factory("Ivan", 20);

            int interfaceStandard = 24;

            Robot robot = new("Terminator", 1000.2341, interfaceStandard);

            Supplement expectedSupplement = new("Laser", interfaceStandard + 1);

            bool expectedResult = factory.UpgradeRobot(robot, expectedSupplement);

            Assert.False(expectedResult);
        }

        [TestCase]
        public void SellRobotShouldReturnCorrectRobot()
        {
            var factory = new Factory("Ivan", 20);

            Robot expectedRobot = new("Terminator", 700, 24);

            _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            _ = factory.ProduceRobot("Terminator2", 1000, 25);
            _ = factory.ProduceRobot("Terminator3", 500, 26);


            Robot actualRobot = factory.SellRobot(800);

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
        }

        [Test]
        public void SellRobotShouldReturnNullIfPriceIsTooLow()
        {
            var factory = new Factory("Ivan", 20);

            Robot expectedRobot = new("Terminator", 700, 24);

            _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            _ = factory.ProduceRobot("Terminator2", 1000, 25);
            _ = factory.ProduceRobot("Terminator3", 500, 26);

            Robot actualRobot = factory.SellRobot(20);

            Assert.Null(actualRobot);
        }

        [Test]
        public void SellRobotShouldReturnNullIfRobotsCollectionIsEmpty()
        {
            var factory = new Factory("Ivan", 20);

            Robot actualRobot = factory.SellRobot(20);

            Assert.Null(actualRobot);
        }
    }
}
