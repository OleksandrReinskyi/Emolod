using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Generator
    {   
        private Random random = new Random();
        private int min;
        private int max;

        public Generator(int min, int max) {
            this.min = min;
            this.max = max;
        }

        public int GenerateNum()
        {
            return this.random.Next(min,max);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator(10, 99);
            int[] nums = new int[20];

            int startIndex = 0;
            int maxSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = generator.GenerateNum();
                Console.WriteLine(i + ": " +nums[i]);

            }

            for (int i = 2; i < nums.Length; i++)
            {
                int temp = nums[i-2] + nums[i-1] + nums[i];
                if(temp > maxSum)
                {
                    startIndex = i-2;
                    maxSum = temp;
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"The indexes of the subset of 3 consecutive values with the highest sum are: {startIndex} {startIndex+1} {startIndex+2}");
        }
    }
}
