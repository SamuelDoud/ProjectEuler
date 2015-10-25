using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Goldbachs
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 10000; //Search limit of 500 million
            int limitSquareRoot = (int)Math.Sqrt(limit); //finds the square root of the maximum number
            int MaxSecond; //This number will be used to prevent an out of bounds in the multiplication
            BitArray primes = new BitArray(limit, true); //creates array and sets all numbers to prime
            BitArray oddComposites = new BitArray(limit);
            List<double> doubleSquare = new List<double>();
            primes[0] = false;//sets initials to not prime
            primes[1] = false;
            for (int first = 0; first <= limitSquareRoot; first++)
            {
                if (primes[first])
                {
                    MaxSecond = (primes.Length - 1) / first;
                    for (int second = first; second <= MaxSecond; second++)
                    {
                        primes[first * second] = false;//sets the product of first and second to not a prime
                    }
                }
            }
            for (int i = 0; i < primes.Count; i++)//find all odd composite numbers
            {
                if (!primes[i] && i % 2 == 1)
                {
                    oddComposites[i] = true;
                }
            }
            for (int i = 0; i * i < limit; i++)//finds the double of every square
            {
                doubleSquare.Add(2 * i * i);
            }
            int searchNum = 0, primeNum = 0;
            bool trigger = true;
            for (int index = 9; index < oddComposites.Count; index+=2)
            {
                if (oddComposites[index])
                {
                    trigger = false;
                    for (primeNum = 2; primeNum < index; primeNum++)
                        if (primes[primeNum])
                        {
                            searchNum = index - primeNum;
                            if(Math.Sqrt(searchNum / 2) % 1 == 0)
                            {
                                trigger = true;
                            }
                        }
                }
                if (!trigger)
                {
                    Console.WriteLine(index + "!");
                }
            }


        }
    }
}
