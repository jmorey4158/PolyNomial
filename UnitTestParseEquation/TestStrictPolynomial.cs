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
            Assert.IsTrue( Helper.IsValidEquation( KnownGood.EquationString ));
        }


        [TestMethod]
        [ExpectedException(typeof(ParseEquation.ParseEquationException))]
        public void TestIsValidEquation_BadEquation_ShouldThrowException()
        {
            List<string> badEquations = KnownBad.KnownBadEquationStrings();

            foreach (string beq in badEquations)
            {
                Assert.IsFalse( Helper.IsValidEquation(beq) );
            }
        }

        #endregion


        #region Test FindOperators

        [TestMethod]
        public void TestFindOperators_GoodEquation_ShouldSuccede()
        {
            Dictionary<int, string> test = Helper.FindOperators( KnownGood.EquationString );
            Dictionary<int, string> pattern = KnownGood.OpsList();

            if(test.Count == pattern.Count)
            {
                foreach (KeyValuePair<int, string> kp in pattern)
                {
                    Assert.IsTrue( CompareDictionary( pattern, test) );
                }
            }
        }

        [TestMethod]
        public void TestFindOperators_BadEquation_ShouldThrowException()
        {
            List<Dictionary<int, string>> badTests = new List<Dictionary<int, string>>();
            Dictionary<int, string> test = Helper.FindOperators(KnownBad.EquationString1);
            Dictionary<int, string> pattern = KnownGood.OpsList();

            foreach (var t in badTests)
            {
                if (t.Count == pattern.Count)
                {
                    foreach (KeyValuePair<int, string> kp in pattern)
                    {
                        Assert.IsFalse( CompareDictionary(pattern, t) );
                    }
                }
            }

        }


        #endregion



        #region Test FindTerms

        [TestMethod]
        public void TestFindTerms_GoodEquation_ShouldSuccede()
        {
            List<string> termStr = KnownGood.TermStrings();
            List<string> testTerms = Helper.FindTerms(KnownGood.EquationString, KnownGood.OpsList());

            for (int i = 0; i < termStr.Count; i++)
            {
                Assert.AreEqual<string>(termStr[i], testTerms[i]);
            }
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

            Assert.IsTrue( CompareDictionary(expectedOps,  testOps) );

        }

        [TestMethod]
        public void TestFindExponent_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        }


        #endregion



        #region Test PareseTerms - NOT COMPLETE

        [TestMethod]
        public void TestParseTerms_GoodEquation_ShouldSuccede()
        {
            List<Term> expectedTerms = KnownGood.TermList();
            List<Term> testTerms = Helper.ParseTerms(KnownGood.TermStrings());

            for (int i = 0; i < expectedTerms.Count; i++)
            {
                Assert.IsTrue( expectedTerms[i] == testTerms[i] );
            }
 

        }

        [TestMethod]
        public void TestParseTerms_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char
        }


        #endregion



        #region Test FinalCal - NOT COMPLETE

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



        #region Test StrictPolynomial - NOT COMPLETE

        [TestMethod]
        public void TestStrictPolynomial_GoodEquation_ShouldSuccede()
        {
            Assert.AreEqual<decimal>(KnownGood.FinalAnswer, 
                Calculate.StrictPolynomial(KnownGood.EquationString, KnownGood.VariableValues));
        }

        #endregion



        #region Helper Methods

        public static bool CompareDictionary(Dictionary<int, string> pattern, Dictionary<int, string> test)
        {

            int[] pkeys = new int[pattern.Count];
            string[] pvals = new string[pattern.Count];

            int[] tkeys = new int[test.Count];
            string[] tvals = new string[test.Count];


            int i = 0;
            foreach (KeyValuePair<int, string> kp in pattern)
            {
                pkeys[i] = kp.Key;
                pvals[i] = kp.Value;
                i++;
            }
            i = 0;
            foreach (KeyValuePair<int, string> kp in test)
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


        #endregion
    }
}
