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
            decimal kg = KnownGood.FinalAnswer;
            decimal t = Calculate.StrictPolynomial(KnownGood.EquationString, KnownGood.VariableValues);
            Console.WriteLine($"KG ANswer: {kg}\nTest Answer: {t}\nAreEqual: {kg == t}");
                
            Console.ReadKey();
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
