using System.Collections.Generic;
using CsharpBasics.basics;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{

    //use fixture when we want all tests to share same instance instead of creating a new instance for each test.
    public class CalculatorFixture
    {
        public ICalculator Calculator { get; set; }

        public CalculatorFixture()
        {
            Calculator = new Calculator();
        }
    }
    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _fixture;
        public CalculatorTests(CalculatorFixture calculatorFixture)
        {
            _fixture = calculatorFixture;
            _fixture.Calculator.Clear(); // Clear the global variables as the instance is shared among the tests
        }

        [Theory]
        [InlineData(10, 20,30)]
        [InlineData(20, 20, 40)]
        public void add_result_should_be_sum_of_input_params(int a, int b , int result)
        {
            _fixture.Calculator.Add(a,b).ShouldBe(result);
        }

       [Fact]
        public void add_result_should_be_difference_of_given_input()
       {
           _fixture.Calculator.Result.ShouldBe(0);
           _fixture.Calculator.Subtract(20, 10);
           _fixture.Calculator.Result.ShouldBe(10);
       }

        [Theory]
      [MemberData("TestData", MemberType = typeof(CalculatorData))]
        public void multiply_result_should_be_product_of_input_params(int a, int b, int result)
        {
            _fixture.Calculator.Multiply(a, b).ShouldBe(result);
        }
    }

    public class CalculatorData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return  new object[] {5,10,50};
                yield return new object[] { 6, 10, 60 };
                yield return new object[] { 7, 10, 70 };
                yield return new object[] { 8, 10, 80 };
            }
        }
    }
}
