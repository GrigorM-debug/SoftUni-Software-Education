namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 2;

            Warrior warrior = new Warrior("Ivan", 50, 100);
            Warrior warrior1 = new Warrior("Gosho", 40, 100);

            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.AreEqual(expectedResult, arena.Count);   
        }

        [Test]
        public void ArenaEnrollShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]  
        public void ArenaEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new Warrior("Ivan", 50, 100);

            arena.Enroll(warrior);
            
            string expectedMessage = "Warrior is already enrolled for the fights!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException> (() => arena.Enroll(warrior));

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void FightMethodShouldWorkCorrectly()
        {
            Warrior attacker = new Warrior("Ivan", 10, 100);
            Warrior defender = new Warrior("Pesho", 5, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 90;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);

            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void FightMethodShouldThrowExceptionIdAttackerNameIsNotFound()
        {
            Warrior attacker = new Warrior("Gosho", 10, 100);
            Warrior defender = new Warrior("Pesho", 10, 100);

            arena.Enroll(defender);

            string expectedMessage = $"There is no fighter with name {attacker.Name} enrolled for the fights!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfDefenderNameIsNotFound()
        {
            Warrior attacker = new Warrior("Gosho", 10, 100);
            Warrior defender = new Warrior("Pesho", 10, 100);

            arena.Enroll(attacker);

            string expectedMessage = $"There is no fighter with name {defender.Name} enrolled for the fights!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }
}
