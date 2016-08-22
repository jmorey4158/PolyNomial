using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComputeEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            string eqGood = "17x^4y^3 + -9x^3y^2 + 87yx^2 - 19x";
            decimal[] val = { 17, 23, 19 };

            string eqBad1 = "17k^4y^3 + -9x^3y^2 + 87yx^2 - 19x";
            string eqBad2 = "17x^4y^3 * -9x^3y^2 + 87yx^2 - 19x";


            Console.WriteLine(Calculate.ParseEquation(eqBad2));

            Console.ReadKey();

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
        /// multiple coefficients. For a good definition of a Polynomial, see Wikipedia. 
        /// 
        ///  Exception handling is done in helper methods, because they have the proper context 
        ///  to provide more details to consumers.</remarks>
        public static decimal Polynomial(string eq, decimal[] values)
        {
            decimal ret = 0;
            Dictionary<int, string> ops = new Dictionary<int, string>();
            List<string> substr = new List<string>();
            List<SubEquation> subs = new List<SubEquation>();

            //make sure equation string follows the rules first
            if (ParseEquation(eq))
            {
                ops = FindOperators(eq);
                substr = GetSubEquationStrings(eq, ops);
                subs = ParseSubEquation(substr, values);
                ret = FinalCalc(ops, subs);
            }


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
        /// <exception cref="">"The equation was not properly formed. Please check the equation and try again."</exception>
        public static bool ParseEquation(string eq)
        {
            // Regex checks for any 'illegal' characters. No point in continuing if 
            //  if consumer provides bad equation. 
            Regex regx = new Regex(@"[0-9]\s\^\-\+xyz", RegexOptions.IgnoreCase);

            if (regx.IsMatch(eq))
                return true;
            else
                throw new Exception("The equation was not properly formed. Please check the equation and try again.");

        }


        /// <summary>
        /// Private Method: FindOperators - This method parses the equation string to find all of the operators
        ///     and records them and their location in the string. The location is used by ParseSubEquation()
        ///     to split the equation string into a List(SubEquation).
        /// </summary>
        /// <param name="eq">String - The equation to be parsed.</param>
        /// <returns>Dictionary(int, string) - The list of the operators (+,-) and their locations in the equation string.</returns>
        public static Dictionary<int,string> FindOperators(string eq)
        {
            Dictionary<int, string> ops = new Dictionary<int, string>();

            // Iterate through equation string and find all the legal operators
            for (int i = 0; i <= eq.Length; i++)
            {
                // Using switch in case (no pun intended) I want to add more legal operators in future releases
                //  If we find a match add the location in the string and the operator. 
                switch (eq.Substring(i,1))
                {
                   case "-":
                        ops.Add(i, "-");
                        break;
                    case "+":
                        ops.Add(i, "+");
                        break;

                    default:
                        break;
                }
            }
            return ops;
        }


        /// <summary>
        /// Private Method: GetSubEquationStrings - This method splits the equations string and retrieves all of the terms in the 
        ///     equation, using the location of the operators as a hint. The method adds each substring to a List(string).
        ///     This List(string) is passed to ParseSubEquation().
        /// </summary>
        /// <param name="eq">String - The equation to be parsed.</param>
        /// <returns>List(string) - The terms in the equation as strings.</returns>
        public static List<string> GetSubEquationStrings(string eq, Dictionary<int, string> ops)
        {
            List<string> subs = new List<string>();
            string eqCopy = eq;
            // Make sure that the term matches Int[xyz]^Int[xyz]^Int[xyz]^Int
            Regex regx = new Regex(@"^[0-9][xyz]\^[0-9]*[xyz]\^[0-9]*[xyz]\^[0-9]*", RegexOptions.IgnoreCase);


            foreach (KeyValuePair<int, string> kp in ops)
            {
                string sub = eqCopy.Substring(0, kp.Key);
                if (regx.IsMatch(sub))
                {
                    subs.Add(sub);
                    eqCopy = eqCopy.Substring(kp.Key, eqCopy.Length - kp.Key);
                }
                else
                {
                    throw new Exception($"The equation term {sub} was not properly formed. Check the equations and try again.");
                }
            }
            return subs;
        }


        /// <summary>
        /// Private Method: ParseSubEquation - This method creates objects from the term substrings.
        ///     These term objects are used in evaluation of the final answer to the equation.
        ///     The method first parses each substring with a Regex to make sure it conforms to the rules.
        ///     IF the term is not properly formed or as 'illegal' characters, then an Exception is thrown.
        /// </summary>
        /// <returns>List(SubEquation) - A list of all the equations terms as SubEquation objects.</returns>
        /// <remarks>ParseSubEquation() receives its input from GetSubEquationStrings()</remarks>
        /// <exception cref="">"One or more equation terms was not properly formed. Check the equations and try again."</exception>
        public static List<SubEquation> ParseSubEquation(List<string> subeq, decimal[] values)
        {
            List<SubEquation> subs = new List<SubEquation>();


            foreach (var sub in subeq)
            {

            }

            return subs;
        }


        /// <summary>
        /// Private Method: FinalCalc - This method calculates the final decimal answer to the equation.
        /// </summary>
        /// <param name="operators">Dictionary(int,</param>
        /// <param name="subs"></param>
        /// <returns></returns>
        public static decimal FinalCalc(Dictionary<int, string> operators, List<SubEquation> subs)
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
