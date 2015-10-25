using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace PEP26
{
    class Program
    {
        static void Main(string[] args)
        {
            int high = 0;
            string s;
            double temp;
            int length = 0;
            bool[] nums = new bool[2500];
            for (int i = 2; i < nums.Length; i++)
            {
                for (int j = 2; i*j < 1000; j++)
                {
                    nums[i * j] = true;
                }
            }

                    for (int i = 3; i < 1000; i++)
                    {
                        if (!nums[i])
                        {
                            BigInteger x = new BigInteger();
                            x = BigInteger.Pow(new BigInteger(10), i - 1);
                            x = BigInteger.Subtract(x, BigInteger.One);
                            x = BigInteger.Divide(x, i);
                            s = x.ToString();
                            int num = (int)Math.Log10(i);
                            for (int z = 0; z < num; z++)
                            {
                                s = "0" + s;
                            }
                            //Console.WriteLine(i + ". " + x.ToString());
                            //
                            bool flip = false;
                            for(int j = 1; j < s.Length; j++)
                            {
                                if (j+1+j < s.Length)
                                {
                                    if (s.Substring(0, j) == s.Substring(j + 1, j))
                                    {
                                        length = j;
                                        flip = true;
                                    }
                                }
                            }
                            if (!flip)
                            {
                                length = s.Length;
                            }
                            if (length > high)
                            {
                                high = i;
                                Console.WriteLine(i);
                            }

                        }
                    }
                    Console.WriteLine(high);
            Console.ReadLine();
        }
    }
}
