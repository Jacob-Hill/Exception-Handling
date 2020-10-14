using System;
using System.Collections.Generic;
using System.Data;

namespace Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
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

        static void ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int number;
            try
            {
                if (!(int.TryParse(input, out number)))
                {
                    throw new InvalidCastException("Invalid Format");
                }
                if (!(number > start && number < end))
                {
                    throw new ConstraintException("Number out of Range");
                }
                Console.WriteLine("Number is within range");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid Format");
            }
            catch (ConstraintException)
            {
                Console.WriteLine("Number out of Range");
            }
        }

        static void CheckNumbers(List<int> list)
        {
            try
            {
                if (list.Count != 10)
                {
                    throw new InvalidOperationException("List contains incorrect amount of ints");
                }
                if (list[0] < 1)
                {
                    throw new ConstraintException("First number is less than 1");
                }
                if (list[9] > 100)
                {
                    throw new ConstraintException("Last number is greater than 100");
                }
                for(int a = 1; a<10; a++)
                {
                    if (list[a] < list[a - 1])
                    {
                        throw new ConstraintException("Number is less than previous");
                    }
                }
                Console.WriteLine("List passes conditions");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("List contains incorrect amount of ints");
            }
            catch (ConstraintException)
            {
                Console.WriteLine("Numbers do not fit specifications");
            }
        }
    }
}
