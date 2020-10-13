using System;
using System.Data;

namespace Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            SafeSquareRoot(100);
            SafeSquareRoot(-100);
            Console.Read();
        }

        static void SafeSquareRoot(int i)
        {
            if (i < 0)
            {
                Console.WriteLine("Invalid Number");
            }
            else
            {
                Console.WriteLine(Math.Sqrt(i));
            }
            Console.WriteLine("Good Bye");
        }


    }
}
