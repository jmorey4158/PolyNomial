using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseEquation
{
    public class ParseEquationException : Exception
    {
        public ParseEquationException() { }
        public ParseEquationException(string message) : base(message) { }
    }
}
