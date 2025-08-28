using Calculator.Presenter;

namespace TestCalculator
{
    [TestFixture]
    public class BasicEvaluator_ShuntingYard
    {
        private MathEvaluator _basicEvaluator;

        [SetUp]
        public void Setup()
        {
            _basicEvaluator = new MathEvaluator();
        }

        [Test]
        public void Test1()
        {
            var tokens = new List<string>() { "3", "+", "4", "*", "(", "2", "-", "1", ")" };
            Assert.That(_basicEvaluator.ShuntingYardAlgorithm(tokens), Is.EqualTo("3421-*+"));
        }

        [Test]
        public void Test2()
        {
            var tokens = new List<string>() { "3", "+", "4", "*", "2", "/", "(", "1", "-", "5", ")", "^", "2", "^", "3" };
            Assert.That(_basicEvaluator.ShuntingYardAlgorithm(tokens), Is.EqualTo("342*15-23^^/+"));
        }

        [Test]
        public void Test3()
        {
            var tokens = new List<string>() { "√","(","5","-","1",")","*","3","!","-","5" };
            Assert.That(_basicEvaluator.ShuntingYardAlgorithm(tokens), Is.EqualTo("342*15-23^^/+"));
        }
    }
}
