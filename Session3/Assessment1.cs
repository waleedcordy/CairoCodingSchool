using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session3
{
    public class Assessment1
    {
        //Assessment#1
        //Represent a Seating Chart in a Movie Theater
        //Use a 2D array to represent a movie theater seating chart
        //where: 1 = available seat, 0 = booked seat
        //You have a seating arrangement with 4 rows and 4 seats per row.
        //Steps:
        //Take input from the user for row and column numbers.
        //Validate that the provided row and column numbers are within the valid range
        //(i.e., between 0 and 3 for both rows and columns).
        //Check availability of the seat:
        //If the seat is available(value is 1), book it(set the seat to 0).
        //If the seat is already booked(value is 0), prompt the user to
        //enter new row and column numbers with a clear message
        //explaining why it needs to be entered again.
        public Assessment1()
        {
            int[,] Seats = new int[4, 4];

            Console.WriteLine("Default Setting :");
            InitializeSetting(Seats);
            ShowCurrentSetting(Seats);
            Console.WriteLine("Please enter row and column number formatted (row,column)");

            
            while (true)
            {
                bool correctFormat = false;
                int selectedRow = -1, selectedCol = -1;
                string line = Console.ReadLine();
                if (line.Length > 0 && line.Split(",").Count() == 2)
                {
                    string[] splits = line.Split(",");
                    for (int i = 0; i < splits.Length; i++)
                    {
                        if (int.TryParse(splits[i], out int result))
                        {
                            if (i == 0) // row
                                selectedRow = result;
                            else //column
                                selectedCol = result;
                        }

                       
                    }

                    if (selectedRow >= 0 && selectedRow < 4 && selectedCol >= 0 && selectedCol < 4)
                    {
                        correctFormat = true;
                        if (Seats[selectedRow, selectedCol] == 1)
                        { 
                            //The seat is available
                            Seats[selectedRow, selectedCol] = 0; // Mark the seat as booked
                            ShowCurrentSetting(Seats);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("The seat is already booked. Please enter new row and column numbers.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid row or column number. Please enter numbers between 0 and 3.");
                    }
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }
        public static void ShowCurrentSetting(int[,] seats)
        {
            for (int rows = 0; rows < seats.GetLength(0); rows++)
            {
                for (int cols = 0; cols < seats.GetLength(1); cols++)
                {
                    Console.Write($"[{seats[rows, cols]}] ");
                }
                Console.WriteLine();
            }
        }
        public static void InitializeSetting(int[,] seats)
        {
            for (int rows = 0; rows < seats.GetLength(0); rows++)
            {
                for (int cols = 0; cols < seats.GetLength(1); cols++)
                {
                    seats[rows,cols] = 1; // Mark all seats as available
                }
            }
        }
    }


}