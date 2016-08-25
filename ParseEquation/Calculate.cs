using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseEquation
{
    public static class Calculate
    {

        /// <summary>
        /// Method: Polynomial - This is the public-facing method that takes a string (the equation) + 
        ///     a decimal[] the decimal values of X, Y, and Z and returns the decimal answer of the equation
        ///     given the input values. 
        /// </summary>
        /// <param name="eq">String - The equation to be evaluated. 
        ///     The equation can include both positive and negative coefficients, positive exponents, 
        ///     and up to 3 indeterminate variable (x,y,z). 
        ///     The operators can only be + or -.</param>
        /// <param name="values">decimal[] - the decimal values of X, Y, and Z (in that order).</param>
        /// <returns>Decimal - The value that the equation produces, given the input values.</returns>
        /// <remarks>The input equation must use '^' as the exponent character. The terms may not have
        /// multiple coefficients. For a good definition of a Polynomial, see Wikipedia. 
        /// 
        ///  Exception handling is done in helper methods, because they have the proper context 
        ///  to provide more details to consumers.</remarks>
        public static decimal StrictPolynomial(string eq, decimal[] values)
        {
            decimal ret = 0;
            Dictionary<int, string> ops = new Dictionary<int, string>();
            List<string> substr = new List<string>();
            List<Term> terms = new List<Term>();

            //make sure equation string follows the rules first
            if (Helper.IsValidEquation(eq))
            {
                ops = Helper.FindOperators(eq);
                substr = Helper.FindTerms(eq, ops);
                terms = Helper.ParseTerms(substr);
                ret = Helper.FinalCalc(ops, terms, values);
            }

            return ret;
        }
    }

}
