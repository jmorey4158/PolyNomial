using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseEquation;

namespace UnitTestParseEquation
{
    public static class TestValues
    {
        public const string eqGood = "17x^4y^3 + -9x^3y^2 + 87x^2y + 19x";
        public const decimal finalValue = 95205m;
        public static decimal[] testVariables = { 3, 4, 5 };

    #region Generate Objects for Tests

    public static List<Term> CreateTerms()
    {
        List<Term> terms = new List<Term>();

        Term term1 = new Term()
        {
            Coefficient = 17,
            xPower = 4,
            yPower = 3,
            zPower = 0
        };
        terms.Add(term1);

        Term term2 = new Term()
        {
            Coefficient = -9,
            xPower = 3,
            yPower = 2,
            zPower = 0
        };
        terms.Add(term2);

        Term term3 = new Term()
        {
            Coefficient = 87,
            xPower = 2,
            yPower = 1,
            zPower = 0
        };
        terms.Add(term3);


        Term term4 = new Term()
        {
            Coefficient = 87,
            xPower = 1,
            yPower = 0,
            zPower = 0
        };
        terms.Add(term4);


        return terms;
    }

    public static Dictionary<int, string> CreateOps()
    {
        Dictionary<int, string> ops = new Dictionary<int, string>();
        ops.Add(12, "+");
        ops.Add(24, "+");
        ops.Add(33, "+");

        return ops;
    }

    public static List<string> CreateTermStrings()
    {
        List<string> termStrings = new List<string>();
        termStrings.Add("17x^4y^3");
        termStrings.Add("-9x^3y^2");
        termStrings.Add("87x^2y");
        termStrings.Add("19x");

        return termStrings;
    }

    public static Euqation CreateEquation()
    {
        Euqation eq = new Euqation();
        


        return eq;
    }

    #endregion
    }



}
