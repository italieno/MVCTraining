using MVCTraining.Web.Core.Constants;
using MVCTraining.Web.Unit.Test.Services;

namespace MVCTraining.Web.Infra.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
       
        public string GetAnwser(int inputNumber)
        {
            if (inputNumber <= 0) return string.Empty;

            if (inputNumber % 15 == 0)
                return FizzBuzzConstants.Answer.FizzBuzz.ToString();

            if (inputNumber % 3 == 0)
                return FizzBuzzConstants.Answer.Fizz.ToString();

            if (inputNumber % 5 == 0)
                return FizzBuzzConstants.Answer.Buzz.ToString();

            return string.Empty;
        }
    }
}