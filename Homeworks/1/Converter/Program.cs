using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Converter
{

    internal class Program
    {
        public static string AskUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static char AskTemperature(string message) {
            return char.ToUpper(AskUser(message)[0]);
        }
        public static bool CheckTemperature(char temp)
        {
            return (temp == 'F' || temp == 'C' || temp == 'K');
        }
        public static bool CheckValue(string input) {
            return Regex.IsMatch(input, @"^((\-)?\d*,?\d+)$");
        }
        public static float ConvertTemperature(char from, char to, float value)
        {
            if (from == 'C' && to == 'F')
            {
                return value * 1.8f + 32;
            }
            else if (from == 'F' && to == 'C')
            {

                return (value - 32f) / 1.8f;
            }
            else if (from == 'K' && to == 'C')
            {
                return value - 273.15f;
            }
            else if (from == 'C' && to == 'K')
            {
                return value + 273.15f;
            }else if(from=='C' && to =='C')
            {
                return value;
            }
            throw (new Exception("Invalid values passed to ConvertTemperature Function! "));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to temperature converter!\nValid inputs for temperatures are:\n \t1) C - Celsius\n \t2) F - Fahrenheit\n \t3) K - Kelvin");

            char typeFrom = AskTemperature("Insert a temperature type of a value that must be converted: ");
            char typeTo = AskTemperature("Insert a temperature type to which the value must be coverted: ");

            if (!CheckTemperature(typeFrom) || !CheckTemperature(typeTo) || (typeFrom == typeTo)) {
                Console.WriteLine("Error: the user inserted incorrect type of temperature or temperature types are the same! ");
                return;
            }


            string value = AskUser("Insert a value: ");
            if (!CheckValue(value)) {
                Console.WriteLine("Error: insert a correct number! ");
                return;
            }


            float toCelsius = ConvertTemperature(typeFrom, 'C', (float)Convert.ToDouble(value));
            if (toCelsius < -273.15f)
            {
                Console.WriteLine("Error: the input value exceeded the absolute zero threshold! ");
                return;
            }


            float result = ConvertTemperature('C', typeTo, toCelsius);
            Console.WriteLine($"Result: {result}");

        }
    }
}
