using Calculator.Presenter;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestCalculator
{
    [TestFixture]
    public class ExchangeEvaluatorUnitTest
    {
        private ExchangeEvaluator   exchangeEvaluator;
        [SetUp]
        public void Setup()
        {
            var mockDB = new Mock<IDatabaseManager>();
            exchangeEvaluator = new ExchangeEvaluator(mockDB.Object);
        }

        [Test]
        public void RateTest()
        {
            var expected = 0.86d;
            var result = exchangeEvaluator.Evaluate("1","USD","EUR");
            Assert.That(result, Is.EqualTo(expected).Within(0.01));

            expected = 116.43d;
            result = exchangeEvaluator.Evaluate("100", "EUR", "USD");
            Assert.That(result, Is.EqualTo(expected).Within(0.01));

            expected = 183.7d;
            result = exchangeEvaluator.Evaluate("1", "CHF", "JPY");
            Assert.That(result, Is.EqualTo(expected).Within(0.01));

            expected = 18.88d;
            result = exchangeEvaluator.Evaluate("23,57", "USD", "CHF");
            Assert.That(result, Is.EqualTo(expected).Within(0.01));

            expected = 720417.7d;
            result = exchangeEvaluator.Evaluate("123456789", "JPY", "EUR");
            Assert.That(result, Is.EqualTo(expected).Within(0.01));
        }
    }
}
