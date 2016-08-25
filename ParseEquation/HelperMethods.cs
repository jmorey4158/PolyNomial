using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseEquation
{
    public class Helper
    {

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
        public static bool IsValidEquation(string eq)
        {
            // Regex checks for any 'illegal' characters. No point in continuing if 
            //  if consumer provides bad equation. 
            //Regex regx = new Regex(@"[0-9]\s\^\-\+xyz", RegexOptions.IgnoreCase);
            Regex regx = new Regex(@"[0-9\s\^\-\+xyz]", RegexOptions.IgnoreCase);

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
        public static Dictionary<int, string> FindOperators(string eq)
        {
            Dictionary<int, string> ops = new Dictionary<int, string>();

            // Iterate through equation string and find all the legal operators
            for (int i = 0; i <= eq.Length; i++)
            {
                // Using switch in case (no pun intended) I want to add more legal operators in future releases.
                // If we find a match add the location in the string and the operator. 
                switch (eq.Substring(i, 1))
                {
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
        public static List<string> FindTerms(string eq, Dictionary<int, string> ops)
        {
            List<string> terms = new List<string>();
            string eqCopy = eq;
            // Make sure that the term matches a valid polynomial term (e.g. -17x^5y^4x^3)
            Regex regx = new Regex(@"^\-?([0-9]+)(x\^[0-9]+)?(y\^[0-9]+)?(z\^[0-9]+)?", RegexOptions.IgnoreCase);


            // Iterate through the equation string (positioned by the operator), grab the substring that represents the 
            //  subequation, validate it, and if valid, add it to the List(string) that represent the equation terms 
            foreach (KeyValuePair<int, string> kp in ops)
            {
                string sub = eqCopy.Substring(0, kp.Key);
                if (regx.IsMatch(sub))
                {
                    terms.Add(sub);
                    eqCopy = eqCopy.Substring(kp.Key, eqCopy.Length - kp.Key);
                }
                else
                {
                    throw new Exception($"The equation term {sub} was not properly formed. Check the equation and try again.");
                }
            }
            return terms;
        }


        /// <summary>
        /// Private Method FindExponent - Parses input string (term) and finds the x, y, and z exponents (if any).
        /// </summary>
        /// <param name="term">String representing the equation term.</param>
        /// <returns>Int[] - int array representing the exponents of the x,y, and z variables.</returns>
        /// <remarks>If the variable has no exponent, FindExponent returns 1 so that N = N.</remarks>
        public static int[] FindExponent(string term)
        {
            int[] exp = { 1, 1, 1 }; // By default return N^1 so that N = N if there is no exponent.
            int pos = 0;
            int parseTry = 0;
            string expStr = "";

            // Get position of x exponent.
            pos = term.IndexOf('x') + 2;
            for (int i = 0; i < term.Length - pos; i++)
            {
                int.TryParse(term.Substring(pos, 1), out parseTry);
                if (parseTry > 0)
                    expStr += term.Substring(pos, 1);
                else
                    break;

            }
            int.TryParse(expStr, out parseTry);
            if (parseTry > 0)
                exp[0] = parseTry;


            // Get position of y exponent.
            pos = term.IndexOf('y') + 2;
            for (int i = 0; i < term.Length - pos; i++)
            {
                int.TryParse(term.Substring(pos, 1), out parseTry);
                if (parseTry > 0)
                    expStr += term.Substring(pos, 1);
                else
                    break;

            }
            int.TryParse(expStr, out parseTry);
            if (parseTry > 0)
                exp[1] = parseTry;


            // Get position of z exponent.
            pos = term.IndexOf('z') + 2;
            for (int i = 0; i < term.Length - pos; i++)
            {
                int.TryParse(term.Substring(pos, 1), out parseTry);
                if (parseTry > 0)
                    expStr += term.Substring(pos, 1);
                else
                    break;

            }
            int.TryParse(expStr, out parseTry);
            if (parseTry > 0)
                exp[1] = parseTry;


            return exp;
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
        public static List<Term> ParseTerms(List<string> subeq)
        {
            List<Term> subs = new List<Term>();


            foreach (var sub in subeq)
            {
                int len = sub.Length - 1;   // The standard basic guard against OutOfRange exception ;- )
                int coef = 0;   // This is the actual value of the coefficient. This value will be stuffed into the SubEquation.Coefficient property.
                bool hasOp = false; // If true then the string representing the coefficient will have '-' at the beginning.
                int isInt = 0;  // Used as out int of the TryPare(). IF it is not 0 then it represents the parsed int value.
                int position = 0;   // position determines the parsing starts. IF there is a sign on the coefficient then it bumps position 1.

                // Detect the sign of the coefficient. "+" should never be input, but check for it anyway.
                if (sub.Substring(position, 1) == "-")
                {
                    hasOp = true;
                    position = 1;
                }
                else if (sub.Substring(position, 1) == "+")
                {
                    position = 1;
                }



                // Parse through the remainder of the subequation string and create the SubEquation class instance and then add it to the List(SubEquations)
                for (int i = position; i <= len; i++)
                {






                }

            }

            return subs;
        }



        /// <summary>
        /// Private Method: FinalCalc - This method calculates the final decimal answer to the equation.
        /// </summary>
        /// <param name="operators">Dictionary(int,</param>
        /// <param name="subs"></param>
        /// <returns></returns>
        public static decimal FinalCalc(Dictionary<int, string> operators, List<Term> termsList, double[] vars)
        {
            decimal final = 0m;
            int terms = termsList.Count();
            int ops = operators.Count();

            // Make sure that there is one fewer operator than term. 
            if (terms -1 != ops)
                throw new Exception();

            else
            {
                List<decimal> termResults = new List<decimal>();
                foreach (Term t in termsList)
                {
                    termResults.Add( CalculateTerm(t, vars) );

                }

                //TODO: Figure out how to combine the Terms and the Operators and generate the result.
            }

            return final;
        }


        /// <summary>
        /// Private Method: CalculateTerm - This method calculates the decimal result for the given Term for the given variable values.
        /// </summary>
        /// <param name="term">Term Class Instance</param>
        /// <param name="vars">int[] with the values for the x,y, and z variables respectively.</param>
        /// <returns>Decimal - the result of calculating the term.</returns>
        public static decimal CalculateTerm(Term term, double[] vars)
        {
            decimal ret = 0m;

            try
            {
                ret = term.Coefficient *
                    (decimal)(Math.Pow(vars[0], term.xPower)) *
                    (decimal)(Math.Pow(vars[1], term.yPower)) *
                    (decimal)(Math.Pow(vars[2], term.zPower));
            }
            catch (OverflowException)
            {
                throw;
            }

            return ret;
        }


    }
}
