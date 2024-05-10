using System;

class Calculator
{
    static void Main(string[] args)
    {
        bool continueCalculation = true;

        while (continueCalculation)
        {
            double num1, num2;
            char operation;

            Console.WriteLine("Välkommen till kalkylatorn");

            Console.WriteLine("Skriv in det första numret:");
            if (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett giltigt decimaltal.");
                continue;
            }

            Console.WriteLine("Vilken operation vill du utföra? (+, -, *, /):");
            if (!char.TryParse(Console.ReadLine(), out operation))
            {
                Console.WriteLine("Ogiltig operation. Ange en av de fyra operationerna: +, -, *, /.");
                continue;
            }

            if (operation == 'q')
            {
                break;
            }

            if (operation != '+' && operation != '-' && operation != '*' && operation != '/')
            {
                Console.WriteLine("Ogiltig operation!");
                continue;
            }

            Console.WriteLine("Skriv in det andra numret:");
            if (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett giltigt decimaltal.");
                continue;
            }

            double result = 0;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Det går inte att dividera med noll ;).");
                        continue;
                    }
                    break;
                default:
                    Console.WriteLine("Ogiltig operation!");
                    continue;
            }

            Console.WriteLine("Resultatet är: " + result);

           
        }

        Console.WriteLine("Tack för att du använt kalkylatorn. Hejdå!");
    }
}

