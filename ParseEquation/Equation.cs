using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseEquation
{
    /// <summary>
    /// Public class Equation - Class representing the input equation, assuming it is valid. The purpose of this is to be able serialize the valid 
    ///     equations to a DB so that, if the equation is needed again, it can quickly be deserialized.
    /// </summary>
    public class Euqation
    {
        public Euqation() { }

        public string EquationString { get; set; }

        public List<Term> Terms { get; set; }

        public Dictionary<int, string> Operators { get; set; }

        public string Hash { get; set; }

    }
}
