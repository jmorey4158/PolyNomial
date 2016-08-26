using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseEquation;

namespace UnitTestParseEquation
{
    public static class KnownGood
    {
        public const string EquationString = "17x^4y^3 + -9x^3y^2 + 87x^2y + 19x";
        public static decimal[] VariableValues = { 3, 4 };
        public const decimal FinalAnswer = 95205;
        public static decimal[] TermCalValues = { 88128, -3888, 3132, 57 };


        #region Generate KnownGood Objects for Tests
        /// <summary>
        /// Test Help Method KnownGoodTerm - Creates a List(Term) of known good Term instances. 
        ///     These Term instances are manually-constructed from the KnownGoodEquation and are pivotal to 
        ///     Pas-testing.
        /// </summary>
        /// <returns>List(Term) of known good Term instances.</returns>
        public static List<Term> TermList()
        {
            List<Term> terms = new List<Term>();

            // 17x^4y^3
            Term term1 = new Term()
            {
                Coefficient = 17,
                xPower = 4,
                yPower = 3
            };
            terms.Add(term1);

            // -9x^3y^2
            Term term2 = new Term()
            {
                Coefficient = -9,
                xPower = 3,
                yPower = 2
            };
            terms.Add(term2);

            // 87x^2y
            Term term3 = new Term()
            {
                Coefficient = 87,
                xPower = 2,
                yPower = 1
            };
            terms.Add(term3);

            // 19x
            Term term4 = new Term()
            {
                Coefficient = 19,
                xPower = 1,
                yPower = 0
            };
            terms.Add(term4);


            return terms;
        }



        /// <summary>
        /// Test Help Method KnownGoodOps - Creates a Dictionary(int, string) of known good operators. 
        ///     These operators are manually-constructed from the KnownGoodEquation and are pivotal to 
        ///     Pas-testing.
        /// </summary>
        /// <returns>Dictionary(int, string) of known good operators.</returns>
        public static Dictionary<int, string> OpsList()
        {
            Dictionary<int, string> ops = new Dictionary<int, string>();
            ops.Add(9, "+");
            ops.Add(20, "+");
            ops.Add(29, "+");

            return ops;
        }


        /// <summary>
        /// Test Help Method KnownGoodTermStrings - Creates a List(string) of known good Term strings. 
        ///     These strings are manually-constructed from the KnownGoodEquation and are pivotal to 
        ///     Pas-testing.
        /// </summary>
        /// <returns> List(string) of known good Term strings.</returns>
        public static List<string> TermStrings()
        {
            List<string> termStrings = new List<string>();
            termStrings.Add("17x^4y^3");
            termStrings.Add("-9x^3y^2");
            termStrings.Add("87x^2y");
            termStrings.Add("19x");

            return termStrings;
        }


        /// <summary>
        /// Test Help Method KnownGoodEquation - Creates an Equation class instance from known good values. 
        ///     This instance manually-constructed from the KnownGoodEquation and other known-good values
        ///     and are pivotal to Pass-testing.
        /// </summary>
        /// <returns>Equation class instance that is known to be good.</returns>
        public static Euqation EquationInstance()
        {
            Euqation eq = new Euqation();
        


            return eq;
        }

        #endregion
    }


    public static class KnownBad
    {

        public const string EquationString1 = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        public const string EquationString2 = "17x^4y^3x^2 * -9x^3y^2z + 87x^2y + 19x"; // has wrong operator '*'
        public const string EquationString3 = "17y^4x^3x^2 + -9x^3y^2z + 87x^2y + 19x"; // has wrong order of variables
        public const string EquationString4 = "17y^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"; // has duplicate variable 'y'


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
