using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        [Test]
        public void ConstructorShouldSetPropertiesCorrectly()
        {
            var team = new FootballTeam("Nai-dobrite", 20);

            string expectedName = "Nai-dobrite";
            int expectedCapcity = 20;

            Assert.AreEqual(expectedName, team.Name);
            Assert.AreEqual(expectedCapcity, team.Capacity);
            Assert.IsEmpty(team.Players);
        }

        [Test]
        public void NamePropertyShouldWorkProperly()
        {
            var team = new FootballTeam("Nai-dobrite", 20);
            string expectedName = "Nai-dobrite";
            Assert.AreEqual(expectedName, team.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NamePropertyShouldThrowExceptionIsNameIsNullOrEmpty(string name)
        {
            FootballTeam team;

            string expectedMessage = "Name cannot be null or empty!";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => team = new FootballTeam(name, 20));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void CapcityPropertyShouldWorkProperly()
        {
            var team = new FootballTeam("Nai-dobrite", 20);

            Assert.AreEqual(20, team.Capacity);
        }

        [TestCase(14)]
        [TestCase(1)]
        public void CapacityPropertyShouldThrowExceptionIfCapacityIsLessThan15(int capacity)
        {
            FootballTeam team;

            string expectedMessage = "Capacity min value = 15";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => team = new FootballTeam("Nai-dobrite", capacity));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AddPlayerPropertyShouldWorkProperly()
        {
            var team = new FootballTeam("Nai-dobrite", 20);
            var player = new FootballPlayer("Ronaldo", 7, "Forward");

            int expedtedPlayerCount = 1; 
            string expedtedMesage = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";

            //team.AddNewPlayer(player);

            //Assert.AreEqual(expedtedPlayerCount, team.Players.Count);

            Assert.AreEqual(team.AddNewPlayer(player), expedtedMesage);

                Assert.AreEqual(expedtedPlayerCount, team.Players.Count);
        }

        [Test]
        public void AddNewPlayerShouldNotAddNewPlayerIfCapacityIsLessThanPlayersCount()
        {
            var team = new FootballTeam("Nai-dobrite", 15);

            FootballPlayer player;

            for(int i = 0; i< 15; i++)
            {
                team.AddNewPlayer(player = new FootballPlayer("Ivan", i+1, "Forward"));    
            }

            string expedtedMesage = "No more positions available!";

            Assert.AreEqual(expedtedMesage, team.AddNewPlayer(player = new FootballPlayer("Mohamed", 11, "Forward")));
        }

        [Test]
        public void PickPlayerMethodShouldWorkProperly()
        {
            var team = new FootballTeam("Nai-dobrite", 15);
            var player = new FootballPlayer("Ivan", 11, "Forward");
            team.AddNewPlayer(player);

            Assert.AreEqual(player, team.PickPlayer("Ivan"));
        }

        [Test]
        public void PickPlayerShouldReturnNullIfNoPlayerIsFound()
        {
            var team = new FootballTeam("Nai-dobrite", 15);
            Assert.IsNull(team.PickPlayer("Ivan"));
        }

        [Test]
        public void PlayerScoreMethodShouldWorkProperly()
        {
            var team = new FootballTeam("Nai-dobrite", 15);
            var player = new FootballPlayer("Ivan", 11, "Forward");
            team.AddNewPlayer(player);

            string expectedMessage = $"{player.Name} scored and now has {player.ScoredGoals+1} for this season!";

            Assert.AreEqual(expectedMessage, team.PlayerScore(11));
        }

        [Test]
        public void PlayerScoreShouldIncreaseGoals()
        {
            var team = new FootballTeam("Nai-dobrite", 15);
            var player = new FootballPlayer("Ivan", 11, "Forward");
            team.AddNewPlayer(player);
            team.PlayerScore(11);

            int expedtedResult = 1;

            Assert.AreEqual(expedtedResult, player.ScoredGoals);
        }

        //[Test]
        //public void PlayerScoreShouldReturnNullIfNoPlayerIsFound()
        //{
        //    var team = new FootballTeam("Nai-dobrite", 15);
            
        //    Assert.IsNull(team.PlayerScore(6));
        //}
    }
}
