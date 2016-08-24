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
            Assert.IsTrue(Helper.IsValidEquation(TestValues.eqGood));
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
            Dictionary<int, string> test = Helper.FindOperators(TestValues.eqGood);
            Dictionary<int, string> pattern = TestValues.CreateOps();

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
            List<string> termStr = TestValues.CreateTermStrings();
            List<string> testTerms = Helper.FindTerms(TestValues.eqGood, TestValues.CreateOps());

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
            Dictionary<int, string> expectedOps = TestValues.CreateOps();
            Dictionary<int, string> testOps = Helper.FindOperators(TestValues.eqGood);

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
            List<Term> expectedTerms = TestValues.CreateTerms();
            List<Term> testTerms = Helper.ParseTerms(TestValues.CreateTermStrings());

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
            List<Term> terms = TestValues.CreateTerms();
            decimal testResult = Helper.FinalCalc(TestValues.CreateOps(), terms);

            Assert.AreEqual(TestValues.finalValue, testResult);

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
            Assert.AreEqual<decimal>(TestValues.finalValue, 
                Calculate.StrictPolynomial(TestValues.eqGood, TestValues.testVariables));
        }

        #endregion



    }
}
