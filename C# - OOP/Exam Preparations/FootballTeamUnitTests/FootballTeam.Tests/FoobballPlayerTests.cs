using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class FootballPlayerTests
    {
        private FootballPlayer player;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Ronaldo", 7, "Forward");
        }

        [Test]
        public void ConstructorShouldInitializePropertiesCorrectly()
        {
            string expectedName = "Ronaldo";
            int expectedNumber = 7;
            string expectedPossition = "Forward";

            Assert.AreEqual(expectedName, player.Name);
            Assert.AreEqual(expectedNumber, player.PlayerNumber);
            Assert.AreEqual(expectedPossition, player.Position);
        }

        [Test]
        public void ConstructorShouldSetSkoredGoalsToZeroAsDefault()
        {
            int expedtedResult = 0;

            Assert.AreEqual(expedtedResult, player.ScoredGoals);
        }

        [Test]
        public void NamePropertyShouldWorkProperly()
        {
            string expectedName = "Ronaldo";
            Assert.AreEqual(expectedName, player.Name);
        }

        [Test]
        public void PlayerNumberPropertyShouldWorkProperly()
        {
            int expectedNumber = 7;
            Assert.AreEqual(expectedNumber, player.PlayerNumber);
        }

        [Test]
        public void PositionPropertyShouldWorkProperly()
        {
            string expectedPossition = "Forward";
            Assert.AreEqual(expectedPossition, player.Position);
        }

        [Test]
        public void ScoredGoalsShouldBeZeroAsDefault()
        {
            int expedtedResult = 0;

            Assert.AreEqual(expedtedResult, player.ScoredGoals);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NamePropertyShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            string expedtedMessage = "Name cannot be null or empty!";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => player = new FootballPlayer(name, 6, "Back"));

            Assert.AreEqual(expedtedMessage, ex.Message);
        }

        [TestCase(0)]
        [TestCase(22)]
        public void PlayerNumberShouldThrowExceptionIfNameIsLessThan1AndMoreThan21(int number)
        {
            string expectedMessage = "Player number must be in range [1,21]";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => player = new FootballPlayer("Ronaldo", number, "Midfielder"));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [TestCase("Back")]
        [TestCase("Half")]
        [TestCase(null)]
        public void PositionPropertyShouldThrowExceptionIfPositionIsInvalid(string position)
        {
            string expectedMessage = "Invalid Position";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => new FootballPlayer("ronaldo", 5, position));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void ScoreMethodShouldIncreaseScoredGoals()
        {
            int expectedResult = 3;
            player.Score();
            player.Score();
            player.Score();

            Assert.AreEqual(expectedResult, player.ScoredGoals);
        }
    }
}