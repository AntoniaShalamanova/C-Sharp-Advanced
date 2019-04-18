using System;

namespace GenericDelegates
{
    class GenericDelegates
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator(4, 5, Multiply));
            Console.WriteLine(Calculator(4, 5, Add));
            Console.WriteLine(Calculator(5, 5, IsGreater));
            Console.WriteLine(Calculator(4, 10, IsGreater));
        }

        public static int WrongFunction(int x, int y)
        {
            return x + y;
        }

        public static string Calculator(int x, int y, Func<int, int, string> opr)
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

        public static string IsGreater(int x, int y)
        {
            return (x > y).ToString();
        }
    }

}
