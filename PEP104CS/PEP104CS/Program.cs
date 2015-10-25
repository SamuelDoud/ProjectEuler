using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PEP104CS
{
    class Program
    {
        public static int length = 1000000000;
        public static bool[] PanD = new bool[length];
        
        static void Main(string[] args)
        {
            bool[] b = new bool[10];
            b[0] = true;
            GeneratePanD(b, 0, 0);
            Console.WriteLine("All pandigitals up to " + length + " generated!");
            int limit = length;
            BigInteger one = new BigInteger(1);
            BigInteger two = one;
            BigInteger three;
            string temp;
            byte[] test;
            int FrontEnd, BackEnd;
            for (int i = 3; i < limit; i++ )
            {
                three = BigInteger.Add(one, two);
                one = two;
                two = three;
                if (i > 65000)
                {
                    test = three.ToByteArray();
                    temp = three.ToString();
                    b = new bool[10];
                    b[0] = true;
                    for (int j = 1; j < 10; j++)
                    {
                        if (!b[test[j]])
                        {
                            b[test[j]] = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int j = 1; j < 10; j++)
                    {
                        if (!b[test[temp.Length - j]])
                        {
                            b[test[temp.Length - j]] = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
                Console.ReadLine();
        
        }
        public static int IntParseFast(string value) // credit to http://www.dotnetperls.com/int-parse-optimization
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = 10 * result + (value[i] - 48);
            }
            return result;
        }
        public static void GeneratePanD(bool[] b, int temp, int index)
        {
            if (index != 9)
            {
                for (int i = 1; i <= 9; i++ )
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        
                        GeneratePanD(b, int.Parse(temp.ToString() + i.ToString()), index + 1);
                        b[i] = false; //resets the recent change
                    }
                }
            }
            else
            PanD[temp] = true;
        }
        public static bool isEndPandigital(BigInteger fib)
        {
            int index = int.Parse(fib.ToString().Substring(fib.ToString().Length - 9, 9));
            return PanD[index];
        }
        public static bool isBeginPandigital(BigInteger fib)
        {
            int index = int.Parse(fib.ToString().Substring(0, 9));
            return PanD[index];
        }
        private static bool containZero(BigInteger fib, int start, int length)
        {
            string fibStr = fib.ToString();
            if (fibStr.Substring(start, length).Contains('0'))
            {
                return false;
            }
            return true;
        }
    }
}
