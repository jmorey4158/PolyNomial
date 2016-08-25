﻿using System;
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
            Assert.IsTrue(Helper.IsValidEquation(KnownGood.EquationString));
        }


        [TestMethod]
        public void TestIsValidEquation_BadEquation_ShouldThrowException()
        {
            List<string> badEquations = KnownBad.KnownBadEquationStrings();

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
            Dictionary<int, string> test = Helper.FindOperators(KnownGood.EquationString);
            Dictionary<int, string> pattern = KnownGood.OpsList();

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
            List<string> termStr = KnownGood.TermStrings();
            List<string> testTerms = Helper.FindTerms(KnownGood.EquationString, KnownGood.OpsList());

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
            Dictionary<int, string> expectedOps = KnownGood.OpsList();
            Dictionary<int, string> testOps = Helper.FindOperators(KnownGood.EquationString);

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
            List<Term> expectedTerms = KnownGood.TermList();
            List<Term> testTerms = Helper.ParseTerms(KnownGood.TermStrings());

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
            List<Term> terms = KnownGood.TermList();
            decimal testResult = Helper.FinalCalc(KnownGood.OpsList(), terms, KnownGood.VariableValues);

            Assert.AreEqual(KnownGood.FinalAnswer, testResult);

        }

        [TestMethod]
        public void TestFinalCal_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
        }

        #endregion


        #region Test CalculateTerm

        [TestMethod]
        public void TestCalculateSingleTerm_GoodTerm_ShouldSuccede()
        {
            Term t = KnownGood.TermList()[0];
            decimal kgVal = KnownGood.TermCalValues[0];

            Assert.AreEqual(kgVal, Helper.CalculateTerm(t, KnownGood.VariableValues));
        }


        [TestMethod]
        public void TestCalculateTermList_GoodTerm_ShouldSuccede()
        {
            for (int i = 0; i < KnownGood.TermList().Count; i++)
            {
                Assert.AreEqual<decimal>(KnownGood.TermCalValues[i], 
                    Helper.CalculateTerm(KnownGood.TermList()[i], KnownGood.VariableValues));
            }
        }



        [TestMethod]
        public void TestCalculateTerm_BadTerm_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
        }

        #endregion



        #region Test StrictPolynomial

        [TestMethod]
        public void TestStrictPolynomial_GoodEquation_ShouldSuccede()
        {
            Assert.AreEqual<decimal>(KnownGood.FinalAnswer, 
                Calculate.StrictPolynomial(KnownGood.EquationString, KnownGood.VariableValues));
        }

        #endregion



    }
}
