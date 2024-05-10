using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Välkommen till spelrecensionsprogrammet.");
        Console.WriteLine("Texterna du skriver kommer sparas i ett separat dokument.");

        Console.Write("Skriv in namnet på spelet: ");
        string spelNamn = Console.ReadLine();

        Console.Write("Ge spelet ett betyg (1-10): ");
        double betyg = Convert.ToDouble(Console.ReadLine());

        Console.Write("Skriv en kort recension av spelet: ");
        string recension = Console.ReadLine();

        Console.Write("Skriv något negativt om spelet:  ");
        string negativ = Console.ReadLine();

        string filePath = "recensioner.txt";

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine("--- Spelrecension ---");
            sw.WriteLine("Spel: " + spelNamn);
            sw.WriteLine("Betyg: " + betyg );
            sw.WriteLine("Recension: " + recension);
            sw.WriteLine("Skriv något negativt om spelet:  " + negativ);
        }

        Console.WriteLine("\nDin recension har sparats till filen 'recensioner.txt'.");
        Console.WriteLine("Tack för din recension!");

        Console.WriteLine("\nTryck på valfri knapp för att avsluta.");
        Console.ReadKey();
    }
}

