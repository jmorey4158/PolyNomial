using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestParseEquation;
using ParseEquation;
using System.Text.RegularExpressions;

namespace AdHocTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // KnownGood 17x^4y^3
            // FUll Regex string '^\-?[0-9]+x\^[0-9]+?y\^[0-9]+'
            Regex regx = new Regex(@"^\-?[0-9]+x\^{1}\d+[y\^{1}\d+]?", RegexOptions.IgnoreCase);

            List<string> good = KnownGood.TermStrings();

            foreach (var g in good)
            {
                Console.WriteLine($"Pattern: {regx}\nTerm: {g}\nPassed: {regx.IsMatch(g)}\n");
            }

            //string g = "17x^33^4";
            //Console.WriteLine($"Pattern: {regx}\nTerm: {g}\nPassed: {regx.IsMatch(g)}\n");




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


    public class OldCode
    {
        //List<string> good = KnownGood.TermStrings();

        //string tg = "-9x^3y^2"; // KnownGood
        //string tb1 = "17K^4y^3"; // Bad - has 'K' variable
        //string tb2 = "17x^^4y^3"; // Bad - has extra '^'
        //string tb3 = "17x^ 4y^3"; // Bad - has space between 'x' and 'y'
        //string tb4 = "17 x^4y^3"; // Bad - has space between coeff. and 'x'

        //    foreach (var g in good)
        //    {
        //        Console.WriteLine($"Pattern: {regx}\nTerm: {g}\nPassed: {regx.IsMatch(g)}\n");
        //    }
        //    Console.WriteLine("\n\n");

        //    Console.WriteLine($"Pattern: {regx}\nTerm: {tb1}\nPassed: {regx.IsMatch(tb1)}\n");
        //    Console.WriteLine($"Pattern: {regx}\nTerm: {tb2}\nPassed: {regx.IsMatch(tb2)}\n");
        //    Console.WriteLine($"Pattern: {regx}\nTerm: {tb3}\nPassed: {regx.IsMatch(tb3)}\n");
        //    Console.WriteLine($"Pattern: {regx}\nTerm: {tb4}\nPassed: {regx.IsMatch(tb4)}\n");

    }

}
