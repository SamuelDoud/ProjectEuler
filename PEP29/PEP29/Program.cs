using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PEP29
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 100;
            List<BigInteger> resultants = new List<BigInteger>();
            for (int a = 2; a <= max; a++)
                for (int b = 2; b <= max; b++)
                    resultants.Add(BigInteger.Pow(new BigInteger(a), b));
            resultants = RemoveDuplicates(resultants);
            resultants.Sort();
        }
        static List<BigInteger> RemoveDuplicates(List<BigInteger> x)
        {
            BigInteger[] i = x.ToArray();
            List<BigInteger> a = new List<BigInteger>();
            for (int j = 0; j < i.Length; j++)
            {
                if(!a.Contains(i[j]))
                {
                    a.Add(i[j]);
                }
            }
            return a;
        }
    }
}
