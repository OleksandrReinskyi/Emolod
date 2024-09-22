using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 Abstract class Generator
    - Special symbol frequency
    - minNumber
    - length
    - Generate Password func
    -- Take min values from each symbol string (for numbers - minnumber, for small and big letters - choose randomly) and put them into one string
    -- While loop through the string until the length of array equals to the length of a string. 
    --- Create a random value based on it's length. Check if the value is in the array of used values
    --- If so, skip, if not insert into the created string 
 Two generators that inherit from it and have their own dictionary of string of symbols (small, capitalized, numbers, specSymbols)
 */

namespace _1
{

    abstract class Generator
    {
        protected Dictionary<int, string> Charset = new Dictionary<int, string>();
        public int SpecSymbolFrequency { set; get; }
        public int MinNumbers { set; get; }
        public int Length { set; get; }

        protected static Random Rand { set; get; }

        public Generator(int length, int minNumbers, int specSymbolFrequency) {
            this.Length = length;
            this.MinNumbers = minNumbers;
            this.SpecSymbolFrequency = specSymbolFrequency + 1;
            Rand = new Random();

            this.Charset[2] = "0123456789";
            this.Charset[3] = "!@#$%^&*()_-+={}[]:;\"'<>,.?/|~\\";
        }

        public string GeneratePassword()
        {
            List<char> password = new List<char>(new char[Length]);


            //Length calculation
            int availableSymbols = Length - MinNumbers;
            CheckTheLength(availableSymbols, 0);

            double specSymbolsLength = Math.Floor((double)((availableSymbols) / (SpecSymbolFrequency-1)));
            availableSymbols = availableSymbols - Convert.ToInt16(specSymbolsLength);
            CheckTheLength(availableSymbols, 2);

            int capitalizedLettersLength = Rand.Next(1,availableSymbols-1);
            int smallLettersLength = availableSymbols - capitalizedLettersLength;

            
            List<int> options = new List<int>() { smallLettersLength,capitalizedLettersLength,MinNumbers};
            List<int> availablePositions = new List<int>();

            for(int i=0;password.Count > i; i++) //add specSymbols 
            {
                
                if(i%SpecSymbolFrequency == 0  && specSymbolsLength>0)
                {
                    password[i] = Charset[3][Rand.Next(0, Charset[3].Length)];
                    specSymbolsLength--;
                }
                else
                {
                    availablePositions.Add(i);
                }
            }

            for(int i = 0; i < options.Count; i++)
            {
                int minValue = options[i];
                for(int j = 0; j < minValue; j++)
                {
                    char randomChar = Charset[i][Rand.Next(0,Charset[i].Length)];
                    int randomPos = availablePositions[Rand.Next(0, availablePositions.Count)];


                    password[randomPos] = randomChar;

                    availablePositions.Remove(randomPos);//removes according to the value, not the index


                }
            }


            return string.Join("",password);
        }

        private void CheckTheLength(int length,int min)
        {
            if (length < min)
            {
                throw new Exception("Error: provided arguments make the password exceed the given length!");
            }
        }
    }

    class UkrGenerator : Generator
    {
        public UkrGenerator(int length,int minNumbers, int specSymbolFrequency):base(length, minNumbers, specSymbolFrequency) {
            this.Charset[0] = "абвгґдеєжзииіїйклмнопрстуфхцчшщьюя";
            this.Charset[1] = "АБВГҐДЕЄЖЗИИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";


        }



    }

    class EngGenerator : Generator
    {
        public EngGenerator(int length, int minNumbers, int specSymbolFrequency) : base(length, minNumbers, specSymbolFrequency)
        {
            this.Charset[0] = "abcdefghijklmnopqrstuvwxyz";
            this.Charset[1] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                UkrGenerator ukrGenerator = new UkrGenerator(6,1, 5);

                EngGenerator engGenerator = new EngGenerator(6, 1, 5);

                Console.WriteLine(ukrGenerator.GeneratePassword());
                Console.WriteLine(engGenerator.GeneratePassword());
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
            }




        }
    }
}
