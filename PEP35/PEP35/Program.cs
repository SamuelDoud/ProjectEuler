//Samuel Doud
//August 24, 2014
//Project Euler problem 35
//How many circular primes below 1 million?
//Answer: 55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP35
{
    class Program
    {
        public static int max = 1000000;//how many numbers to search through
        public static bool[] primes = new bool[max];//false is prime, true is composite
        
        static void Main(string[] args)
        {
            int index = 0;
            string temp;
            bool flipper;
            for (int i = 2; i < Math.Sqrt(max); i++)// i goes to sqrt of max
            {
                for (int j = 2; j * i < max; j++)// i * j goes to max
                {
                    primes[j * i] = true;//sets the product to not prime
                }
            }//sieve of Erathosenes
            index++;//increments the number of circular primes by one
            //Console.WriteLine(2);//adds two because of its special nature as an even prime
            for (int i = 3; i < max; i+=2)//Looks through all numbers less 0, 1, and 2 and checks to see if they are circuar prime
            {
                //another optimization; check all digits to see if they are odd, less two
                temp = i.ToString();
                flipper = true;
                foreach (char c in temp)
                {
                    if (int.Parse(c.ToString()) % 2 == 0)//if any digit is even flipper is false and breaks the loop
                    {
                        flipper = false;
                        break;
                    }
                }
                if (flipper && !primes[i] && AllPrime(Rotate(i)))//Checks to see if i is worth checking and if a rotation array of i is all prime
                {
                    index++;//increments the number of cirular primes by one
                   // Console.WriteLine(i);//prints the circular prime for giggles
                }
            }
        }
        static bool AllPrime(int[] numbers)
        {
            foreach (int i in numbers)//iterates through each member of numbers
            {
                if (primes[i])//if member is true in primes then false is returned
                    return false;
            }
            return true;//if false is not returned for all members then true is returned
        }
        static int[] Rotate(int number)//Returns an array of ints that represents all rotations from a given int. 
        {
            string NumStr = number.ToString();
            int[] Combo = new int[NumStr.Length];
            string temp;
            int mod;
            for (int i = 0; i < NumStr.Length; i++)//i represents the number of ints to be created. Also it pushes the indivdual numbers of a int over i times
            {
                temp = ""; //Clears the string
                //197, 971, 719; test values
                for (int j = 1; j <= NumStr.Length; j++) //j moves through the individual numbers of an int.
                {
                    mod = (j + i) % (Combo.Length);//Ensures that mod never goes above the lenght of the string
                    temp = temp + NumStr[mod]; //adds the target character to the string
                }
                Combo[i] = int.Parse(temp); //Parses the string to an int and adds it to the array
            }
            return Combo;
           
        }
    }
}
