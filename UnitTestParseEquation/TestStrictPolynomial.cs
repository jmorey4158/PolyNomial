using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseEquation;

namespace UnitTestParseEquation
{
    [TestClass]
    public class TestStrictPolynomial
    {
        #region Test IsValidEquation


        [TestMethod]
        public void TestIsValidEquation_GoodEquation_ShouldSuccede()
        {
            string eqGood = "17x^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x";
            string eqBad = "The quick brown fox jumped over the lazy dogs.";

            Assert.IsTrue(Helper.IsValidEquation(eqBad));
        }

        [TestMethod]
        public void TestIsValidEquation_BadEquation_ShouldThrowException()
        {
            // Setting up multiple wrong ways to test each one
            string eqBad1 = "17k^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"; //has wrong variable 'k'
            string eqBad2 = "17x^4y^3x^2 * -9x^3y^2z + 87x^2y + 19x"; // has wrong operator '*'
            string eqBad3 = "17y^4x^3x^2 + -9x^3y^2z + 87x^2y + 19x"; // has wrong order of variables
            string eqBad4 = "17y^4y^3x^2 + -9x^3y^2z + 87x^2y + 19x"; // has duplicate variable 'y'

            Assert.IsFalse(Helper.IsValidEquation(eqBad1));
            Assert.IsFalse(Helper.IsValidEquation(eqBad2));
            Assert.IsFalse(Helper.IsValidEquation(eqBad3));
            Assert.IsFalse(Helper.IsValidEquation(eqBad4));
        }

        #endregion


        #region Test FindOperators

        [TestMethod]
        public void TestFindOperators_GoodEquation_ShouldSuccede()
        {
            string eqGood = "17x^4y^3 + -9x^3y^2 + 87yx^2 + 19x";

        }

        [TestMethod]
        public void TestFindOperators_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^4y^3   -9x^3y^2 + 87yx^2 + 19x"; // Missing operator '  '
        }


        #endregion


        #region Test FindTerms

        [TestMethod]
        public void TestFindTerms_GoodEquation_ShouldSuccede()
        {
            string eqGood = "17x^4y^3 + -9x^3y^2 + 87yx^2 + 19x";

        }

        [TestMethod]
        public void TestFindTerms_BadEquation_ShouldThrowException()
        {
            // Should throw Exception("The equation was not properly formed. Please check the equation and try again.")
            string eqBad = "17x^^4y^3 + -9x^3y^2 + 87yx^2 + 19x"; // Extra '^' char





        }


        #endregion














    }
}
