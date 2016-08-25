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

            List<Term> t = KnownGood.TermList();
            var v = KnownGood.VariableValues;
            var c = KnownGood.TermCalValues;

            for (int i = 0; i < t.Count(); i++)
            {
                Console.WriteLine($"Should Be: {c[i]}\t\tIs: {Helper.CalculateTerm(t[i], v)}");
            }

            Console.ReadKey();
        }
    }
}
