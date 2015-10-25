using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP28
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int highNumber = (int)Math.Pow(1001,2);
            int diaSum = 0, tempPower, tempIndex = 0;
            for(; i <= highNumber; i++)
            {
                tempPower = OddPower(i);
                if (tempIndex == tempPower)
                {
                    tempIndex = 0;
                    
                }
                else
                {
                    if (tempIndex == 0)
                    {
                        diaSum += i;
                    }
                    tempIndex++;
                }

            }
            
        }
        static int OddPower(int i)
        {
          int x =  (int)Math.Truncate(Math.Sqrt(i));
            if (x % 2 == 0)
            {
                x--;
            }
            return x;
        }
    }
}
