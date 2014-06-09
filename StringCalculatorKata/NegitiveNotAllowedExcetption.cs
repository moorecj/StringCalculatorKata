using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class NegitiveNotAllowedExcetption : Exception
    {

        public NegitiveNotAllowedExcetption(string message)  : base(message)
        { 

        }
    }
}
