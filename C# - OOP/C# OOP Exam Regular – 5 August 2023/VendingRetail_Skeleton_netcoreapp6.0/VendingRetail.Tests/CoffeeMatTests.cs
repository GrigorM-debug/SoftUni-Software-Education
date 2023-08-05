using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class CoffeeMatTest
    {
        private CoffeeMat coffee;

        [SetUp]
        public void Setup()
        {
            coffee = new CoffeeMat(200, 3);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Assert.AreEqual(200, coffee.WaterCapacity);
            Assert.AreEqual(3, coffee.ButtonsCount);
            Assert.AreEqual(0, coffee.Income);
        }

        [Test]
        public void WaterCapacityShouldWorkProperly()
        {
            Assert.AreEqual(200, coffee.WaterCapacity);
        }

        [Test]
        public void ButtonsCountShouldWorkProperly()
        {
            Assert.AreEqual(3, coffee.ButtonsCount);
        }

        [Test]
        public void IncomeShouldWorkProperly()
        {
            Assert.AreEqual(0, coffee.Income);
        }

        [Test]
        public void FillWaterTankShouldWorkProperly()
        {
            string result = $"Water tank is filled with {200}ml";

            Assert.AreEqual(result, coffee.FillWaterTank());
        }

        [Test]
        public void FillWaterShouldDoNothingIfTankIsAlreadyWfilled()
        {
            string result = $"Water tank is already full!";

            coffee.FillWaterTank();
            coffee.FillWaterTank();

            Assert.AreEqual(result, coffee.FillWaterTank());
        }

        [Test]
        public void AddDrinkShouldReturnTrueIfDrinkIsAdded()
        {
            //coffee.AddDrink("Pepsi", 20);

            Assert.IsTrue(coffee.AddDrink("Pepsi", 20));
        }

        [Test]
        public void AddDrinkShouldReturnFalseIfDrinkIsNotAdded()
        {
            var coffe = new CoffeeMat(200, 1);
            
            coffe.AddDrink("Cola", 20);

            Assert.IsFalse(coffe.AddDrink("wxwx", 20));
        }

        [Test]
        public void AddDrinkShouldReturnFalseIfThereIsAlreadyDrinkWithTheGivenName()
        {
            coffee.AddDrink("Cola", 20);
            Assert.IsFalse(coffee.AddDrink("Cola", 20));
        }

        [Test]
        public void BuyDrinkShouldWorkProperly()
        {
            coffee.AddDrink("Cola", 20);
            coffee.FillWaterTank();
            string result = $"Your bill is {20:f2}$";

            Assert.AreEqual(result, coffee.BuyDrink("Cola"));
        }

        [Test]
        public void BuyDrinkShouldInCreaseTheIncome()
        {
            coffee.AddDrink("Cola", 20);
            coffee.FillWaterTank();
            double result = 20;
            coffee.BuyDrink("Cola");
            Assert.AreEqual(result, coffee.Income);
        }

        [Test]
        public void BuyDrinkShouldReturnMessageIfNoDrinkIsFound()
        {
            coffee.AddDrink("Cola", 20);
            coffee.FillWaterTank();
            string result = "burgr is not available!";

            Assert.AreEqual(result, coffee.BuyDrink("burgr"));
        }

        [Test]
        public void BuyDrinkShouldNotWorkIfWatertankLevelIsUnder80()
        {
            coffee.AddDrink("Cola", 20);
            //coffee.FillWaterTank();
            string result = "CoffeeMat is out of water!";

            Assert.AreEqual(result, coffee.BuyDrink("Cola"));
        }

        [Test]
        public void CollectionIncomeShouldReturnIncome()
        {
            coffee.AddDrink("Cola", 20);
            coffee.FillWaterTank();

            coffee.BuyDrink("Cola");

            Assert.AreEqual(20, coffee.CollectIncome());
        }

        [Test]
        public void CollectionIncomeShouldSetIncometoZero()
        {
            coffee.AddDrink("Cola", 20);
            coffee.FillWaterTank();

            coffee.BuyDrink("Cola");

            coffee.CollectIncome();
            Assert.AreEqual(0, coffee.Income);
        }
    }
}