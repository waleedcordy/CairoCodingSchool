using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Session1
{
   public class Assessment1
    {
        //Assessment1
        //Asks the user to enter two numbers.
        //Asks the user to enter a mathematical operation(+, -,*, or /).
        //2 + 2 , 3+7 …….
        //Performs the selected operation on the two numbers.
        //Displays the result of the calculation.
        //Handles invalid inputs, such as division by zero or entering a nonnumeric value or invalid operation.
        public Assessment1()
        {
            decimal num1 = 0, num2 = 0, result = 0;
            char operation = '0';
            bool num1Parsed = false, num2Parsed = false, operationParsed = false;
            bool isEligible = false;

            while (isEligible == false)
            {
                while (num1Parsed == false)
                {
                    Console.WriteLine("Enter number 1: ");
                    string line = Console.ReadLine();
                    if (decimal.TryParse(line, out num1))
                        num1Parsed = true;
                }

                while (operationParsed == false)
                {
                    Console.WriteLine("Enter Operation: ");
                    string line = Console.ReadLine();
                    if (line.Length == 1 && (line[0] == '/' || line[0] == '*' || line[0] == '-' || line[0] == '+'))
                    {
                        operation = line[0];
                        operationParsed = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operation.");
                    }
                }

                while (num2Parsed == false)
                {
                    Console.WriteLine("Enter number 2: ");
                    string line = Console.ReadLine();
                    if (decimal.TryParse(line, out num2))
                        num2Parsed = true;
                }

                if (IsEligabile(num1, num2, operation))
                {
                    Console.WriteLine("Result :" + Calculate(num1, num2, operation));
                    isEligible = true;
                }
                else
                {
                    //reset
                    num1Parsed = false;
                    num2Parsed = false;
                    operationParsed = false;
                }
            }
        }

        static bool IsEligabile(decimal num1, decimal num2, char operation)
        {
            if (operation == '/' && num2 == 0)
            {
                Console.WriteLine("Error");
                return false;
            }

            return true;
        }

        static decimal Calculate(decimal num1, decimal num2, char operation)
        {
            if (operation == '/')
                return (num1 / num2);
            else if (operation == '*')
                return (num1 * num2);
            else if (operation == '-')
                return (num1 - num2);
            else
                return (num1 + num2);
        }
    }
}