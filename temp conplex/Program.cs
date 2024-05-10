using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Välj en operation:");
            Console.WriteLine("1. Celsius till Fahrenheit");
            Console.WriteLine("2. Fahrenheit till Celsius");
            Console.WriteLine("3. Celsius till Kelvin");
            Console.WriteLine("4. Kelvin till Celsius");
            Console.WriteLine("5. Fahrenheit till Kelvin");
            Console.WriteLine("6. Kelvin till Farenheit");
            Console.WriteLine("7. Avsluta");

            int choice;
            while (true)
            {
                Console.Write("Välj ett tal mellan 1-7: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= 7)
                    {

                        break;
                    }
                }
                Console.WriteLine("Ogiltigt ange en operation med talen mellan 1-7");
            }
            if (choice == 7)
            {
                Console.WriteLine("Tack och hej då");
                break;
            }

            double temperature;
            string inputMessage;
            string outputMessage;

            switch (choice)
            {
                case 1:
                    inputMessage = "Ange temperatur i Celsius: ";
                    outputMessage = "F är lika med ";
                    break;
                case 2:
                    inputMessage = "Ange temperatur i Fahrenheit: ";
                    outputMessage = "C är lika med ";
                    break;
                case 3:
                    inputMessage = "Ange tempera i Celsius: ";
                    outputMessage = "C är lika med ";
                    break;
                case 4:
                    inputMessage = "Ange din temperatur i Kelvin: ";
                    outputMessage = "Kelvin är lika med ";
                    break;
                case 5:
                    inputMessage = "Ange din temperatur i Fahrenheit: ";
                    outputMessage = "Fahrenheit är lika med";
                    break;
                case 6:
                    inputMessage = "Ange din temperatur i Kelvin: ";
                    outputMessage = "Kelvin är lika med";
                    break;

                default:
                    inputMessage = "";
                    outputMessage = "";
                    break;
            }

            Console.Write(inputMessage);
            temperature = double.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ConvertToCelsiusToFahrenheit(temperature);
                    break;
                case 2:
                    ConvertFahrenheitToCelsius(temperature);
                    break;
                case 3:
                    ConvertCelsiusToKelvin(temperature);
                    break;
                case 4:
                    ConvertKelvinToCelsius(temperature);
                    break;
                case 5:
                    ConvertFahrenheitToKelvin(temperature);
                    break;
                case 6:
                    ConvertKelvintoFahrenheit(temperature);
                    break;
            }
        }
    }

    static void ConvertToCelsiusToFahrenheit(double celsius)
    {
        double fahrenheit = (celsius * 9 / 5) + 32;
        Console.WriteLine($"{celsius} grader Celsius är lika med {fahrenheit} grader Fahrenheit.");
    }

    static void ConvertFahrenheitToCelsius(double fahrenheit)
    {
        double celsius = (fahrenheit - 32) * 5 / 9;
        Console.WriteLine($"{fahrenheit} grader Fahrenheit är lika med {celsius} grader Celsius.");
    }
    static void ConvertCelsiusToKelvin(double celsius)
    {
        double kelvin = (celsius + 273.15);
        Console.WriteLine($"{celsius} grader är lika med {kelvin} grader Kelvin.");
    }
    static void ConvertKelvinToCelsius(double kelvin)
    {
        double celsius = (kelvin - 273.15);
        Console.WriteLine($"{kelvin} grader är lika med {celsius} grader Celsius");
    }
    static void ConvertFahrenheitToKelvin(double fahrenheit)
    {
        double kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;
        Console.WriteLine($"{fahrenheit} grader är lika med {kelvin} grader Kelvin");
    }
    static void ConvertKelvintoFahrenheit(double kelvin)
    {
        double fahrenheit = (kelvin - 273.15) * 9 / 5 + 32;
        Console.WriteLine($"{kelvin} grader Kelvin är lika med {fahrenheit} grader Fahrenheit");
    }
}

