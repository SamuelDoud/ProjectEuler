using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareDigitChains
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 100;//= 10000000;
            int targetNumber = 89;
            int ONE = 1;
            int currentNumber, count = 0;

            for (int i = 1; i <= limit; i++)
            {
                currentNumber = nextNumber(i);
                while (currentNumber != ONE || currentNumber != targetNumber)
                {
                    currentNumber = nextNumber(currentNumber);
                }
                if (currentNumber == targetNumber)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
        static int nextNumber(int initNumber)
        {
            int newNumber = 0;
            int numOfDigits = (int)Math.Log(initNumber) + 1;
            int[] digits = new int[numOfDigits];
            for(int divisor = 1; divisor <= numOfDigits; divisor++)
            {
                digits[divisor] = (initNumber * ((int)Math.Pow(10,divisor))) % (int)Math.Pow(10, divisor); //takes the digit at position x and adds it to the array
                newNumber += (int)Math.Pow(digits[divisor],2);//adds the square to the new number
            }
            return newNumber;
            
        }
    }
}
