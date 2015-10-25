using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEP205
{
    class Program
    {
        static void Main(string[] args)
        {
            int sidesOfPyrDie = 4, sidesOfCubeDie = 6, numOfPyrDie = 9, numOfCubeDie = 6;
            double TotalGames = 0, pyrWins = 0, cubeWins = 0, ties = 0;
            int pG = 0, cG = 0;
            int pyrMaxRoll = numOfPyrDie * sidesOfPyrDie;
            int cubeMaxRoll = numOfCubeDie * sidesOfCubeDie;
            double[] cubeRolls = new double[cubeMaxRoll + 1];
            double[] pyrRolls = new double[pyrMaxRoll + 1];
            cubeRolls = cont(cubeRolls, 0, sidesOfCubeDie, numOfCubeDie);
            pyrRolls = cont(pyrRolls, 0, sidesOfPyrDie, numOfPyrDie);
            foreach (int p in pyrRolls)
            {
                pG += p;
            }
            for (int i = 0; i < pyrRolls.Length; i++)
            {
                pyrRolls[i] /= pG;
            }

            foreach (int c in cubeRolls)
            {
                cG += c;
            }
            for (int i = 0; i < cubeRolls.Length; i++)
            {
                cubeRolls[i] /= cG;
            }
            for (int p = numOfPyrDie; p < pyrRolls.Length; p++ )
            {
                if (p < cubeRolls.Length)
                {
                    ties += pyrRolls[p] * cubeRolls[p];
                    for (int c = p - 1; c >= numOfCubeDie; c--)
                    {
                        pyrWins += (cubeRolls[c] * pyrRolls[p]);
                    }
                    
                }
            }
                TotalGames = ties + cubeWins + pyrWins;
            Console.WriteLine((pyrWins));
            Console.WriteLine(ties);
            Console.WriteLine((1 - pyrWins - ties));
            Console.ReadLine();
        }
        public static double[] cont(double[] x, int index, int max, int depth)
        {
            for (int i = 1; i <= max; i++)
            {
                if (depth == 0)
                {
                    x[index]++;
                    return x;
                }
                else
                {
                    x = cont(x, index + i, max, depth - 1);
                }
            }
            return x;
        }
    }
}
