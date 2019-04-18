using System;

namespace Delegates
{
    class Delegates
    {
        public delegate string BinaryOperator(int x, int y);

        static void Main(string[] args)
        {
            Console.WriteLine(Calculator(4, 5, Multiply));
            Console.WriteLine(Calculator(4, 5, Add));
            Console.WriteLine(Calculator(5, 5, IsGreater));
            Console.WriteLine(Calculator(4, 10, IsGreater));
        }

        public static string Calculator(int x, int y, BinaryOperator opr)
        {
            return opr(x, y);
        }

        public static string Multiply(int x, int y)
        {
            return (x * y).ToString();
        }

        public static string Add(int x, int y)
        {
            return (x + y).ToString();
        }

        public static string IsGreater(int z, int m)
        {
            return (z > m).ToString();
        }
    }
}
