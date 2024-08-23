using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Calculator
    /*
     Pseudocode:
    It will be a calculator that firstly takes 2 numbers, performs an operation and then waits for another user's input 
    with the first number being the result of the previous operation
    
    Must implement a Calculator class with
    - public string array with first and second numbers that are set to null
    - public char operation
    - public float function that will return an output based on operation
    
    Helper functions:
    - askUser function that will ask a question and get the output
    - Validate function that will validate the number's inputs 

    While loop until the user hits Ctr+C 
     */
{
   class Calculator
   {
        public Calculator() {
        
        }
        public string[] numbers = new string[2] { null, null };
        public string operation = null; 



        public double Calculate()
        {
            double number1 = Convert.ToDouble(this.numbers[0]);
            double number2 = Convert.ToDouble(this.numbers[1]);
            switch (this.operation)
            {
                case "*":
                    return number1 * number2;
                case "-":
                    return number1 - number2;
                case "+":
                    return number1 + number2;
                case "/":   
                    if (number2 ==0) {
                        throw new Exception("Cannot divide by 0!");
                    }
                    return number1 / number2;
                case "sqrt":
                    if (number1 < 0)
                    {
                        throw new Exception("Cannot get the square root of a less than 0 value (number 1)!");
                    }
                    return Math.Sqrt(number1);
                case "pow":
                    if (number2 < 0) {
                        throw new Exception("Cannot raise to the power that is less than 0!");
                    }
                    return Math.Pow(number1, number2);
                default:
                    throw new InvalidOperationException("Please insert a valid operation!");
            }
        }
        
   }

    internal class Program
    {
        public static string AskUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static bool Validate(string str)
        {
            return Regex.IsMatch(str, @"^((\-)?\d*,?\d+)$");
        }
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            string startingMessage = @"Welcome to the calculator! 
You will be asked to insert operation and 2 numbers. 
After each operation the result will be stored as the 1 number.So you can continue working with it.
The list of supported operations:
    1. * 
    2. +
    3. -
    4. /
    5. pow - raising the 1 number to the 2 number
    6. sqrt - getting the square root of the 1 number
Enjoy!
P.s.: You can exit the calculator by pressing Ctr+C.
                                    ";
            Console.WriteLine(startingMessage);
            while (true) {
                try
                {
                    int fin = 2; 
                    calculator.operation = AskUser("Insert an operation: ");
                    if(calculator.operation == "sqrt")
                    {
                        fin = 1;
                    }
                    for(int i = 0; i < fin; i++)
                    {
                        if (calculator.numbers[i] == null)
                        {
                            string answer = AskUser($"Insert the {i+1} number: ");
                            while (Validate(answer) == false)
                            {
                                answer = AskUser($"Insert the {i+1} number: ");
                            }
                            calculator.numbers[i] = answer;
                        }
                    }

                    string result = Convert.ToString(calculator.Calculate());
                    calculator.numbers[0] = result;
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception e) {
                    Console.WriteLine("Error occured: "+e.Message);
                }
                finally
                {
                    calculator.operation = null;
                    calculator.numbers[1] = null;
                }
            }
        }
    }
}
