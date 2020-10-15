using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadTxtFile("a.txt"));
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
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ConstraintException e)
            {
                Console.WriteLine(e.Message);
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
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ConstraintException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string ReadTxtFile(string fileName)
        {
            string result = "";
            try
            {
                if (fileName.Length < 4)
                {
                    throw new InvalidOperationException("Filename is too short to be a complete filename");
                }
                if(fileName[fileName.Length - 4] != '.' || fileName[fileName.Length - 3] != 't' || fileName[fileName.Length - 2] != 'x' || fileName[fileName.Length - 1] != 't')
                {
                    throw new InvalidOperationException("File is not a .txt file");
                }
                if (!File.Exists(fileName))
                {
                    throw new InvalidOperationException("File does not exist in current directory");
                }
                StreamReader fileStr = File.OpenText(fileName);
                string nextLine;
                do
                {
                    nextLine = fileStr.ReadLine();
                    if(nextLine != "" && nextLine != "\n" && nextLine != null)
                    {
                        result += nextLine + "\n";
                    }
                } while (nextLine != "" && nextLine != "\n" && nextLine != null);

            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }


    }
}
