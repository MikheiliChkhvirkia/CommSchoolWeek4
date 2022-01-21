using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkWeek8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HomeWork1();
            //HomeWork2();
            //HomeWork3();
            HomeWork4();
            //HomeWork5();
        }

        static void HomeWork1()
        {
            Console.WriteLine("* HomeWork 1 *\n");

            int[] inputArray = new int[3];

            int counter = 0;

            for (int i = 0,j=1; i < 3; i++)
            {
                Console.Write("Input Number " + j + " : ");
                inputArray[i]=Convert.ToInt32(Console.ReadLine());
                j++;
            }

            var middleValue = inputArray.FirstOrDefault(x => x != inputArray.Max() && x != inputArray.Min());

            try
            {
                for (int i = inputArray.Min(); i < inputArray.Max(); i++)
                {
                    if(Math.Pow(i, middleValue) <= middleValue)
                    {
                        counter++;
                    }
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("\n"+counter);

        }
        static void HomeWork2()
        {
            Console.WriteLine("* HomeWork 2 *\n");

            Console.Write("Input String : ");

            string inputString = Console.ReadLine().ToUpper();

            List<char> repeatedCharacters = new ();

            var groupsOfChars = inputString.GroupBy(x => x);

            int result = 0;

            groupsOfChars.ToList().ForEach(x =>
            {
                if (x.Count() > 1)
                {
                    if (x.Count() % 2 == 1)
                    {
                        result += (x.Count() - 1) / 2;
                    }
                    else
                    {
                        result += x.Count()/2;
                    }
                    repeatedCharacters.Add(x.Key);
                }
            });
            foreach (var item in repeatedCharacters)
            {
                Console.Write("\n"+item+" ");
            }

            if (result != 0) 
            { 
                Console.WriteLine("\n"+result);
            }
            else
            {
                Console.WriteLine("\n No Pair Found");
            }
            

        }

        static void HomeWork3()
        {
            Console.WriteLine("* HomeWork 3 *\n");

            string FirstInputString = " ";
            string SecondInputString = " ";

            List<char> repeatedchar = new();

            for (int i = 0,j=0; i < 2; i++)
            {
                Console.Write("Input String "+j+" : ");
                if (i == 0)
                {
                    FirstInputString = Console.ReadLine();
                }
                else
                {
                    SecondInputString = Console.ReadLine();
                }
                j++;
            }
            List<string> diff;
            IEnumerable<string> set1 = FirstInputString.Split(' ').Distinct();
            IEnumerable<string> set2 = SecondInputString.Split(' ').Distinct();

            if (set2.Count() > set1.Count())
            {
                diff = set2.Except(set1).ToList();
            }
            else
            {
                diff = set1.Except(set2).ToList();
            }
            foreach (var item in diff)
            {
                Console.WriteLine("\n"+ item + " ");
            }


        }

        static void HomeWork4()
        {
            Console.WriteLine("* HomeWork 4 *\n");

            var obj = new List<string>() {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
            var obj1 = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };
            var obj2 = new List<bool>() { true, false, true, false, false, false, true, true, true};

            OverloadList(obj);
            OverloadList(obj1);
            OverloadList(obj2);
        }

        static void OverloadList(List<string> x)
        {
            foreach (var item in x)
            {
                Console.WriteLine(item.ToUpper());
            }
        }
        static void OverloadList(List<int> x)
        {
            int result = 0;

            foreach (var item in x)
            {
                result += item;
            }
            Console.WriteLine(result);

        }
        static void OverloadList(List<bool> x)
        {
            var middleIndex = x.Count() / 2;
            if (x.Count() % 2 == 0)
            {
                
                Console.WriteLine($"First : {x.First()}\nSecond : {x.Last()}\nMiddle : {x.ElementAt(middleIndex)}");
            }
            else
            {
                Console.WriteLine($"First : {x.First()}\nSecond : {x.Last()}\nMiddles are : {x.ElementAt(middleIndex)} - {x.ElementAt(middleIndex+1)}");
            }
            
        }

        static void HomeWork5()
        {
            Console.WriteLine("* HomeWork 5 *\n");
            Console.Write("Input : ");
            string inputString = Console.ReadLine();

            char[] toCharArr = inputString.ToCharArray();

            for (int i = 0; i < toCharArr.Length; i++)
            {
                if (toCharArr[i] != ' ')  
                    if (i < toCharArr.Length - 1)
                        Console.Write($"{toCharArr[i]} - ");
                    else
                        Console.Write($"{toCharArr[i]} ;");
                else
                    Console.Write($" ");
            }
        }
    }
}
