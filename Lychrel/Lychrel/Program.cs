using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lychrel
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterationLimit = 100;//how many iterations will be performed on each number
            int numberLimit = 25000;//the limit of the search
            int lychrelCount = numberLimit;//all numbers are assumed lychrel until to proven otherwise
            double thisSum, thisSumPalindrome;
            for (int baseNum = 1; baseNum <= numberLimit; baseNum++)
            {//baseNum is the starting point of each cycle limited by the given NumberLimit
                thisSum = baseNum;//reset this sum to the current number
                thisSumPalindrome = Palindrome(thisSum);
                for (int depth = 0; depth < iterationLimit; depth++)
                {//iteration depth is limited to the value of iterationLimit
                    thisSum = thisSumPalindrome + thisSum;//adds the current thisSum and its reverse to a new thisSum
                    thisSumPalindrome = Palindrome(thisSum);
                    if(thisSum == thisSumPalindrome)//this sum is a palindrome
                    {
                        lychrelCount--;
                        //palindrome found, this loop is now unessary
                        break;
                    }

                }
            }
            Console.WriteLine(lychrelCount);//print the count
            Console.ReadLine();//hold the console open
        }
        public static double Palindrome(double num)
        {
            double palindromeOfNum = 0;//the number that will be returned
            int numOfDigits = (int)Math.Log10(num) + 1; //tje number of digits in num
            double temp; //a temporary holding double
            for (int i = 0; i < numOfDigits; i++)
            {
                //logic to reverse the number
                temp = num % (Math.Pow(10, i + 1)) - num % Math.Pow(10,i);
                palindromeOfNum += temp * Math.Pow(10,numOfDigits - 2*i - 1);
            }
                return palindromeOfNum;
        }
        public static bool isPalindrome(double num)
        {
            //compares num to it's reverse to see if its palindromic
            return num == Palindrome(num);
        }
    }
}
