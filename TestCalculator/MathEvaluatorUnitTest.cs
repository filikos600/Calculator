using Calculator.Presenter;
using Moq;

namespace TestCalculator
{
    [TestFixture]
    public class MathEvaluatorUnitTest
    {
        private MathEvaluator mathEvaluator;

        [SetUp]
        public void Setup()
        {
            var mockDB = new Mock<IDatabaseManager>();
            mathEvaluator = new MathEvaluator(mockDB.Object);
        }

        [Test]
        public void ShunningYardTest()
        {
            var tokens = new List<string>() { "3", "+", "4", "x", "", "(", "2", "-", "1", ")" };
            var expected = new List<string> { "3", "4", "2", "1", "-", "x", "+" };
            var results = mathEvaluator.ShuntingYardAlgorithm(tokens);
            Assert.That(results, Is.EqualTo(expected));

            tokens = new List<string>() { "3", "+", "4", "x", "2", "÷", "(", "1", "-", "5", ")", "^", "2", "^", "3" };
            expected = new List<string> { "3", "4", "2", "x", "1", "5", "-", "2", "3", "^", "^", "÷", "+" };
            results = mathEvaluator.ShuntingYardAlgorithm(tokens);
            Assert.That(results, Is.EqualTo(expected));

            tokens = new List<string>() { "√", "(", "5", "-", "1", ")", "x", "!", "(", "3", ")", "-", "5" };
            expected = new List<string>() { "5", "1", "-", "√", "3", "!", "x", "5", "-" };
            results = mathEvaluator.ShuntingYardAlgorithm(tokens);
            Assert.That(results, Is.EqualTo(expected));
        }

        [Test]
        public async Task EvaluateTest()
        {
            var input = "4!x(2,5-10)";
            double expected = 180d;
            var result =await mathEvaluator.Evaluate(input);
            Assert.That(result, Is.EqualTo(expected).Within(1e-5));


            input = "(4-1)!-1,5*0";
            expected = 0d;
            result = await mathEvaluator.Evaluate(input);
            Assert.That(result, Is.EqualTo(expected).Within(1e-5));

        }
    }
}
