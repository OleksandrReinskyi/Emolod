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
        public static float GenerateNum(int min, int max, Random random)
        {
            double range = (double)max-(double)min;
            double sample = random.NextDouble();
            float scaled = (float)((sample * range) + min);
            return scaled;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            float[] numbers = new float[100];

            // Range
            int min = 100;
            int max = 900;

            float secondMin = float.MaxValue;
            float firstMin = float.MaxValue;

            for (int i = 0; i < numbers.Length; i++) 
            {
                float random = GenerateNum(min, max, rnd);
                numbers[i] = random;
                if(random < secondMin)
                {
                    if(random < firstMin)
                    {
                        firstMin = random;
                    }
                    else
                    {
                        secondMin = random;
                    }
                }

            }
            Console.WriteLine("The second min value from the end is: "+secondMin.ToString().Replace(",","."));
        }
    }
}
