using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseEquation;
using System.Collections.Generic;

namespace UnitTestParseEquation
{
    [TestClass]
    public class TestStrictPolynomial
    {



        #region Test IsValidEquation

        [TestMethod]
        public void TestIsValidEquation_GoodEquation_ShouldSuccede()
        {
            Assert.IsTrue(Helper.IsValidEquation(KnownGoodValues.knownGoodEquationString));
        }


        [TestMethod]
        public void TestIsValidEquation_BadEquation_ShouldThrowException()
        {
            List<string> badEquations = KnownBadValues.KnownBadEquationStrings();

            foreach (string beq in badEquations)
            {
                Assert.IsFalse(Helper.IsValidEquation(beq));
            }
        }

        #endregion


        #region Test FindOperators

        [TestMethod]
        public void TestFindOperators_GoodEquation_ShouldSuccede()
        {
            Dictionary<int, string> test = Helper.FindOperators(KnownGoodValues.knownGoodEquationString);
            Dictionary<int, string> pattern = KnownGoodValues.KnownGoodOps();

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
            List<string> termStr = KnownGoodValues.KnownGoodTermStrings();
            List<string> testTerms = Helper.FindTerms(KnownGoodValues.knownGoodEquationString, KnownGoodValues.KnownGoodOps());

            Assert.AreEqual<List<string>>(termStr, testTerms);
        }

        [TestMethod]
        public void TestFindTerms_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
        }


        #endregion


        #region Test FindExponent

        [TestMethod]
        public void TestFindExponent_GoodEquation_ShouldSuccede()
        {
            Dictionary<int, string> expectedOps = KnownGoodValues.KnownGoodOps();
            Dictionary<int, string> testOps = Helper.FindOperators(KnownGoodValues.knownGoodEquationString);

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
            List<Term> expectedTerms = KnownGoodValues.KnownGoodTerm();
            List<Term> testTerms = Helper.ParseTerms(KnownGoodValues.KnownGoodTermStrings());

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
            List<Term> terms = KnownGoodValues.KnownGoodTerm();
            decimal testResult = Helper.FinalCalc(KnownGoodValues.KnownGoodOps(), terms, KnownGoodValues.knownGoodVariableValues);

            Assert.AreEqual(KnownGoodValues.knownFinalAnswer, testResult);

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
            Assert.AreEqual<decimal>(KnownGoodValues.knownFinalAnswer, 
                Calculate.StrictPolynomial(KnownGoodValues.knownGoodEquationString, KnownGoodValues.knownGoodVariableValues));
        }

        #endregion



    }
}
