using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solution to coding problem: 
            //   Given the inputs of a signed Int , write a method that 
            //   reverses the order of the digits in the Int (e.g. 12345 becomes 54321)
            //   while preserving the sign.

            //Example with Int32 ('int')
            Console.Write(Operation.Reverse(13123191));

            Console.WriteLine();

            //Example with Int64 ('long')
            Console.Write(Operation.Reverse(-9549843094584039));

            // Don't close Console automatically
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Class : This static class contains one or more operations for Int32 or Int64.
    /// Method Reverse: Reverse takes any signed Int32 or Int64 and reverses the order of 
    ///     the digits while preserving the sign (+ or -)
    ///     Overloads: 2 one for Int32 and one for Int64
    /// </summary>
    /// <example>Operation.Reverse(13123191); Produces 19132131</example>
    public static class Operation
    {
        /// <summary>
        /// Method Reverse: Reverse takes any signed Int32 and reverses the order of 
        ///     the digits while preserving the sign (+ or -)
        /// </summary>
        /// <example>Operation.Reverse(-9549787898); Produces -8987879459</example>
        public static int Reverse(int n)
        {
            // Create variables used in the method
            int sign = Math.Sign(n);
            int ret = Math.Abs(n);
            double pow = 0;
            int index = 0;
            List<int> list = new List<int>();


            // Start by grabbing each digit in the 10^i power spot
            //  Each round in the while loop does ret % 10, and multiplies by 10
            //  to get the last whole number
            //  The key here is to get each digit at its Power of 10 place
            //  for example 12345 => 1x 10^4, 2x 10^3, 3x 10^2, 4x 10^1, 5x10^0
            while (ret >= 1)
            {
                // Add each digit from last to first
                list.Add((ret % 10));

                // set ret to be equal to remaining digits -- e.g. 1234
                decimal rd = (ret / 10);
                ret = Convert.ToInt32(Math.Floor(rd));

            }

            // Must reset ret to zero  to fill back up
            ret = 0;

            // Create reversed int by going through List<int>
            //   and multiplying out by 10^i
            //   for example 12345 --> 5,4,3,2,1
            //   5x 10^4, 4x 10^3, 3x 10^2, 2x 10^1, 1x 10^0 = 54321
            pow = list.Count - 1;
            while (index <= list.Count - 1)
            {
                ret += Convert.ToInt32(list[index] * Math.Pow(10, pow));
                pow--;
                index++;
            }

            // Retain the sing of the input Int
            ret *= sign;

            // Return the reversed Int
            return ret;

        }

        /// <summary>
        /// Method Reverse: Reverse takes any signed Int64 and reverses the order of 
        ///     the digits while preserving the sign (+ or -)
        /// </summary>
        /// <example>Operation.Reverse(-9549843094584039); Produces -9304854903489459</example>
        public static long Reverse(long n)
        {
            // Create variables used in the method
            int sign = Math.Sign(n);
            long ret = Math.Abs(n);
            double pow = 0;
            int index = 0;
            List<long> list = new List<long>();


            // Start by grabbing each digit in the 10^i power spot
            //  Each round in the while loop does ret % 10, and multiplies by 10
            //  to get the last whole number
            //  The key here is to get each digit at its Power of 10 place
            //  for example 12345 => 1x 10^4, 2x 10^3, 3x 10^2, 4x 10^1, 5x10^0
            while (ret >= 1)
            {
                // Add each digit from last to first
                list.Add((ret % 10));

                // set ret to be equal to remaining digits -- e.g. 1234
                decimal rd = (ret / 10);
                ret = Convert.ToInt64(Math.Floor(rd));

            }

            // Must reset ret to zero  to fill back up
            ret = 0;

            // Create reversed int by going through List<int>
            //   and multiplying out by 10^i
            //   for example 12345 --> 5,4,3,2,1
            //   5x 10^4, 4x 10^3, 3x 10^2, 2x 10^1, 1x 10^0 = 54321
            pow = list.Count - 1;
            while (index <= list.Count - 1)
            {
                ret += Convert.ToInt64(list[index] * Math.Pow(10, pow));
                pow--;
                index++;
            }

            // Retain the sing of the input Int
            ret *= sign;

            // Return the reversed Int
            return ret;

        }

    }

}
