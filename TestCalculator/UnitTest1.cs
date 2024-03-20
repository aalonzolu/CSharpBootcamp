using BootcampCalculator;

namespace TestCalculator
{
    public class CalculatorTests
    {
        [Fact]
        public void AddTest()
        {
            double a = 5;
            double b = 3;
            double expected = 8;
            
            double actual = Calculator.Add(a, b);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SubtractTest()
        {
            double a = 5;
            double b = 3;
            double expected = 2;
            
            double actual = Calculator.Subtract(a, b);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiplyTest()
        {
            double a = 5;
            double b = 3;
            double expected = 15;
            
            double actual = Calculator.Multiply(a, b);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideTest()
        {
            double a = 6;
            double b = 3;
            double expected = 2;
            
            double actual = Calculator.Divide(a, b);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void DivideByZeroTest()
        {
            double a = 6;
            double b = 0;
            
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
        }
        
        [Fact]
        public void NotANumberTest()
        {
            double a = 6;
            double b = double.NaN;
            double expected = double.NaN;
            
            double actual = Calculator.Divide(a, b);
            
            Assert.Equal(expected, actual);
        }
        
    }
}