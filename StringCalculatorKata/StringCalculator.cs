using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add( string numbersString )
        {
            var delimeters = new[] { ',', '\n' };

            if(CustomDelimetersExist (numbersString ))
            {
                delimeters = new char[] { numbersString[2] };
                numbersString = numbersString.Substring(4);
            }
            

            if (String.IsNullOrWhiteSpace(numbersString))
            return 0;

            String[] numbers = numbersString.Split(delimeters);
 

            var sum = 0;

            foreach(var number in numbers)
            {
                sum += ConvertStringToNumber(number);
            }
            return sum;

        }

        public int ConvertStringToNumber( string number )
        {
            var numberToAdd = Convert.ToInt32(number);

            if (numberToAdd < 0)
                throw new NegitiveNotAllowedExcetption(String.Format("Negitives not allowed: {0}", numberToAdd));

            return numberToAdd;
        }

        private Boolean  CustomDelimetersExist( string numbersString )
        {
            return ( numbersString.Length > 1 && numbersString.Substring(0,2).Equals("//"));
        }
    }
}
