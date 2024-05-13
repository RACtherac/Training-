using System;

class Program
{
    static void Main()
    {
        string[] options = { "rock", "paper", "scissors" };

        Console.WriteLine("Let's play Rock, Paper, Scissors!");

        while (true)
        {
            Console.WriteLine("Enter your choice (rock, paper, scissors) or 'quit' to exit:");
            Console.WriteLine("1. rock");
            Console.WriteLine("2. paper");
            Console.WriteLine("3. scissors");
            Console.WriteLine("4. quit");

            int choice;
            while (true)
            {
                Console.Write("Pick a number 1-4: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                     if  (choice >= 1 && choice <= 4)
                    {
                        break;
                    }
                }
                Console.WriteLine("Please enter a valid number between 1-4");
            }
            if (choice == 4)
            {
                Console.WriteLine("Thank you and goodbye!");
                break;
            }

            string playerChoice = options[choice - 1]; 

            Random random = new Random();
            int randomIndex = random.Next(options.Length);
            string computerChoice = options[randomIndex];

            Console.WriteLine("Computer chooses: " + computerChoice);

            if (playerChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                     (playerChoice == "paper" && computerChoice == "rock") ||
                     (playerChoice == "scissors" && computerChoice == "paper"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Computer wins!");
            }
        }
    }
}

