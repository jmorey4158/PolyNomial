using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseEquation;
using System.Collections.Generic;

namespace UnitTestParseEquation
{
    [TestClass]
    public class TestStrictPolynomial
    {
        private const string eqGood = "17x^4y^3 + -9x^3y^2 + 87x^2y + 19x";
        private const decimal finalValue = 0;
        private decimal[] testVariables = { 3, 4, 5 };


        #region Test IsValidEquation

        [TestMethod]
        public void TestIsValidEquation_GoodEquation_ShouldSuccede()
        {
            Assert.IsTrue(Helper.IsValidEquation(eqGood));
        }

        [TestMethod]
        public void TestIsValidEquation_BadEquation_ShouldThrowException()
        {
            // Setting up multiple wrong ways to test each one
            List<string> BadEqs = new List<string>();
            BadEqs.Add("17k^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"); //has wrong variable 'k'
            BadEqs.Add("17x^4y^3x^2 * -9x^3y^2z + 87x^2y + 19x"); // has wrong operator '*'
            BadEqs.Add("17y^4x^3x^2 + -9x^3y^2z + 87x^2y + 19x"); // has wrong order of variables
            BadEqs.Add("17y^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"); // has duplicate variable 'y'

            foreach (string beq in BadEqs)
            {
                Assert.IsFalse(Helper.IsValidEquation(beq));
            }
        }

        #endregion


        #region Test FindOperators

        [TestMethod]
        public void TestFindOperators_GoodEquation_ShouldSuccede()
        {
            Dictionary<int, string> test = Helper.FindOperators(eqGood);
            Dictionary<int, string> pattern = CreateOps();

            Assert.AreEqual<Dictionary<int, string>>(pattern, test);

        }

        [TestMethod]
        public void TestFindOperators_BadEquation_ShouldThrowException()
        {
        }


        #endregion



        #region Test FindTerms

        [TestMethod]
        public void TestFindTerms_GoodEquation_ShouldSuccede()
        {
            List<string> termStr = CreateTermStrings();
            List<string> testTerms = Helper.FindTerms(eqGood, CreateOps());

            Assert.AreEqual<List<string>>(termStr, testTerms);
        }

        [TestMethod]
        public void TestFindTerms_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        }


        #endregion


        #region Test FindExponent

        [TestMethod]
        public void TestFindExponent_GoodEquation_ShouldSuccede()
        {
            Dictionary<int, string> expectedOps = CreateOps();
            Dictionary<int, string> testOps = Helper.FindOperators(eqGood);

            Assert.AreEqual<Dictionary<int, string>>(expectedOps, testOps);

        }

        [TestMethod]
        public void TestFindExponent_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        }


        #endregion



        #region Test PareseTerms

        [TestMethod]
        public void TestParseTerms_GoodEquation_ShouldSuccede()
        {
            List<Term> expectedTerms = CreateTerms();
            List<Term> testTerms = Helper.ParseTerms(CreateTermStrings());

            Assert.AreEqual<List<Term>>(expectedTerms, testTerms);

        }

        [TestMethod]
        public void TestParseTerms_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        }


        #endregion



        #region Test FinalCal

        [TestMethod]
        public void TestFinalCal_GoodEquation_ShouldSuccede()
        {
            List<Term> terms = CreateTerms();
            decimal testResutl = Helper.FinalCalc(CreateOps(), terms);

            Assert.AreEqual(finalValue, testResutl);

        }

        [TestMethod]
        public void TestFinalCal_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        }

        #endregion



        #region Test StrictPolynomial

        [TestMethod]
        public void TestStrictPolynomial_GoodEquation_ShouldSuccede()
        {
            Assert.AreEqual<decimal>(finalValue, Calculate.StrictPolynomial(eqGood, testVariables));
        }

        #endregion



        #region Generate Objects for Tests

        private List<Term> CreateTerms()
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

        private Dictionary<int, string> CreateOps()
        {
            Dictionary<int, string> ops = new Dictionary<int, string>();
            ops.Add(12, "+");
            ops.Add(24, "+");
            ops.Add(33, "+");

            return ops;
        }

        private List<string> CreateTermStrings()
        {
            List<string> termStrings = new List<string>();
            termStrings.Add("17x^4y^3");
            termStrings.Add("-9x^3y^2");
            termStrings.Add("87x^2y");
            termStrings.Add("19x");

            return termStrings;
        }

        #endregion
    }
}
