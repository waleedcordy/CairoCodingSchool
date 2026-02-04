using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session2
{
    public class Assessment1
    {
        //Assessment#1
        //The program generates a random number between 1 and 100.
        //The user has to guess the number within a certain number of attempts.
        //The program gives hints like "Too high" or "Too low".
        //The game continues until the user guesses correctly or runs out of attempts
         public Assessment1()
        {
            int random = new Random().Next(1, 100);
            int maxAttempts = 5;
            while (maxAttempts > 0)
            {
                Console.WriteLine($"Please enter number (attempts {maxAttempts}):");
                string line = Console.ReadLine();
                maxAttempts--;
                if (int.TryParse(line, out int gussed) == false)
                {
                    Console.WriteLine("Please enter a valid number");
                    maxAttempts++;
                    continue;
                }

                if (gussed == random)
                {
                    Console.WriteLine("Congratulations! You guessed the correct number!");
                    break;
                }
                else if (gussed < random)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine("Too high! Try again.");
                }
            }
        }
    }
}