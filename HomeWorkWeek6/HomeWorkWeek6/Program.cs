using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkWeek6
{
    internal class Program
    {
        static void Main()
        {
            ExcerciseFirst();
            ExcerciseSecond();
            ExcerciseThird();
        }
        static void ExcerciseFirst()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exercise First \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Array Length : ");

            int lengthInput = Convert.ToInt32(Console.ReadLine());

            double?[] oddArray = new double?[lengthInput];
            double?[] evenArray = new double?[lengthInput];
            Console.Write("Would you like to input yourself (Y) or computer to input (N)? (Y/N) : ");
            string userInput = Console.ReadLine();
            if (userInput.ToUpper() == "Y")
            {
                for (int i = 0; i < lengthInput; i++)
                {
                    Console.Write("Enter Array Elements : ");
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (input % 2 != 0)
                    {
                        oddArray[i] = input;
                        evenArray[i] = null;
                    }
                    else
                    {
                        evenArray[i] = input;
                        oddArray[i] = null;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lengthInput; i++)
                {
                    var input = Random();
                    if (input % 2 != 0)
                    {
                        oddArray[i] = input;
                        evenArray[i] = null;
                    }
                    else
                    {
                        evenArray[i] = input;
                        oddArray[i] = null;
                    }
                }
            }

            Console.WriteLine("\n");
            Console.Write("Odd  : ");
            foreach (var item in oddArray)
            {
                if (item != null)
                    Console.Write(item + " ");
            }

            Console.WriteLine("\n");
            Console.Write("Even : ");
            foreach (var item in evenArray)
            {
                if (item != null)
                    Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }
        static void ExcerciseSecond()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exercise Second \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Array Length : ");

            int listLength = Convert.ToInt32(Console.ReadLine());

            List<int> array = new();

            Console.Write("Would you like to input yourself (Y) or computer to input (N)? (Y/N) : ");
            string userInput = Console.ReadLine();
            if (userInput.ToUpper() == "Y")
            {
                for (int i = 0; i < listLength; i++)
                {
                    Console.Write("Enter Array Elements : ");
                    array.Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
            else
            {
                for (int i = 0; i < listLength; i++)
                {
                    array.Add(Random());
                }
            }

            var query = array.GroupBy(x => x)
                .Select(x => new {
                    Char = x.Key,
                    Count = x.Count()
                });

            foreach (var listItem in query)
            {
                Console.WriteLine($"{listItem.Char} was {listItem.Count}");
            }
            Console.WriteLine("\n");
        }
        static void ExcerciseThird()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exercise Third \n");
            Console.ForegroundColor = ConsoleColor.White;
            List<int> array = new();

            Console.Write($"How long you want Array to be? : ");

            var arrayLength = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < arrayLength; i++)
            {
                array.Add(Random());
            }

            Console.Write($"How many top numbers you want to see? (Max - {arrayLength} : Min - 1) : ");

            var userInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n");

            Console.Write("Show Array         : "); 

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n");

            Console.Write("Show Ordered Array : ");

            var queryOrdered = array.OrderBy(x => x);

            foreach (var item in queryOrdered)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n");

            Console.Write("Show Result        : ");
            if (userInput != 0)
            {

                var query = array.OrderBy(x => x).Skip(array.Count - userInput);

                foreach (var item in query)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.Write("You Chose not to see any =) ");
            }
            Console.WriteLine("");
        }

        static int Random()
        {
            Random rnd = new();
            return rnd.Next(-101, 101);
        }

    }
}
