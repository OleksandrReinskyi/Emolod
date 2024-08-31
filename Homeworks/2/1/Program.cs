using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Program
    {

        //1. STRING GENERATOR ---------------------------------------------------------

        //class Generator
        //{
        //    private Random random = new Random();
        //    public Generator() { }
        //    public string GenerateString(int length)
        //    {
        //        string str = "";
        //        for (int i = 0; i < length; i++)
        //        {
        //            int randomNum = this.random.Next(33, 126);
        //            str += (char)randomNum;
        //        }
        //        return str;
        //    }
        //}


        //static void Main(string[] args)
        //{
        //    int stringLength = 8;
        //    int numberOfStrings = 10;

        //    string[] text = new string[numberOfStrings];
        //    Generator generator = new Generator();
        //    for (int i = 0; i < numberOfStrings; i++)
        //    {

        //        text[i] = generator.GenerateString(stringLength);
        //        Console.WriteLine(text[i]);
        //    }

        //}
        // ---------------------------------------------------------------------------------------


        //2. NUMBER GENERATOR ---------------------------------------------------------
        public static int GenerateNum(int min, int max, Random random)
        {
            return random.Next(min, max);
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] numbers = new int[10];

            // Range
            int min = 100;
            int max = 900;

            float secondMin = max ;
            float firstMin = max;

            for (int i = 0; i < numbers.Length; i++) 
            {
                int random = GenerateNum(min, max, rnd);
                numbers[i] = random;
                Console.WriteLine(numbers[i]);
                if(random < secondMin)
                {
                    if(random < firstMin)
                    {
                        secondMin = firstMin;
                        firstMin = random;
                    }
                    else
                    {
                        secondMin = random;
                    }
                }

            }
            Console.WriteLine("The second min value is: "+secondMin);
        }
    }
}
