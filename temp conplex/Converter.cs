using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp_conplex
{
    internal class Converter 
    {
         public double ConvertFromCelsiusToFahrenheit(double celsius)
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            return fahrenheit;
        }

         double ConvertFromFahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
           return celsius;
        }
        double ConvertFromCelsiusToKelvin(double celsius)
        {
            double kelvin = (celsius + 273.15);
            return kelvin;
        }
        double ConvertFromKelvinToCelsius(double kelvin)
        {
            double celsius = (kelvin - 273.15);
            return celsius;
        }
        double  ConvertFahrenheitToKelvin(double fahrenheit)
        {
            double kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;
            return kelvin;
        }
        double ConvertKelvintoFahrenheit(double kelvin)
        {
            double fahrenheit = (kelvin - 273.15) * 9 / 5 + 32;
            return fahrenheit; 
        }



    }
}
