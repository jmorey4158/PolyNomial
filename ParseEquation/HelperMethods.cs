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
            Regex regx = new Regex(@"[^\d+\s+\^+\-*\++x+y*]", RegexOptions.IgnoreCase);

            if (regx.IsMatch(eq))
                throw new ParseEquationException("The equation was not properly formed. Please check the equation and try again.");
            else
                return true;

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
            for (int i = 0; i < eq.Length-1; i++)
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
            string[] ts = eq.Split('+');
            List<string> terms = new List<string>();

            foreach (string t in ts)
            {
                terms.Add(t.Trim());

            }

            // Iterate through the equation string and grab the substring that represents the 
            //  term and add it to the List(string) that represent the equation terms. 
            //foreach (KeyValuePair<int, string> kp in ops)
            //{
            //    string sub = eqCopy.Substring(0, kp.Key);
            //    terms.Add(sub);
            //    eqCopy = eqCopy.Substring(kp.Key + 2, eqCopy.Length - (kp.Key + 2));
            //}
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
        public static List<Term> ParseTerms(List<string> termStrings)
        {
            List<Term> newTerms = new List<Term>();

            foreach (var t in termStrings)
            {
                bool isNegative = false; // If true then the string representing the coefficient will have '-' at the beginning.
                StringBuilder intSb = new StringBuilder(); // Used to construct Coefficient
                int position = 0;   // position determines the parsing starts. IF there is a sign on the coefficient then it bumps position 1.
                Term newTerm = new Term();
                int result = 0;

                // Detect the sign of the coefficient. "+" should never be input, but check for it anyway.
                if (t.Substring(position, 1) == "-")
                {
                    isNegative = true;
                    position = 1;
                }
                else if (t.Substring(position, 1) == "+")
                {
                    position = 1;
                }

                if (int.TryParse(t.Substring(position, 1), out result))
                {
                    if(isNegative)
                    {
                        newTerm.Coefficient = -Convert.ToInt32(Regex.Match(t.Substring(position), "^[0-9]+").Value);
                        position += newTerm.Coefficient.ToString().Length-1;
                    }
                    else
                    {
                        newTerm.Coefficient = Convert.ToInt32(Regex.Match(t.Substring(position), "^[0-9]+").Value);
                        position += newTerm.Coefficient.ToString().Length;
                    }
                }
                else
                {
                    throw new ParseEquationException($"The TermString character {t.Substring(position, 1)} must be an integer. Check the equation and try again.");
                }

                for (int index = position; index < t.Length;)
                {
                    switch(t.Substring(index,1))
                    {
                        case "x":
                            try
                            {
                                newTerm.xPower = FindTermInt(t.Substring(index +2, 1));
                                index += newTerm.xPower.ToString().Length+2;
                            }
                            catch (Exception)
                            {
                                newTerm.xPower = 1;
                                index++;
                            }
                            break;

                        case "y":
                            try
                            {
                                newTerm.yPower = FindTermInt(t.Substring(index + 2, 1));
                                index += newTerm.yPower.ToString().Length+2;
                            }
                            catch (Exception)
                            {
                                newTerm.yPower = 1;
                                index++;
                            }

                            break;

                        case "^":
                            index++;
                            break;

                        default:
                            throw new ParseEquationException($"The TermString character {t.Substring(position, 1)} must be an integer. Check the equation and try again.");
                    }
                }


                newTerms.Add(newTerm);
            }

            return newTerms;
        }



        /// <summary>
        /// Private Method: FinalCalc - This method calculates the final decimal answer to the equation.
        /// </summary>
        /// <param name="operators">Dictionary(int,</param>
        /// <param name="subs"></param>
        /// <returns></returns>
        public static decimal FinalCalc(Dictionary<int, string> operators, List<Term> termsList, decimal[] vars)
        {
            // Make sure there are only two variables
            if (vars.Length > 2)
                throw new ParseEquationException($"Only two variables can be used -- 'x' and 'y'.");


            decimal final = 0;
            int oLen = operators.Count();
            int tLen = termsList.Count();

            // Make sure that there is one fewer operator than term. 
            if (tLen - 1 != oLen)
                throw new ParseEquationException("The number of Operators must be one less than the number of Terms. Check the equation and try again.");
            else
            {
                // Calculate the result for each term and store
                // The list of Term results must be an Array to iterate through Terms and Operators properly
                decimal[] termResults = new decimal[tLen];
                for (int i = 0; i < tLen; i++)
                {
                    termResults[i] = CalculateTerm(termsList[i], vars);
                }

                for (int i = 0; i < termResults.Length - 1;)
                {
                    final += (termResults[i] + termResults[i + 1]);
                    i += 2;
                }
            }

            return final;
        }


        /// <summary>
        /// Private Method: CalculateTerm - This method calculates the decimal result for the given Term for the given variable values.
        /// </summary>
        /// <param name="term">Term Class Instance</param>
        /// <param name="vars">int[] with the values for the x,y, and z variables respectively.</param>
        /// <returns>Decimal - the result of calculating the term.</returns>
        public static decimal CalculateTerm(Term term, decimal[] vars)
        {
            double ret = 0;
            double xPow = (double)vars[0];
            double yPow = (double)vars[1];

            try
            {
                ret = term.Coefficient;
                ret *= Math.Pow(xPow, term.xPower);
                ret *= Math.Pow(yPow, term.yPower);
            }
            catch (OverflowException)
            {
                throw;
            }

            return (decimal)ret;
        }


        /// <summary>
        /// Helper Method FindTermInt - Finds the integer part of the string passed in. This is uses to find the 
        ///     integer parts of a TermString. 
        /// </summary>
        /// <param name="s">String - Part of a TermString</param>
        /// <returns>Int - the integer part of the string</returns>
        public static int FindTermInt(string s)
        {
            int outInt = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s.Substring(i, 1), out outInt))
                    sb.Append(outInt.ToString());
                else
                    break;
            }

            if (int.TryParse(sb.ToString(), out outInt))
                return outInt;
            else
                throw new ParseEquationException($"No integers were found in the string {s}. Check the equation and try again.");

        }


    }
}
