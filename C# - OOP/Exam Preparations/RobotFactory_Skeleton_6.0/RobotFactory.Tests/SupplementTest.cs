using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class SuplementTest
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Supplement supplement = new("Specialist finger", 1);

            string expectedName = "Specialist finger";
            int expectedInterfaceStandart = 1;

            Assert.AreEqual(expectedName, supplement.Name);
            Assert.AreEqual(expectedInterfaceStandart, supplement.InterfaceStandard);
        }

        [Test]
        public void ConstructorShouldSetNameProperly()
        {
            Supplement supplement = new("Specialist arm", 2);

            string expectedName = "Specialist arm";

            Assert.AreEqual(expectedName, supplement.Name);
        }

        [Test]
        public void ConstructorShouldSetInterfaceStandartProperly()
        {
            Supplement supplement = new("Specialist leg", 40);

            int expectedResult = 40;

            Assert.AreEqual(expectedResult, supplement.InterfaceStandard);
        }

        [Test]
        public void NamePropertyShouldWorkProperly()
        {
            Supplement supplement = new("Specialist head", 30);

            string expectedResult = "Specialist head";

            Assert.AreEqual(expectedResult, supplement.Name);
        }

        [Test]
        public void InterfacePropertyShouldWorkProperly()
        {
            Supplement supplement = new("Specialist month", 60);

            int expectedResult = 60;    

            Assert.AreEqual(expectedResult, supplement.InterfaceStandard);
        }

        [Test]
        public void OverritetoStringMethodShouldReturnCorrectMessage()
        {
            Supplement supplement = new("Specialist arm", 40);

            var expectedResult = $"Supplement: {supplement.Name} IS: {supplement.InterfaceStandard}";

            Assert.AreEqual(expectedResult, supplement.ToString());
        }
    }
}