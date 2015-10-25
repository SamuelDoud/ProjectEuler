using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PEP60
{
    class Program
    {
        public static int length = 100000000;
        public static List<int> primes = new List<int>();
        public static int leastSum = 500000;
        public static Boolean[] bits = new Boolean[length];
        static void Main(string[] args)
        {
            int[] allPrime;
            bits[0] = true;
            bits[1] = true;
            int temp;
            int searchDepth = 10000;
            //Sieve
            for (int even = 4; even < length; even += 2)
            {
                bits[even] = true;
            }
            for (int first = 3; first < Math.Sqrt(length); )
            {
                for (int second = 3; second * first < length; )
                {
                    bits[first * second] = true;
                    do
                    {
                        second += 2;
                    } while (bits[first] == true);
                }
                do
                {
                    first += 2;
                } while (bits[first] == true);
            }
            for (int print = 0; print < searchDepth; print++)
            {
                if (!bits[print])
                {
                    // Console.WriteLine(print);
                    primes.Add(print);
                }

            }
            Console.WriteLine("Prime Collection complete!");



            allPrime = new int[5];


            for (int one = 1; one < primes.Count; one++)
            {
                allPrime[0] = one;
                for (int two = one + 1; two < primes.Count; two++)
                {
                    allPrime[1] = two;
                    if(IsComboPrime(allPrime))
                    {
                        for (int three = two + 1; three < primes.Count; three++)
                        {
                            allPrime[2] = three;
                            if(IsComboPrime(allPrime))
                            {
                                for (int four = three + 1; four < primes.Count; four++)
                                {
                                    allPrime[3] = four;
                                    if (IsComboPrime(allPrime))
                                    {
                                        temp = 0;
                                        foreach (int i in allPrime)
                                        {
                                            if (i > 0)
                                            {
                                                temp += primes[i];

                                                Console.Write(primes[i] + ", ");
                                            }
                                        }
                                        Console.Write(" for a sum of " + temp);
                                        for (int five = four + 1; five < primes.Count; five++)
                                        {
                                            allPrime[4] = five;
                                            if (IsComboPrime(allPrime))
                                            {
                                                temp = 0;
                                                foreach (int i in allPrime)
                                                {
                                                    temp += primes[i];
                                                    Console.Write(primes[i] + ", ");
                                                }
                                                Console.Write(" for a sum of " + temp);
                                                if (temp < leastSum)
                                                {
                                                    leastSum = temp;
                                                    Console.WriteLine("New Sum is " + leastSum);
                                                }
                                                else
                                                    Console.WriteLine();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

                Console.WriteLine("Search Complete!");
            if (leastSum != int.MaxValue)
            {
                Console.WriteLine(leastSum + " is the answer!");
            }
            else
            {
                Console.WriteLine("No answer was uncovered.");
            }
            Console.ReadLine();
        }
        public static bool IsTwoPrime(int x, int y)
        {
            return !bits[int.Parse(x.ToString() + y.ToString())] && !bits[int.Parse(y.ToString() + x.ToString())];
        }
        public static bool IsComboPrime(int[] x)
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != 0)
                {
                    count++;
                }
            }
            int[] y = new int[count];
            for (int i = 0; i < count; i++)
            {
                y[i] = x[i];
            }
            x = y;
            for (int first = 0; first < x.Length; first++)
            {
                for (int second = first + 1; second < x.Length; second++)
                {
                    if (!IsTwoPrime(primes[x[first]], primes[x[second]]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
