using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creates the board
            List<string> board = newBoard();
            string player = "x";

            while (!IsGameOver(board))
            {
                displayBoard(board);
                int choice = positionChoice(player);

                makeMove(board, choice, player);
            
                player = getNextPlayer(player);
            }

            displayBoard(board);
            Console.WriteLine("Game Over! Thanks for playing!");

        }

        static bool IsWinner(List<string> board, string player)
        {
            bool isWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
            || (board[3] == player && board[4] == player && board[5] == player)
            || (board[6] == player && board[7] == player && board[8] == player)
            || (board[0] == player && board[3] == player && board[6] == player)
            || (board[1] == player && board[4] == player && board[7] == player)
            || (board[2] == player && board[5] == player && board[8] == player)
            || (board[0] == player && board[4] == player && board[8] == player)
            || (board[2] == player && board[4] == player && board[6] == player)
            )
            {
                isWinner = true;
            }
            return isWinner;
        }
        static bool IsTie(List<string> board)
        {
            bool foundDigit = false;
            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board)) 
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        //This function creates a new game board
        static List<string> newBoard()
        {
            // create a list for game board
            List<string> boardOriginal = new List<string>();

            for (int i = 1; i <= 9; i++ )
            {
                boardOriginal.Add(i.ToString());
            }

            return boardOriginal;
        }
        static void displayBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine($"- + - + -");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine($"- + - + -");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        
        }

        //This function sets up the next player 
        static string getNextPlayer(string player)
        {
           string nextPlayer = "x";

           if (player == "x")
           {
                nextPlayer = "o";
           }

           return nextPlayer;
        }

        static int positionChoice(string nextPlayer)
        {
            Console.Write($"{nextPlayer}'s turn: choose a spot (1-9): ");
            string choiceString = Console.ReadLine();

            int choice = int.Parse(choiceString);
            return choice;
        }

        static void makeMove(List<string> board, int choice, string player)
        {
            int index = choice - 1;
            if (board[index] == "x" || board[index] == "o")
            {
                Console.Write("Spot already taken, choose again:");
                string newchoice = Console.ReadLine();
                int newindex = int.Parse(newchoice);
                index = newindex - 1;
            }

            board[index] = player;
        } 
    }
}