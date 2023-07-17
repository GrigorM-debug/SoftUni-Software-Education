using NUnit.Framework;
using System;
using System.Reflection.Metadata;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeContructorShouldInitializeWithCorrectValues()
        {
            Axe axe = new Axe(100, 100);

            Assert.AreEqual(axe.DurabilityPoints, 100);
            Assert.AreEqual(axe.AttackPoints, 100);
        }

        [Test]
        public void AxeLosesDurabilityPoints()
        {
            Axe axe = new Axe(10,  10);
            Dummy dummy = new Dummy(100, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttactWithBrokenAxeAttactMethodShowThrowException()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy= new Dummy(100, 10);

            for(int i = 0 ; i < 10; i++)
            {
                axe.Attack(dummy);
            }

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }
    }
}