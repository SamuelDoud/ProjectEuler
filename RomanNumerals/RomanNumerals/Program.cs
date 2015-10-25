using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RomanNumerals
{
    class Program
    {
        
        public static Char[] romanNumerals = {'I','V','X','L','C','D','M' };
        public static char[] validSubtractors = { 'I', 'X', 'C' };//can be accessed by n-1 / 2
        public static int[] romanValues = { 1, 5, 10, 50, 100, 500, 1000 };
        public static int[] romanSubValues = { 1, 10, 100 };
        public static void Main(string[] args)
        {
            List<String> romanNums = new List<string>();
            StreamReader reader = new StreamReader("roman.txt");
            int countOfLetters = 0;
            while (!reader.EndOfStream)
            {
                romanNums.Add(reader.ReadLine());
            }
            int count = 0;
            String temp;
            foreach (string s in romanNums)
            {
                temp = createRomanNumeral(valueOfRomanNumeral(s));
                Console.WriteLine(++count + " was: " + s + " is now " + temp + " with length " + temp.Length + " improvement of " + (s.Length - temp.Length));
                countOfLetters += s.Length - temp.Length;
            }
            reader.Close();
            Console.WriteLine(countOfLetters);
            Console.ReadLine();
        }

        public static String createRomanNumeral(int num)
        {
            String roman = "";
            int[] legalValues = { 1000, 900, 500, 400, 100, 90 ,50, 40, 10, 9, 5, 4, 1 };
            string[] legalStrings = {"M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};
            int tempCount;
            for (int currentValueIndex = 0; currentValueIndex < legalValues.Length && num !=0; currentValueIndex++ )
            {
                tempCount = num / legalValues[currentValueIndex];
                num %= legalValues[currentValueIndex];
                for (int i = 0; i < tempCount; i++)
                {
                    roman += legalStrings[currentValueIndex];
                }
            }

                return roman;
        }

        public static int valueOfRomanNumeral(String romanNum)
        {
            List<int> letters = valueOfLetters(romanNum);
            letters = combineSubtractors(letters);
            return letters.Sum();
        }
        public static List<int> valueOfLetters(String romanNum)
        {
            List<int> values = new List<int>();
            foreach (char c in romanNum)
            {
                values.Add(valueOfLetter(c));
            }
            return values;
        }

        public static int valueOfLetter(char c)
        {
            return romanValues[Array.IndexOf(romanNumerals, c)];
        }

        public static List<int> combineSubtractors(List<int> values)
        {
            int subValue;
            for (int i = 1; i < values.Count; i++)
            {
                subValue = validSubtractorValue(values[i]);//the valid sutraction value
                if (values[i-1] == subValue)
                {
                    //subtractor found
                    values[i] = values[i] - values[i-1];
                    values.RemoveAt(i-1);//remove the subtractor from the list
                    i--;//since the list is one smaller we must back track on 
                }
            }
            return values;
        }
        public static int validSubtractorValue(int baseValue)
        {
            if(baseValue == 1)
            {
                return -1;
            }
            return romanSubValues[(Array.IndexOf(romanValues, baseValue) - 1) / 2];
        }

    }
}
