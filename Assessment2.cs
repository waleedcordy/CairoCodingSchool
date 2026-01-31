using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Assessment2
    {
        //Assessment2
        //Asks the user to enter a number.
        //Checks if the number is even or odd using the modulus(%) operator.
        //Displays the result as either "Even" or "Odd"
        public Assessment2()
        {
            decimal number;
            Console.WriteLine("Enter number : ");
            string line = Console.ReadLine();
            if (decimal.TryParse(line,out number) == false)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            if (number % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Odd");

        }
    }
}