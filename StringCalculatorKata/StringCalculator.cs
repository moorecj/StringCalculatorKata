using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add( string numbers )
        {
            if (String.IsNullOrWhiteSpace(numbers))
            return 0;

            var sum = Convert.ToInt32(numbers);

            return sum;

        }
    }
}
