using System;
using System.IO;
using Xunit;
using FluentAssertions;

namespace FizzBuzz.Test
{
    public class FizzBuzzUnitTest: IDisposable
    {
        private FizzBuzz _fizbuzz;

        public FizzBuzzUnitTest()
        {
            _fizbuzz = new FizzBuzz();
        }        

        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(9, "Fizz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(20, "Buzz")]
        [InlineData(30, "FizzBuzz")]
        public void should_match_the_results_above(int number, string result)
        {
            // Act
            var fizzBuzz = _fizbuzz.GetFizzBuzz(number);

            // Assert
            fizzBuzz
            .Should()
            .Be(result);
        }


        [Fact]
        public void should_raise_exception_when_number_is_negative()
        {
            // Arrange
            int number = -10;

            // Act
            Action actionFizzBuzz = () => _fizbuzz.GetFizzBuzz(number);

            // Assert
            actionFizzBuzz
            .Should()
            .Throw<InvalidDataException>()
            .WithMessage("The request number should be between 1 and 100");
        }

        [Fact]
        public void should_raise_exception_when_number_is_greater_than_100()
        {
            // Arrange
            int number = 105;

            // Act
            Action actionFizzBuzz = () => _fizbuzz.GetFizzBuzz(number);

            // Assert
            actionFizzBuzz
            .Should()
            .Throw<InvalidDataException>()
            .WithMessage("The request number should be between 1 and 100");
        }

        [Fact]
        public void should_return_7_ocurrences_of_Fizz()
        {
            // Arrange
            string fizzBuzz = string.Empty;

            // Act
            for (int i=1; i<=21; i++)
            {
                fizzBuzz += _fizbuzz.GetFizzBuzz(i);
            }
            int count = fizzBuzz.Split("Fizz").Length-1;

            // Assert
            count.Should().Be(7);
        }

        public void Dispose()
        {
           _fizbuzz = null;
        }


    }
}
