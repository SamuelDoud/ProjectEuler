using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP179
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit =  (int)Math.Pow(10, 7);
            int[] numOfDiv = new int[limit + 1];
            int count = 0;
            for (int i = 1; i <= limit; i++)
            {
                for (int j = 1; j * i <= limit; j++)
                {
                    numOfDiv[i * j]++;
                }
            }
            for(int i = 0; i < limit; i++)
            {
                if (numOfDiv[i] == numOfDiv[i + 1])
                    count++;
            }
            //for (int i = limit; i > 0; i--)
            //{
            //    for(int j = 1; j <= Math.Sqrt(i); j++)
            //    {
            //        if (i % j == 0)
            //        {
            //            numOfDiv[i]+=2;
            //        }
            //    }
            //    if ((int)Math.Sqrt(i) * (int)Math.Sqrt(i) == i)
            //    {
            //        numOfDiv[i]--;
            //    }
            //    if (i < limit&&numOfDiv[i] == numOfDiv[i + 1])
            //    {
            //        count++;

            //    }
            //}
        }
    }
}
