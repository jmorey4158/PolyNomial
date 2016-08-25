using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseEquation;

namespace UnitTestParseEquation
{
    public static class KnownGoodValues
    {
        public const string knownGoodEquationString = "17x^4y^3 + -9x^3y^2 + 87x^2y + 19x";
        public const decimal knownFinalAnswer = 95205m;
        public static double[] knownGoodVariableValues = { 3, 4};

        public const string knownBadEquationString1 = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        public const string knownBadEquationString2 = "17x^4y^3x^2 * -9x^3y^2z + 87x^2y + 19x"; // has wrong operator '*'
        public const string knownBadEquationString3 = "17y^4x^3x^2 + -9x^3y^2z + 87x^2y + 19x"; // has wrong order of variables
        public const string knownBadEquationString4 = "17y^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"; // has duplicate variable 'y'





        #region Generate KnownGood Objects for Tests

        public static List<Term> KnownGoodTerm()
        {
            List<Term> terms = new List<Term>();

            Term term1 = new Term()
            {
                Coefficient = 17,
                xPower = 4,
                yPower = 3
            };
            terms.Add(term1);

            Term term2 = new Term()
            {
                Coefficient = -9,
                xPower = 3,
                yPower = 2
            };
            terms.Add(term2);

            Term term3 = new Term()
            {
                Coefficient = 87,
                xPower = 2,
                yPower = 1
            };
            terms.Add(term3);


            Term term4 = new Term()
            {
                Coefficient = 87,
                xPower = 1,
                yPower = 0
            };
            terms.Add(term4);


            return terms;
        }

        public static Dictionary<int, string> KnownGoodOps()
        {
            Dictionary<int, string> ops = new Dictionary<int, string>();
            ops.Add(12, "+");
            ops.Add(24, "+");
            ops.Add(33, "+");

            return ops;
        }

        public static List<string> KnownGoodTermStrings()
        {
            List<string> termStrings = new List<string>();
            termStrings.Add("17x^4y^3");
            termStrings.Add("-9x^3y^2");
            termStrings.Add("87x^2y");
            termStrings.Add("19x");

            return termStrings;
        }

        public static Euqation KnownGoodEquation()
        {
            Euqation eq = new Euqation();
        


            return eq;
        }

        #endregion


    }


    public static class KnownBadValues
    {
        #region Generate KnownBadObjects for Tests

        // Setting up multiple wrong ways to test each one
        public static List<string> KnownBadEquationStrings()
        {
            List<string> KnownBadEquationStrings = new List<string>();
            KnownBadEquationStrings.Add("17k^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"); //has wrong variable 'k'
            KnownBadEquationStrings.Add("17x^4y^3x^2 * -9x^3y^2z + 87x^2y + 19x"); // has wrong operator '*'
            KnownBadEquationStrings.Add("17y^4x^3x^2 + -9x^3y^2z + 87x^2y + 19x"); // has wrong order of variables
            KnownBadEquationStrings.Add("17y^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"); // has duplicate variable 'y'

            return KnownBadEquationStrings;
        }


        #endregion


    }



}
