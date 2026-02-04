using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session2
{
    public class Assessment2
    {
        //Assessment#3
        //Write a program and ask the user to enter a number.Compute the
        //factorial of the number and print it on the console.For example, if the
        //user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display
        //it as 5! = 120.
        public Assessment2()
        {
            while (true)
            {
                Console.WriteLine("Enter number :");
                string line = Console.ReadLine();
                int number = 0;
                if (int.TryParse(line, out number) == false)
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                int result = 1;
                for (int i = 1; i < number + 1; i++)
                {
                        result = result * i;
                }

                Console.WriteLine($"{number}! is {result}.");
            }
        }
    }
}