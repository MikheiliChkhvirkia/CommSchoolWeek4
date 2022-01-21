using System;
using System.Collections.Generic;
using System.Linq;

namespace Week7Homework
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //HomeWork1();
            //HomeWork2();
            //HomeWork3();
            //HomeWork4();
            //HomeWork5();
            HomeWork6();
        }
        #region HomeWork1
        static void HomeWork1()
        {
            Console.Write("Write Circle Radius : ");
            int input = Convert.ToInt32(Console.ReadLine());
            var result1 = (Math.Pow((input * 2), 2)) / 2;
            var result2 = Math.Pow((input * 2), 2);
            Console.WriteLine((int)result2 - result1);
            Console.Write("");
        }
        #endregion

        #region HomeWork2
        static void HomeWork2()
        {
            Console.WriteLine("Jackpot\n");
            bool win = false;
            int attemptTry = 0;
            while (win != true)
            {

                int length = Randomizer();

                string result = " ";

                char incomeChar = ' ', firstChar = ' ';

                int counter = 0;
                string input = " ";
                if (attemptTry >= 3)
                {
                    attemptTry = 0;
                    Console.Write("Sick of losing? Try 100% win chance (Y/N) : ");

                    input = Console.ReadLine();
                    Console.WriteLine(" ");
                }

                Random rnd = new Random();

                int random = rnd.Next(0, 5);

                if (input.ToLower() == "y")
                {
                    for (int i = 0; i < length; i++)
                    {
                        incomeChar = Win(random);

                        if (i == 0)
                            firstChar = incomeChar;

                        result += incomeChar;

                        Console.Write(incomeChar + " ");

                        if (firstChar == incomeChar)
                        {
                            counter++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < length; i++)
                    {
                        incomeChar = RandomSymbol();

                        if (i == 0)
                            firstChar = incomeChar;

                        result += incomeChar;

                        Console.Write(incomeChar + " ");

                        if (firstChar == incomeChar)
                        {
                            counter++;
                        }
                    }
                }
                if (counter == length)
                {
                    win = true;

                    Console.WriteLine("You Won\n");

                    counter = 0;
                }
                else
                {
                    attemptTry++;

                    win = false;

                    Console.WriteLine("You Lose\n");

                    counter = 0;
                }
            }
        }
        static int Randomizer()
        {
            Random rnd = new Random();
            return rnd.Next(3, 10);
        }
        static char RandomSymbol()
        {
            Random rnd = new Random();
            char[] symbols = { '@', '#', '$', '%', '&', '*' };
            return symbols[rnd.Next(0, 5)];
        }
        static char Win(int winSequence)
        {
            char[] symbols = { '@', '#', '$', '%', '&', '*' };
            return symbols[winSequence];
        }
        #endregion

        #region HomeWork3

        static void HomeWork3()
        {
            Console.Write("Input Win : ");
            int Win = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input Draw : ");
            int Draw = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input Lose : ");
            int Lose = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine((Win * 3) + (Draw * 1) + (Lose * 0));
        }

        #endregion

        #region HomeWork4

        static void HomeWork4()
        {
            int[] arr = new int[7];
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Input week work hours for {WeekDays(i)} : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(workHourCalculator(arr));
            
        }
        static string WeekDays(int input)
        {
            string[] array = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            return array[input];
        }
        static int workHourCalculator(int[] arr)
        {
            int result = 0, 
                counter = 0,
                regularSalary = 10,
                overTimeSalary = 15,
                weekendSalary = regularSalary*2;

            for (int i = 0; i < arr.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < arr[i]; j++)
                {
                    
                    counter++;
                    if (i >= 5)
                    {
                        result += weekendSalary;
                        continue;
                    }
                    if (counter <= 8)
                    {
                        result += regularSalary;
                    }
                    else
                    {
                        result += overTimeSalary;
                    }
                    
                }
            }
            return result;
        }
        #endregion

        #region HomeWork5

        static void HomeWork5()
        {
            int[] inputArr = new int[7];
            int changer, progressCounter = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Input daily training hours : ");
                inputArr[i] = Convert.ToInt32(Console.ReadLine());
            }
            changer = inputArr[0];
            for (int i = 0; i < 7; i++)
            {
                if(changer < inputArr[i])
                {
                    changer = inputArr[i];
                    progressCounter++;
                }
            }
            Console.WriteLine($"Progress was in {progressCounter} days");

        }

        #endregion

        #region HomeWork6

        static void HomeWork6()
        {
            int inputLength=0;
            List<string> words = new() { "possibility", "muscle", "syndrome", "bacon", "assume", "wake", "magnetic", "herd", "arrest", "chord", "tree" };

            int rndLength = RandomInt();

            string[] rndWords = new string[rndLength];

            Console.Write("Input Length : ");

            inputLength = Convert.ToInt32(Console.ReadLine());

            Console.Write("Want randomly created words or Meaningfull words? ( R for Random / Press Any Key for meaningfull words ) : ");

            string input = Console.ReadLine();

            if (input.ToLower() == "r")
            {
                for (int i = 0; i < rndLength; i++)
                {
                    rndWords[i] = RandomWords();
                }
                var query = rndWords.Where(x => x.Length == inputLength);

                Console.WriteLine("");

                OutputOfQuery(query);
            }
            else
            {
                var query = words.Where(x => x.Length == inputLength);

                Console.WriteLine("");

                OutputOfQuery(query);
            }
            Output(words, rndWords);
        }
        static void Output(List<string>? words, string[]? rndWords)
        {
            if (words != null && words.Any())
                Console.WriteLine("\nMeaningful words list\n");
                foreach (var item in words)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine("\n");
            if(rndWords != null && rndWords.Any())
                Console.WriteLine("Random words List\n");
                for (int i = 0; i < rndWords.Length; i++)
                {
                    Console.Write(rndWords[i] + ", ");
                }
                Console.WriteLine("\n");
        }
        static void OutputOfQuery(IEnumerable<string> query)
        {
            if (query != null && query.Any())
            {
                foreach (var item in query)
                {
                    Console.Write(item + " ");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.Write("No Elements Were Found");
                Console.WriteLine("");
            }
        }

        static string RandomWords()
        {
            List<char> words = new() 
            { 
                'a', 'b', 'c', 'd', 'e', 
                'f', 'g', 'h', 'i', 'j', 
                'k', 'l', 'm', 'n', 'o', 
                'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 
                'z'
            };
            var returnString="";
            int random = RandomInt();
            for (int i = 0; i < random; i++)
            {
                returnString += words[RandomInt()];
            }
            return returnString;
        }

        static int RandomInt()
        {
            Random random = new Random();

            return random.Next(0, 26);
        }
        #endregion
    }
}
