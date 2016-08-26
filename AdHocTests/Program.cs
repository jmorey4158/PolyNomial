using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestParseEquation;
using ParseEquation;

namespace AdHocTests
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Dictionary<int, string> test = Helper.FindOperators(KnownGood.EquationString);
            test.OrderBy(pair => pair.Key);

            Dictionary<int, string> pattern = KnownGood.OpsList();
            pattern.OrderBy(pair => pair.Key);

            Console.WriteLine( CompareDictionary(pattern, test) );


            Console.ReadKey();
        }


        public static bool CompareDictionary(Dictionary<int, string> pattern, Dictionary<int, string> test)
        {
            
            int[] pkeys = new int[pattern.Count];
            string[] pvals = new string[pattern.Count];

            int[] tkeys = new int[test.Count];
            string[] tvals = new string[test.Count];


            int i = 0;
            foreach (KeyValuePair<int,string> kp in pattern)
            {
                pkeys[i] = kp.Key;
                pvals[i] = kp.Value;
                i++;
            }
            i = 0;
            foreach (KeyValuePair<int,string> kp in test)
            {
                tkeys[i] = kp.Key;
                tvals[i] = kp.Value;
                i++;
            }

            for (int k = 0; k < pkeys.Length; k++)
            {
                if (pkeys[k] != tkeys[k])
                    return false;

                if (pvals[k] != tvals[k])
                    return false;
            }

            return true;
        }


    }

}
