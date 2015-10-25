//August 21, 2014
//Samuel Doud
//Project Euler Probem 48
//find sum of all a^a last 10 digits
//for a <= 1000
//answer = 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PEP48
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger c = new BigInteger(0); //resultant number
            int b; // number to be raised and raised to
            int limit = 1000;//sets upper bound of search
            int numberOfEndDigits = 10; //how many digits to pull out of resultant
            for (b = 1; b <= limit; b++)//iterates b to a limited amount
            {
                c = BigInteger.Add(c, BigInteger.Pow(new BigInteger(b), b)); //c = b^b + c
            }
            Console.WriteLine(c.ToString().Substring(c.ToString().Length - numberOfEndDigits, numberOfEndDigits)); // prints c's last 10 digits
            Console.ReadLine(); // holds console
        }
    }
}
