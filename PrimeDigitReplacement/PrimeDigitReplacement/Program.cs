using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PrimeDigitReplacement
{
    class Program
    {
        public static BitArray sieve;
        static void Main(string[] args)
        {
            List<int> numbers = digitReplacement(1254328, new int[] { 1,5,3 });
            int x = 0;
            foreach (int i in numbers)
            {
                Console.WriteLine(++x + ". " + i);
            }
            Console.ReadLine();
        }
        static void generatePrimes (int limit)
        {
            sieve = new BitArray(limit, true);//all numbers up to limit are currently prime
            int prime = 2; //a prime number
            for (; prime < limit / 2; prime++)
            {
                if (sieve[prime] == true)//the number is in fact prime
                {
                    for (int mult = 3; mult * prime < limit; mult+=2)
                    {
                        sieve[prime * mult] = false;
                    }
                }
            }
        }
        static bool isPrime(int number)
        {
            if (number > sieve.Length || number < 0)
                return false;//number is out of range
            return sieve[number];
        }
        static List<int> digitReplacement(int number, int[] digitsToReplace)
        {
            //digitsToReplace are represented by 10^n
            List<int> numbers = new List<int>();

            int left = 0, right = 0;
            int tempNum;
            for (int digit = 0; digit < 10; digit++)
            {
                tempNum = number;
                for (int currentDigit = 0; currentDigit < digitsToReplace.Length; currentDigit++)
                {

                    left = (tempNum / ((int)Math.Pow(10, digitsToReplace[currentDigit] + 1)));
                    right = tempNum % (int)Math.Pow(10, digitsToReplace[currentDigit]);
                    tempNum = addedNumbers(left, right, digit);
                }
                numbers.Add(tempNum);
            }
            return numbers;
        }
        static int addedNumbers(int left, int right, int i)
        {
            int rightLength = (int)Math.Log10(right) + 1;
            return (left * 10 + i) * (int)Math.Pow(10, rightLength) + right;
        }
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
   
}
