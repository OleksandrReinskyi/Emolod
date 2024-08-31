using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2
{
    internal class Program
    {

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static bool ValidateString(string message) {
            if (message == null) { 
                return false;
            }
            for (int i = 0; i < message.Length; i++) { 
                if(!((message[i] >= 20) && (message[i] <= 126)))
                {
                    Console.WriteLine("The text contains forbidden characters!");
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            string str = null;
            while (!ValidateString(str))
            {
                str = GetUserInput("Insert a line of text in the English language: ");
            }


            var letters = new Dictionary<char, int>();

            foreach (char c in str) {
                char test = char.ToUpper(c);
                if(!(test<=90 && test >= 65))
                {
                    continue;
                }
                if (letters.ContainsKey(c)) { 
                    letters[c]++;
                }
                else
                {
                    letters[c] = 1;
                }
            }

            foreach (var kvp in letters)
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);

        }
    }
}
