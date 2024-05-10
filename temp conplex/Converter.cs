using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp_conplex
{
    internal class Converter
    {
         double ConvertFromCelsiusToFahrenheit(double celsius)
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            return fahrenheit;
        }

         double ConvertFromFahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
           return celsius;
        }
    }
}
