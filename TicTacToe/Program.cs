using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = [ '0', '1', '2', '3', '4', '5', '6', '7', '8' ];
        static char currentPlayer = 'X';
        static int choice;
        static int gameStatus = 0;
        static char lastPlayer = 'X';

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine();
                DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("Player {0}, enter your move (0-8): ", currentPlayer);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out choice) && choice >= 0 && choice <= 8)
                    {
                        if (board[choice] != 'X' && board[choice] != 'O')
                        {
                            board[choice] = currentPlayer;
                            lastPlayer = currentPlayer;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The cell {0} is already occupied with {1}. Please choose another cell.", choice, board[choice]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 8.");
                    }
                }

                gameStatus = CheckWin();
                if (gameStatus == 0)
                {
                    SwitchPlayer();
                }
            }
            while (gameStatus == 0);

            Console.Clear();
            DisplayBoard();

            if (gameStatus == 1)
            {
                Console.WriteLine("Player {0} has won!", lastPlayer);
            }
            else
            {
                Console.WriteLine("The game is a draw.");
            }

            Console.ReadLine();
        }

        static void DisplayBoard()
        {
            Console.WriteLine("___________________");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |   {board[2]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |   {board[5]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |   {board[8]}   ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("-------------------");
        }

        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        private static int CheckWin()
        {
            int[,] winConditions = new int[,]
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Horizontal
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Vertical
                { 0, 4, 8 }, { 2, 4, 6 }  // Diagonal
            };

            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                int a = winConditions[i, 0];
                int b = winConditions[i, 1];
                int c = winConditions[i, 2];

                if (board[a] == board[b] && board[b] == board[c])
                {
                    return 1;
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}

