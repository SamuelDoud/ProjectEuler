//Samuel Doud
//August 23, 2014
//Find the cancelling digit fractions that maintain equivencly
// I.E. 49 / 98
// 9s cancel and fraction represents the same number
//All two digit examples less than one
//Find Common denominator
//Answer is 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP33
{
    class Program
    {
        static void Main(string[] args)
        {
            double denom, numer, quot;
            string DStr, NStr;
            double CumlativeN = 1, CumlativeD = 1;//set to one so it can be multiplied with no effect
            int limit = 100;//caps the search amount to two digit
            for (numer = 11; numer < limit; numer++)
            {
                if (numer % 10 != 0)//remove trivial numbers
                {
                    NStr = numer.ToString();
                    for (denom = numer + 1; denom < limit; denom++)
                     {
                        if (denom % 10 != 0)//remove trivial numbers
                        {
                            DStr = denom.ToString();
                            quot = numer / denom;
                            if (NStr[0] == DStr[1])//checks if the opposing digits are the same
                            {
                                if(Double.Parse(NStr[1].ToString()) / Double.Parse(DStr[0].ToString()) == quot) // checks the remaining quotenient
                                {
                                    //Console.WriteLine(numer + "/ " + denom + " = " + quot + "\t" + NStr + " / " + DStr + " = " + (Double.Parse(NStr) / Double.Parse(DStr)));
                                    CumlativeN *= numer;
                                    CumlativeD *= denom;//Adds both numbers to ccumlative
                                }
                            }
                            if (NStr[1] == DStr[0])//checks if the opposing digits are the same. Opposite of last statement
                            {
                                if (Double.Parse(NStr[0].ToString()) / Double.Parse(DStr[1].ToString()) == quot) // checks the remaining quotenient
                                {
                                   // Console.WriteLine(numer + "/ " + denom + " = " + quot + "\t" + NStr + " / " + DStr + " = " + (Double.Parse(NStr) / Double.Parse(DStr)));
                                    CumlativeN *= numer;
                                    CumlativeD *= denom;//Adds both numbers to ccumlative
                                }
                            }
                        }
                    }
               }
            }
            //Finding greastest common multiple of Cumlatives
            quot = CumlativeN / CumlativeD;
            int greatest = 1; // Multiple of all integers, which the Cumlatives are in reality
            for (int i = 2; i < CumlativeD / 2 + 1 || i < CumlativeN / 2 + 1; i++)
            {
                if (CumlativeN % i == 0 && CumlativeD % i == 0)//checks to see if multiples of i
                {
                    greatest = i;
                }
            }
            Console.WriteLine(CumlativeD / greatest); //prints the simplified denominator
        }
    }
}
