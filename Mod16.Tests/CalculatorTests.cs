using System;
using NUnit;
using NUnit.Framework;

namespace Mod16.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AdditionalMustReturnCorrectValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(calculator.Additional(10, 20), 30);
        }

        [Test]
        public void SybtructionMustReturnCorrectValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(calculator.Subtraction(5, 2), 3);
        }

        [Test]
        public void MultiplicationMustReturnCorrectValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(calculator.Miltiplication(10, 20), 200);
        }

        [Test]
        public void DivisionMustReturnCorrectValue()
        {
            var calculator = new Calculator();
            Assert.AreEqual(10, calculator.Division(100, 10));
        }

        [Test]
        public void DivisionMustThrow()
        {
            var calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Division(100, 0));
        }
    }
}
