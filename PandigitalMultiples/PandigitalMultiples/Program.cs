using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandigitalMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentNum = "";
            for (int i = 1; i < 987654321; i++)
            {
                currentNum = "";
                for (int j = 1; currentNum.Length < 11; j++)
                {
                    currentNum = currentNum + (i * j);
                    if (currentNum[0] != '9')
                        break;
                    if (isPandigital(currentNum))
                        Console.WriteLine(currentNum);
                }
            }

            Console.ReadLine();
        }
        static bool isPandigital(String num)
        {
            if (num.Length != 9)
                return false;
            bool[] nums = new bool[10];
            nums[0] = true;
            foreach (char c in num)
                if (c == '0')
                    return false;
                else
                    nums[c - 48] = true;
            foreach (bool b in nums)
                if (!b)
                    return b;
            return true;
        }
    }
}
