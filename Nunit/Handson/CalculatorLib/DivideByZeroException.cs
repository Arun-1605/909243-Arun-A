using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class DivideByZeroException : Exception
    {
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}

