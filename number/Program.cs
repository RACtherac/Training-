using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        bool repeat = true;
        while (repeat)
        {
            Console.WriteLine("Välkommen till numer spel.");
            Console.WriteLine("Gissa talet mellan 1 till 100.");
            Console.WriteLine("Starta med att klicka på S eller avsluta på Q:");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "Q")
            {
                repeat = false;
                continue;
            }

            Random random = new Random();
            int secretNumber = random.Next(1, 100);
            int guesses = 0;
            int maxGuesses = 10;

            while (guesses < maxGuesses)
            {
                Console.Write("Gissa numret: ");
                string input = Console.ReadLine();
                int guess;

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Ange ett giltigt tal.");
                    continue;
                }
                guesses++;

                if (guess < secretNumber)
                {
                    Console.WriteLine($"Talet {guess} är för lågt.");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine($"Talet {guess} är för högt.");
                }
                else
                {
                    Console.WriteLine($"Grattis! Du lyckades gissa rätt nummer ({secretNumber}) på {guesses} försök.");
                    break;
                }
                if (secretNumber == 69)
                {
                    Console.WriteLine("nice");
                }
            }

            if (guesses == maxGuesses)
            {
                Console.WriteLine($"Du har använt alla {maxGuesses} försök. Det hemliga talet var {secretNumber}.");
            }

            Console.WriteLine("Vill du spela igen? (Tryck T för arr starta om, Q för att avsluta)");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain != "T")
            {
                repeat = false;
            }
        }

        Console.WriteLine("Tack för att du spelade!");
    }
}

