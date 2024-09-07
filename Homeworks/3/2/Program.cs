using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Program
    {
        static public string askUser(string message) { 
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int[] numbers = new int[100];
            int lowBoundary = 100;
            int highBoundary = 900;
            Random rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(lowBoundary,highBoundary+1);
            }

            int min = Convert.ToInt32(askUser("Insert the min value: "));
            int max = Convert.ToInt32(askUser("Insert the max value: "));
            int length = Convert.ToInt32(askUser("Insert the length: "));

            Dictionary<int,int> sequences = new Dictionary<int,int>(); // key - start index of suitable sequence; value - its sum

            for (int i = length; i < numbers.Length; i++) {
                int tempSum = 0;

                for (int j = i-length; j < i; j++) {
                    tempSum += numbers[j];
                }
                if (tempSum > min && tempSum < max) { 
                    sequences[i-length] = tempSum;
                }
            }

            foreach(int item in sequences.Keys)
            {
                Console.WriteLine(item+"-"+(item+length-1)+": " + sequences[item]);
            }

        }
    }
}
