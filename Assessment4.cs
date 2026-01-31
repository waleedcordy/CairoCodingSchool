using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    public class Assessment4
    {
        //Assessment4
        //Write a program and ask the user to enter a number.The number should be between 1 to 10. If the user enters a valid number, display
        //"Valid" on the console.Otherwise, display "Invalid" .
        //(This logic is used a lot in applications where values entered into input boxes need to be validated.
        public Assessment4()
        {
            int number;
            string line;

            Console.WriteLine("Enter number : ");
            line = Console.ReadLine();
            if (int.TryParse(line, out number) == false)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            if (number >= 1 && number <= 10)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

        }
    }
}