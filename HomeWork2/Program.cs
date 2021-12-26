using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    class Program
    { 
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            string name;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"My name is {Identity().Name} {Identity().Surname}");
            do
            {
                Console.WriteLine("What is your Name (Name and Surname) ? : ");
                name = Console.ReadLine();
                InputParseAndSave(name);
                if (InputParseAndSave(name).Name != null)
                {
                    Console.WriteLine($"Your Name is {InputParseAndSave(name).Name} {InputParseAndSave(name).Surname} ");
                }
                else
                {
                    Console.WriteLine($"Your Name Or Surname is Written Incorrectly : {name}\nIf you wish to Try again press Any Key \nTo Exit Press ESC");
                }
                input = Console.ReadKey();
            }while(input.Key != ConsoleKey.Escape);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static identity InputParseAndSave(string name)
        {
            if (name.Contains(' '))
            {
                string[] nameAndSurname = name.Split(' ');
                return new identity()
                {
                    Name = nameAndSurname[0],
                    Surname = nameAndSurname[1]
                };
            }
            else
            {
                return new identity()
                {
                    Name = null,
                    Surname = null
                };
            }
        }
        public static identity Identity()
        {
            return new identity()
            {
                Name = "Mikheil",
                Surname = "Chkhvirkia"
            };
        }
    }
}
