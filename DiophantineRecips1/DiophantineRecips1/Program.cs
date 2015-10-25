using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiophantineRecips1
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstDenom, dioDenom;
            double tempLimit, remain;
            double target = 7000;
            double count = 0;
            for (dioDenom = 0; dioDenom < 20; dioDenom+=1)
            {
                count = 0;
                tempLimit = dioDenom * 2;
                remain = dioDenom;
                for (firstDenom = dioDenom + 1; firstDenom <= tempLimit; firstDenom++)
                {
                    //if (remain + count < target)
                    //{
                    //    break;
                    //}
                    if ((dioDenom * dioDenom) / firstDenom % 1 == 0)
                        count++;
                    remain--;
                }
               Console.Out.WriteLine(dioDenom + ". " + count);
            }
            Console.Out.WriteLine((dioDenom- 1) + ". " + count);
            Console.In.ReadLine();

        }
    }
}
