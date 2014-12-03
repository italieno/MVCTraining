using MVCTraining.Web.Core.Constants;
using MVCTraining.Web.Infra.Services;
using NUnit.Framework;

namespace MVCTraining.Web.Unit.Test.Services
{
    [TestFixture]
    public class FizzBuzzServiceTest
    {
        private IFizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Given_A_FizzBuzzService()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Test]
        public void It_Should_Return_A_String()
        {
            var result = _fizzBuzzService.GetAnwser(2);
            Assert.IsTrue(result is string);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void It_Should_Return_Fizz_If_Number_Provided_Can_Be_Divided_By_3(int inputNumber)
        {
            var result = _fizzBuzzService.GetAnwser(inputNumber);
            Assert.IsTrue(result == FizzBuzzConstants.Answer.Fizz.ToString());
        }


        [TestCase(5)]
        [TestCase(10)]
        public void It_Should_Return_Buzz_If_Number_Provided_Can_Be_Divided_By_5(int inputNumber)
        {
            var result = _fizzBuzzService.GetAnwser(inputNumber);
            Assert.IsTrue(result == FizzBuzzConstants.Answer.Buzz.ToString());
        }

        [TestCase(15)]
        [TestCase(30)]
        public void It_Should_Return_FizzBuzz_If_Number_Provided_Can_Be_Divided_By_5_and_3(int inputNumber)
        {
            var result = _fizzBuzzService.GetAnwser(inputNumber);
            Assert.IsTrue(result == FizzBuzzConstants.Answer.FizzBuzz.ToString());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void It_Should_Return_String_Empty_If_Number_Provided_Cant_Be_Divided_By_3_Or_5(int inputNumber)
        {
            var result = _fizzBuzzService.GetAnwser(inputNumber);
            Assert.IsTrue(result == string.Empty);
        }


    }
}
