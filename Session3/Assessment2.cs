using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace ConsoleApp1.Session3
{
    public class Assessment2
    {
        //Assessment-Tic-Tac-Toe(XO) Game
        //Create a simple two-player console-based Tic-Tac-Toe(XO) game using C#.
        //The game is played on a 3x3 board. Players take turns marking a cell with X or O.
        //The first to get three marks in a row (vertically, horizontally, or diagonally) wins.
        //If the board is filled with no winner, the game is a draw.
        //Alternate turns between Player X and Player O.
        //Prompt the player to enter their move (row and column).
        //Validate input: Check if the cell is within bounds and not already occupied.
        //Update the board with the player's symbol.
        //Check for a winner after each move:
        //All rows
        //All columns
        //Both diagonals
        //Check for a draw if the board is full and there is no winner.
        //Display the final result: "Player X wins","Player O wins", or "It's a draw!"
        public Assessment2()
        {
            char[,] Board = new char[3, 3];
            bool inputChecked = false;
            char Winner = ' ';

            char[] Turns = new char[2];
            Turns[0] = 'X';
            Turns[1] = 'O';
            char CurrentTurn = Turns[new Random().Next(0, 1)];

            InitializeBoard(Board);
            ShowBoard(Board);



            while (Winner == ' ' && IsFullBoard(Board) == false)
            {

                Console.WriteLine($"For player {CurrentTurn} , Enter number in format n,n :");
                inputChecked = false;

                while (inputChecked == false)
                {
                    string input = Console.ReadLine();

                    inputChecked = CheckInput(input, Board);

                    if (inputChecked)
                    {
                        PlaceSafeChar(CurrentTurn, Board, input);
                        ShowBoard(Board);

                        char winner = CheckWhoIsWinner(Board);
                        if (winner != ' ')
                        {
                            Winner = winner;
                            Console.WriteLine($"Player : {winner} wins");
                        }

                        else if (IsFullBoard(Board))
                        {
                            Console.WriteLine("It is a draw!");
                        }

                        else
                        {
                            CurrentTurn = SwapTurns(CurrentTurn);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid input");
                    }
                }
            }


        }

        static char SwapTurns(char currentTurn)
        {
            if (currentTurn == 'X')
                return 'O';

            return 'X';
        }

        void PlaceSafeChar(char chr, char[,] board, string location)
        {
            board[ParseSafeRow(location), ParseSafeCol(location)] = chr;
        }

        bool IsFullBoard(char[,] board)
        {
            int count = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] != ' ')
                        count = count + 1;

                }
            }
            if (count == 9)
                return true;

            return false;
        }

        static int ParseSafeRow(string input)
        {
            var splits = input.Split(",");
            return int.Parse(splits[0]);
        }

        static int ParseSafeCol(string input)
        {
            var splits = input.Split(",");
            return int.Parse(splits[1]);
        }
        static bool CheckInput(string line, char[,] board)
        {
            int row = 0, col = 0;

            var splits = line.Split(",");
            if (splits.Count() != 2)
                return false;

            if (splits[0].Length > 1 || splits[1].Length > 1)
                return false;

            //now we are sure splits in format n,n , let's check the values
            if (int.TryParse(splits[0], out row) == false)
                return false;
            if (int.TryParse(splits[1], out col) == false)
                return false;

            //The input is absloutly numeric , let's check if the input fits the board
            if (row < 0 || row > 2)
                return false;
            if (col < 0 || col > 2)
                return false;

            //now check if the square is empty
            if (board[row, col] != ' ')
                return false;

            return true;
        }
        static void InitializeBoard(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
        static void ShowBoard(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"[{board[row, col]}] ");
                }
                Console.WriteLine();
            }
        }

        static char CheckWhoIsWinner(char[,] board)
        {
            char winner;
            for (int row = 0; row < 3; row++) //checking columns
            {
                string result = string.Empty;
                for (int col = 0; col < 3; col++)
                {
                    result = result + board[row, col];

                }
                winner = CheckTheThree(result);
                if (winner == 'X' || winner == 'O')
                {
                    return winner;
                }
            }

            for (int col = 0; col < 3; col++) //checking rows
            {
                string result = string.Empty;
                for (int row = 0; row < 3; row++)
                {
                    result = result + board[row, col];

                }
                winner = CheckTheThree(result);
                if (winner == 'X' || winner == 'O')
                {
                    return winner;
                }
            }

            winner = CheckDiagonally(board);
            if (winner == 'X' || winner == 'O')
            {
                return winner;
            }

            return ' ';
        }

        static char CheckTheThree(string input)
        {
            input = input.Trim().ToUpper();
            if (input == "XXX")
                return 'X';
            else if (input == "OOO")
                return 'O';
            else
                return ' ';


        }

        static char CheckDiagonally(char[,] board)
        {
            string diagonal1 = string.Empty, diagonal2 = string.Empty;
            diagonal1 = board[0, 0].ToString() + board[1, 1].ToString() + board[2, 2].ToString();
            char result = CheckTheThree(diagonal1);
            if (result == 'O' || result == 'X')
                return result;

            diagonal2 = board[0, 2].ToString() + board[1, 1].ToString() + board[2, 0].ToString();
            result = CheckTheThree(diagonal2);
            if (result == 'O' || result == 'X')
                return result;

            return ' ';
        }
    }
}