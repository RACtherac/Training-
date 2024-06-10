using System;
using System.Linq;
using System.Threading;

namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fieldLength = 50, fieldWidth = 15;
            const char fieldTile = '#';
            string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

            const int racketLength = fieldWidth / 4;
            const char racketTile = 'I';

            int leftRacketHeight = 0;
            int rightRacketHeight = 0;

            int ballx = fieldLength / 2;
            int bally = fieldWidth / 2;
            const char ballTile = 'O';

            bool isBallGoingDown = true;
            bool isBallGoingRight = true;

            int leftPlayerPoints = 0;
            int rightPlayerPoints = 0;

            int scoreboardX = fieldLength / 2 - 2;
            int scoreboardY = fieldWidth + 3;

            while (true)
            {
                Console.Clear();

                // Draw top and bottom borders
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);
                Console.SetCursorPosition(0, fieldWidth + 1);
                Console.WriteLine(line);

                // Draw rackets
                for (int i = 0; i < racketLength; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + leftRacketHeight);
                    Console.WriteLine(racketTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1 + rightRacketHeight);
                    Console.WriteLine(racketTile);
                }

                // Draw ball
                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(ballx, bally);
                    Console.WriteLine(ballTile);
                    Thread.Sleep(100);

                    Console.SetCursorPosition(ballx, bally);
                    Console.WriteLine(' ');

                    if (isBallGoingDown)
                    {
                        bally++;
                    }
                    else
                    {
                        bally--;
                    }
                    if (isBallGoingRight)
                    {
                        ballx++;
                    }
                    else
                    {
                        ballx--;
                    }

                    // Ball hits top or bottom wall
                    if (bally == 1 || bally == fieldWidth)
                    {
                        isBallGoingDown = !isBallGoingDown;
                    }

                    // Ball hits left racket or scores for right player
                    if (ballx == 1)
                    {
                        if (bally >= leftRacketHeight + 1 && bally <= leftRacketHeight + racketLength)
                        {
                            isBallGoingRight = !isBallGoingRight;
                        }
                        else
                        {
                            rightPlayerPoints++;
                            bally = fieldWidth / 2;
                            ballx = fieldLength / 2;
                            isBallGoingRight = true; // Ball always starts going to the right after a score
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftPlayerPoints} II {rightPlayerPoints}");

                            if (rightPlayerPoints == 10)
                            {
                                EndGame("Right player wins!");
                                return;
                            }
                        }
                    }

                    // Ball hits right racket or scores for left player
                    if (ballx == fieldLength - 2)
                    {
                        if (bally >= rightRacketHeight + 1 && bally <= rightRacketHeight + racketLength)
                        {
                            isBallGoingRight = !isBallGoingRight;
                        }
                        else
                        {
                            leftPlayerPoints++;
                            bally = fieldWidth / 2;
                            ballx = fieldLength / 2;
                            isBallGoingRight = false; // Ball always starts going to the left after a score
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftPlayerPoints} II {rightPlayerPoints}");

                            if (leftPlayerPoints == 10)
                            {
                                EndGame("Left player wins!");
                                return;
                            }
                        }
                    }
                }

                // Control rackets
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (rightRacketHeight > 0)
                        {
                            rightRacketHeight--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (rightRacketHeight < fieldWidth - racketLength)
                        {
                            rightRacketHeight++;
                        }
                        break;
                    case ConsoleKey.W:
                        if (leftRacketHeight > 0)
                        {
                            leftRacketHeight--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (leftRacketHeight < fieldWidth - racketLength)
                        {
                            leftRacketHeight++;
                        }
                        break;
                }
            }
        }

        static void EndGame(string message)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
