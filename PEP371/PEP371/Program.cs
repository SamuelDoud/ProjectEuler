using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP371
{
    class Program
    {
        static void Main(string[] args)
        {
            //Brute Force
            int desired = 1000, temp;
            Random r;
            double numOfRuns = 0;
            long runTimes = 1000000000;
            bool complete;
            bool[] plates;
            r = new Random();
            for (int run = 0; run < runTimes; run++)
            {
                complete = false;
                plates = new bool[desired];
                plates[r.Next(desired)] = true;
                for (int x = 1; !complete; x++) 
                {
                    temp = r.Next(desired - 1);
                    if (temp != 0)
                    if (plates[desired - temp] == true)
                    {
                        complete = true;
                        numOfRuns += x;  
                    }
                    plates[temp] = true;
                }
            }
            Console.WriteLine(numOfRuns/runTimes);
            Console.ReadLine();
        }
    }
}
