using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP32
{
    class Program
    {
        static void Main(string[] args)
        {
            int high = 10000000, sum = 0;
            // generate all numbers that do not have repeating digits
            bool[] areRepeating = new bool[high];
            
            for (int i = 1; i < high; i++)
            {
                areRepeating[i] = HasRepeating(i);
            }
            for(int a = 1; a < high / 2; a++)
            {
                if (!areRepeating[a])
                {
                    for (int b = a + 1; a * b < high; b++)
                    {
                        int c = a * b;
                        if (c > 1)
                        {
                            if (!areRepeating[b] && !areRepeating[c])
                            {

                                if (IsPandigital(a, b, c))
                                {
                                    sum += c;
                                    Console.WriteLine(a + " x " + b + " = " + c);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(sum + "... done");
            Console.ReadLine();
        }
        static bool IsPandigital(int i, int j, int k)
        {
            if ((i.ToString() + j.ToString() + k.ToString()).Length != 9)
                return false;
            //if ((i.ToString() + j.ToString() + k.ToString()).Contains('0'))
            //    return false;
            if (HasRepeating(int.Parse(i.ToString() + j.ToString())) && HasRepeating(int.Parse(i.ToString() + k.ToString())) && HasRepeating(int.Parse(j.ToString() + k.ToString())))
            {
                return false;
            }
            if (HasRepeating(int.Parse(i.ToString() + j.ToString() + k.ToString())))
                return false;
            return true;
        }
        static bool HasRepeating(int i)
        {
            string num = i.ToString();
            if (num.Contains('0'))
                return true;
            for(int j = 0; j < num.Length - 1; j++)
            {
                for(int k = j + 1; k < num.Length; k++)
                {
                    if (num[j] == num[k])
                        return true;
                }
            }
            return false;
        }
    }
}
