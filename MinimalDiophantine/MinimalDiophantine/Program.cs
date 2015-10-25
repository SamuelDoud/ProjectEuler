using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalDiophantine
{
    class Program
    {
        static void Main(string[] args)
        {
            int searchLimit = 1001;
            int diophantine, second;
            double first;
            //int[] arrayOfSquaresLessOne;
            int maxD = 0, maxFirst = 2, maxSecond = 0;
            //arrayOfSquaresLessOne = generateSquares(new int[0], searchLimit * searchLimit);
            for (diophantine = 2; diophantine <= searchLimit; diophantine++)
            {
                if (!isSquare(diophantine))
                {
                    second = 1;
                    first = 0.1;
                    while (first % 1 != 0)
                    {
                        first = Math.Sqrt(second * second * diophantine + 1.0);
                        second++;
                    }
                    
                    if (first % 1 == 0 && first > maxFirst)
                    {
                        maxFirst = (int)first;
                        maxSecond = second - 1;
                        maxD = diophantine;
                       
                    }
                    
                }
            }
            Console.WriteLine(maxFirst + "^2 -" + maxD + "x" + maxSecond + "^2 = 1");
            Console.ReadLine();
        }
        /**
         * This function determines if a passed number is a square number
         */
        static bool isSquare(int number)
        {
            return (Math.Sqrt(number) % 1 == 0);
        }
        static int[] generateSquares(int[] array, int length)
        {
            if (length < array.Length) // the passed length is too short for any copying to take place
                return array;
            int[] newArray = new int[length];
            int i;
            for(i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];//copies the old array into the new one
            }
            for (; i < length; i++)
            {
                newArray[i] = i * i - 1; //puts the new numbers in the array
            }
            return newArray;
        }
    }
}
