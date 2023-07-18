namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Globalization;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorConstructorShouldInitializeCorrectly()
        {

            string expectedName = "Ivan";
            int expectedDamage = 30;
            int expectedHP = 100;

            Warrior warrior = new(expectedName, expectedDamage, expectedHP);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("         ")]
        public void WarriorConstructorShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior(name, 20, 100));

            string expectedMessage = "Name should not be empty or whitespace!";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void WarriorConstructorShouldThrowExceptionIfDamageIsNotPositive(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Ivan", damage, 100));

            string expectedMessage = "Damage value should be positive!";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase(-3)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void WarriorConstructorShouldThrowExceptionIfHPIsNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 30, hp));

            string expectedMessage = "HP should not be negative!";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAttackerHp = 95;
            int expectedDefenderHP = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            int expectedDefenderHp = 0;

            Warrior attacker = new Warrior("Pesho", 80, 100);
            Warrior defender = new Warrior("Gosho", 5, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        public void AttackMethodShouldThrowExceptionIfAttackeerHPIs30OrBelow(int hp)
        {
            Warrior attacker = new Warrior("Ivan", 40, hp);
            Warrior defender = new Warrior("Pesho", 20, 100);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));

            string expectedMessage = "Your HP is too low in order to attack other warriors!";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        public void AttackMethodShouldThrowExceptionIfEnemyHPIs30OrBelow(int hp)
        {
            Warrior attacker = new Warrior("Ivan", 40, 100);
            Warrior defender = new Warrior("Pesho", 20, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));

            string expectedMessage = "Enemy HP must be greater than 30 in order to attack him!";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void AttackMethodShouldThrowExcptionIfYouTryToAttackTooStrongEnemy()
        {
            Warrior attacker = new Warrior("Ivan", 40, 40);
            Warrior defender = new Warrior("Pesho", 60, 100);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));

            string expectedMessage = "You are trying to attack too strong enemy";

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}