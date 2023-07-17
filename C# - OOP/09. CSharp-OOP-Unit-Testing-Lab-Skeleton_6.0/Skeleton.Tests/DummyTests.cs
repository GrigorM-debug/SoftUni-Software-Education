using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyConstructorShouldInitializeWithCorrectValues()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.AreEqual(100, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldDecriseHealth()
        {
            Dummy dummy= new Dummy(10, 100);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldThrowException()
        {
            Dummy dummy= new Dummy(10, 100);

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10), "Dummy is dead.");
        }

        [Test]
        public void GiveExperienceMethodShouldThrowExceptionIfDummyIsNotDead()
        {
            Dummy dummy= new Dummy(10, 100);

            dummy.TakeAttack(5);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }

        [Test]
        public void GiveExperienceMethodShouldReturnXPIfDummyIsDead()
        {
            Dummy dummy= new Dummy(10, 100);

            dummy.TakeAttack(10);

            Assert.AreEqual(100, dummy.GiveExperience());
        }
    }
}