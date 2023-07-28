using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotFactory.Tests
{
    public class RobotTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var robot = new Robot("Terminator", 4000, 30);

            string expectedModel = "Terminator";
            double expectedPrice = 4000;
            int expectedInterfaceStandart = 30;

            Assert.AreEqual(expectedModel, robot.Model);
            Assert.AreEqual(expectedPrice, robot.Price);
            Assert.AreEqual(expectedInterfaceStandart, robot.InterfaceStandard);
            Assert.NotNull(robot.Supplements);
        }

        [Test]
        public void PropertyModelShouldWorkProperly()
        {
            var robot = new Robot("Terminator", 4000, 30);

            string expectedModel = "Terminator";

            Assert.AreEqual(expectedModel, robot.Model);    
        }

        [Test]
        public void PropertyPriceShouldWorkProperly()
        {
            var robot = new Robot("Terminator", 4000, 30);

            double expectedPrice = 4000;

            Assert.AreEqual(expectedPrice, robot.Price);
        }

        [Test]
        public void PropertyInterfaceStandartShouldWorkProperly()
        {
            var robot = new Robot("Terminator", 4000, 30);

            int expectedInterfaceStandart = 30;

            Assert.AreEqual(expectedInterfaceStandart, robot.InterfaceStandard);
        }

        [Test]
        public void OverriteToStringMethodShouldWorkProperly()
        {
            var robot = new Robot("Terminator", 4000, 30);

            string expectedMessage = $"Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}";

            Assert.AreEqual(expectedMessage, robot.ToString()); 
        }
    }
}
