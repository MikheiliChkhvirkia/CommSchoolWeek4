using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkWeek5
{
    public class InputModel{
        public int FirstInput { get; set; }
        public int SecondInput { get; set; }
    }
    internal class Program
    {
        static void Main()
        {
            Console.Write("Type Two Numbers (Seperate with 'space' example - '5 5' ) : ");
            string inputText = Console.ReadLine();
            if (inputText.Contains(' '))
            {
                string[] parsedString = inputText.Split(' ');
                var saveInput = new InputModel() { 
                    FirstInput=Convert.ToInt32(parsedString[0]),
                    SecondInput=Convert.ToInt32(parsedString[1])
                };
                CanBeDevidedByFive(saveInput);
                Calculator(saveInput);
                ChangePossitions(saveInput);
                Multiplication(saveInput);
                Power(saveInput);
            }
            else
            {
                Console.WriteLine("written incorrectly");
            }
        }
        static void CanBeDevidedByFive(InputModel input) 
        {
            Console.WriteLine("\n* 1 *\n");
            for (int i = 0; i < 2; i++)
            {
                int item;
                if (i == 0)
                {
                    item = input.FirstInput;
                }
                else
                {
                    item = input.SecondInput;
                }
                if(item % 5 == 0)
                {
                    Console.WriteLine($"{item} can be devided by 5 : YES");
                }
                else
                {
                    Console.WriteLine($"{item} can not be devided by 5 : NO");
                }

            }
        }
        static void Calculator(InputModel input)
        {
            Console.WriteLine("\n* 2 *\n");
            Console.WriteLine("First Number + Second Number = " + (input.FirstInput + input.SecondInput));
            Console.WriteLine("First Number * Second Number = " + (input.FirstInput * input.SecondInput));
            if (input.FirstInput > input.SecondInput)
            {
                Console.WriteLine("First Number - Second Number = " + (input.FirstInput - input.SecondInput));
                if (input.FirstInput != 0 || input.SecondInput != 0)
                    Console.WriteLine("First Number / Second Number = " + (input.FirstInput / input.SecondInput));
                else
                    Console.WriteLine("Not Allowed To Divide By Zero");
            }
            else
            {
                Console.WriteLine("Second Number - First Number = " + (input.SecondInput - input.FirstInput));
                if (input.FirstInput != 0 || input.SecondInput != 0)
                    Console.WriteLine("Second Number / First Number = " + (input.SecondInput / input.FirstInput));
                else
                    Console.WriteLine("Not Allowed To Divide By Zero");
            }
        }
        static void ChangePossitions(InputModel input)
        {
            Console.WriteLine("\n* 3 *\n");
            int firstNum = input.FirstInput, 
                secondNum = input.SecondInput;
            Console.WriteLine($"Before Switch First Num = {firstNum}, Second Num = {secondNum}");
            int temp = firstNum;
            firstNum= secondNum;
            secondNum= temp;
            Console.WriteLine($"After Switch First Num = {firstNum}, Second Num = {secondNum}");
            
        }
        static void Multiplication(InputModel input)
        {
            Console.WriteLine("\n* 4 *\n");
            Console.WriteLine(input.FirstInput + "     " + input.SecondInput);
            for (int i = 2; i <= 10; i++)
            {
                Console.WriteLine(input.FirstInput*i + "    " + input.SecondInput*i);
            }
        }
        static void Power(InputModel input)
        {
            Console.Write("\n* 5 *");
            int item;
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("\n");
                if (i == 0)
                    item = input.FirstInput;
                else
                    item = input.SecondInput;
                for (int j = 1; j < item; j++)
                {
                    if(j%2==0)
                        Console.Write(Math.Pow(j,2)+" ");
                }
            }
        }
    }
}
