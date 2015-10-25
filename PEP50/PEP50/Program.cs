using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP50
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1000000;
            bool[] primes = new bool[limit];

            List<int> actualPrimes = new List<int>();
            primes[0] = true;
            primes[1] = true;
            for(int i = 2; i < limit; i++)
            {
                for(int j = 2; j*i < limit; j++)
                {
                    primes[i * j] = true;
                }
            }
            for (int i = 0; i < primes.Length; i++)
            {
                if (!primes[i])
                    actualPrimes.Add(i);
            }
            //prime array
            int count, sum, highSum, highCount = 0;
            for (int i = 0; i < actualPrimes.Count; i++)
            {
                sum = 0;
                for (count = 0; sum < limit && i + count < actualPrimes.Count; count++)
                {
                        sum += actualPrimes[i + count];
                        if (sum < limit)
                        {
                            if (!primes[sum] && count > highCount)
                            {
                                highCount = count + 1;
                                highSum = sum;
                            }
                        }
                    else break;

                }
                

                
            }
        }
    }
}
