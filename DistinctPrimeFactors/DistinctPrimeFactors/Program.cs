using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DistinctPrimeFactors
{
    class Program
    {
        public static BitArray publicPrimes;
        static void Main(string[] args)
        {
            int limit = 500000; //Search limit of 500 million

            int limitSquareRoot = (int)Math.Sqrt(limit); //finds the square root of the maximum number
            int MaxSecond; //This number will be used to prevent an out of bounds in the multiplication
            BitArray primes = new BitArray(limit, true); //creates array and sets all numbers to prime
            primes[0] = false;//sets initials to not prime
            primes[1] = false;
            for (int first = 0; first <= limitSquareRoot; first++)
            {
                if(primes[first])
                {
                    MaxSecond = (primes.Length - 1) / first;
                    for (int second = first; second <= MaxSecond; second++)
                    {
                        primes[first * second] = false;//sets the product of first and second to not a prime
                    }
                }
            }
            publicPrimes = primes;

            int numOfDistinct = 4;
            List<String> current;
            List<String> toCheckAgaint;
            for (int i = 3; i < primes.Count - numOfDistinct; i++)
            {
                if (!primes[i])
                {
                    current = giveExponents(PrimeFactors(i));
                    if (current.Count == numOfDistinct)
                    {
                        for (int j = 1; j < numOfDistinct; j++)
                        {
                            if (!primes[i + j])
                            {
                                toCheckAgaint = giveExponents(PrimeFactors(i + j));
                                if (toCheckAgaint.Count == numOfDistinct)
                                {
                                    if (!isDistinct(current, toCheckAgaint))
                                        break;
                                    current.AddRange(toCheckAgaint);
                                    if (numOfDistinct == j + 1)
                                    {
                                        for (int k = 0; k < numOfDistinct; k++)
                                        {
                                            Console.Write((i + k) + ", ");
                                        }
                                        Console.WriteLine();
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    j = numOfDistinct;
                                }
                            }
                            else
                            {
                                j = numOfDistinct;
                            }
                        }
                    }
                }

            }

        }
        public static bool isDistinct(List<String> a, List<String> b)
        {
            for (int i = 0; i < a.Count; i++)
                for (int j = 0; j < b.Count; j++)
                {
                    if (a[i].Equals(b[j]))
                        return false;
                }
            return true;
        }
        public static List<int> PrimeFactors(int num)
        {
            
            List<int> factors = new List<int>();
            int max = publicPrimes.Count;

            for (int index = 2; index < max && num != 1; index++)
            {
                if (publicPrimes[index] && num % index == 0)
                {
                    factors.Add(index);
                    factors.AddRange(PrimeFactors(num / index));
                    break;
                }
            }
            factors.Sort();
            return factors;
        }
        public static List<String> giveExponents(List<int> PrimeFactors)
        {
            String numStr;
            int power = 1;
            List<string> stringPrimeFactors = new List<string>();
            for (int i = 0; i < PrimeFactors.Count; i++)
            {
                power = 1;
                numStr = PrimeFactors[i].ToString();
                while (i + 1 < PrimeFactors.Count && PrimeFactors[i] == PrimeFactors[i+1])
                {
                    power++;
                    i++;
                }
                stringPrimeFactors.Add(numStr + "^" + power.ToString());
            }
                return stringPrimeFactors;
        }
    }
}
