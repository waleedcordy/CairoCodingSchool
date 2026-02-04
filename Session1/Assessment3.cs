using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Session1
{
    public class Assessment3
    {
        //Assessment3
        //Write a program which takes two numbers from the console and displays the maximum of the two
        public Assessment3()
        {
            decimal number1;
            decimal number2;
            string line;

            Console.WriteLine("Enter first number : ");
            line = Console.ReadLine();
            if (decimal.TryParse(line,out number1) == false)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter second number : ");
             line = Console.ReadLine();
            if (decimal.TryParse(line, out number2) == false)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            if (number1 > number2)
                Console.WriteLine("number1 is greater than number2");
            else if (number2 > number1)
                Console.WriteLine("number2 is greater than number1");
            else
                Console.WriteLine("Both numbers are equal");
        }
    }
}