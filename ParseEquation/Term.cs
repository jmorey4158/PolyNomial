using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseEquation
{
    /// <summary>
    /// Public Class SubEquation - This class is used to represent the terms in the equation 
    ///     in a way that computer-based calculation can be done.
    /// </summary>
    public class Term
    {
        public Term()
        {
            xPower = 1;
            yPower = 1;
        }

        public int Coefficient { get; set; }

        public int xPower { get; set; }

        public int yPower { get; set; }
    }
}
