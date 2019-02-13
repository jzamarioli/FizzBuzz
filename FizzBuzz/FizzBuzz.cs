using System.IO;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public string GetFizzBuzz(int n)
        {
            if (n<1 || n > 100)
                throw new InvalidDataException("The request number should be between 1 and 100");

            string result=string.Empty;

            if (n % 3 == 0 && n % 5 == 0)
                result = "FizzBuzz";
            else if (n % 3 == 0)
                result = "Fizz";
            else if (n % 5 == 0)
                result = "Buzz";
            else
                result = n.ToString();

            return result;
        }
    }
}
