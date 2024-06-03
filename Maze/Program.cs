using Maze;
using System;

class MazeGame
{   
    static void Main(string[] args)
    {
        var helpers = new Helpers();
        
        var dto = helpers.InitializeMaze();
        dto = helpers.PlaceGoal(dto);

        Console.WriteLine("Welcome to the maze game. You are 'P' and your goal is to reach 'G'.");
        Console.WriteLine("Use arrow keys to move. Press any key to start.");
        Console.ReadKey(true);

        while (!dto.gameWon)
        {
            helpers.DrawMaze(dto.maze);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            dto = helpers.HandleKeyPress(dto,keyInfo);
            Console.Clear();
        }

        Console.WriteLine("Congratulations! You won!");
        Console.ReadLine();
    }

    

    

   

    


    
}

