using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Helpers
    {
        public void DrawMaze(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        public GameDto InitializeMaze()
        {
            Random random = new Random();
            int rows = random.Next(10, 20);
            int cols = random.Next(10, 20);

            var maze = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = (random.Next(100) < 20) ? '#' : ' ';
                }
            }
            var dto = new GameDto();
            dto.playerRow = (random.Next(1, 10));
            dto.playerCol = 1;
            maze[dto.playerRow, dto.playerCol] = 'P';
            dto.maze = maze;
            return dto;
        }
        public GameDto PlaceGoal(GameDto dto)
        {
            Random random = new Random();
            do
            {
                dto.goalRow = random.Next(1, dto.maze.GetLength(0)-1);
                dto.goalCol = random.Next(1, dto.maze.GetLength(1) - 1);
            } while (dto.maze[dto.goalRow, dto.goalCol] == '#');

            dto.maze[dto.goalRow, dto.goalCol] = 'g';

            return dto;
        }
        public GameDto HandleKeyPress(GameDto dto,ConsoleKeyInfo keyInfo)
        {
            int newRow = dto.playerRow;
            int newCol = dto.playerCol;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    newRow--;
                    break;
                case ConsoleKey.DownArrow:
                    newRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    newCol--;
                    break;
                case ConsoleKey.RightArrow:
                    newCol++;
                    break;
            }

            if (dto.maze[newRow, newCol] != '#')
            {
                dto.maze[dto.playerRow, dto.playerCol] = ' ';
                dto.playerRow = newRow;
                dto.playerCol = newCol;
                dto.maze[dto.playerRow, dto.playerCol] = 'P';
            }

            if (dto.playerRow == dto.goalRow && dto.playerCol == dto.goalCol)
            {
                dto.gameWon = true;
            }
            return dto;
        }
    }
}
