

namespace CsharpBasics.basics
{
    public interface ICalculator
    {
        int Result { get; set; }
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
        void Clear();
    }

    public class Calculator : ICalculator
    {
        public int Result { get; set; }
        public int Add(int a, int b)
        {
            Result = a + b;
            return Result;
        }

        public int Subtract(int a, int b)
        {
            Result = a - b;
            return Result;
        }

        public int Multiply(int a, int b)
        {
            Result = a * b;
            return Result;
        }

        public int Divide(int a, int b)
        {
            Result = a / b;
            return Result;
        }

        public void Clear()
        {
            Result = 0;
        }
    }
}
