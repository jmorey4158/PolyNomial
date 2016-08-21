using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseEquation
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

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
        /// multiple coefficients. For a good definition of a Polynomial, see Wikipedia. </remarks>
        public static decimal Polynomial(string eq, decimal[] values)
        {
            decimal ret = 0;



            return ret;
        }

        /// <summary>
        /// Private Method: ParseEquation - This method parses the string equations to make sure that the 'rules' 
        ///     are being followed. If an characters other than'-', '+', '^', 'x', 'y', 'z' or numbers
        ///     are in the string, an Exception will be thrown.
        ///     
        ///     ParseEquation also checks to make sure that one and only one coefficient is present in any term. 
        ///     if not, an Exception will be thrown. This keeps us from waisting our time with naughty equations.
        /// </summary>
        /// <param name="eq">String - The equation to be parsed.</param>
        /// <returns>Boolean - True if the given equation follows the rules or False if not</returns>
        private static bool ParseEquation(string eq)
        {
            bool parse = false;



            return parse;
        }


        /// <summary>
        /// Private Method: FindOperators - This method parses the equation string to find all of the operators
        ///     and records them and their location in the string. The location is used by ParseSubEquation()
        ///     to split the equation string into a List(SubEquation).
        /// </summary>
        /// <param name="eq">String - The equation to be parsed.</param>
        /// <returns>Dictionary(int, string) - The list of the operators (+,-) and their locations in the equation string.</returns>
        private static Dictionary<int,string> FindOperators(string eq)
        {
            Dictionary<int, string> ops = new Dictionary<int, string>();



            return ops;
        }


        /// <summary>
        /// Private Method: ParseSubEquation - This method creates objects from the terms in the equation string.
        ///     These term objects are used in evaluation of the final answer to the equation.
        /// </summary>
        /// <returns>List(SubEquation)</returns>
        private static List<SubEquation> ParseSubEquation()
        {
            List<SubEquation> subs = new List<SubEquation>();




            return subs;
        }


        /// <summary>
        /// Private Method: FinalCalc - This method calculates the final decimal answer to the equation.
        /// </summary>
        /// <param name="operators">Dictionary(int,</param>
        /// <param name="subs"></param>
        /// <returns></returns>
        private static decimal FinalCalc(Dictionary<int, string> operators, List<SubEquation> subs)
        {
            decimal final = 0;

            return final;
        }


    }


    /// <summary>
    /// Public Class SubEquation - This class is used to represent the terms in the equation in a way that computer-based calculation can be done.
    /// </summary>
    public class SubEquation
    {
        public SubEquation() { }


        public int Coefficient { get; set; }

        public int TermX { get; set; }

        public int TermY { get; set; }

        public int TermZ { get; set; }

    }
}
