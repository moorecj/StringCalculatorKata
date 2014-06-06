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
            var delimeters = new List<string>() { ",", "\n" };
<<<<<<< HEAD

            if(CustomDelimetersExist (numbersString ))
            {
=======
            

            if(CustomDelimetersExist (numbersString ))
            {

>>>>>>> 4f21a5373b9d2ce48207e16acc7ed2afb3df863b
                delimeters.AddRange(GetCustomDelimeters(numbersString));
                numbersString = TruncateDelimetersFromString(numbersString);
            }

            if ( String.IsNullOrWhiteSpace( numbersString ) )
            return 0;

            String[] numbers = numbersString.Split(delimeters.ToArray(), StringSplitOptions.None);

            List<int> numbersToAdd = new List<int>();

            foreach(var number in numbers)
            {
                numbersToAdd.Add( ConvertStringToNumber(number) );
            }

            if(NegitiveNumbersExist(numbersToAdd))
            {
                var negitiveNumbers = String.Join(" | ", numbersToAdd.Where( number => number < 0 ));
                throw new NegitiveNotAllowedExcetption(String.Format("Negitives not allowed: {0}", negitiveNumbers ));
            }

            numbersToAdd = numbersToAdd.Where(number => number <= 1000).ToList();

            return numbersToAdd.Sum();

        }


        private List<string> GetCustomDelimeters( string numbersString )
        {

            int delimeterStartIndex;
            int delimeterEndIndex;

            var delimeters = new List<string>() { ",", "\n" };

            delimeterStartIndex = numbersString.IndexOf('[') + 1;
            delimeterEndIndex = numbersString.IndexOf(']');

            if ( delimeterEndIndex < 0 )
            {
                delimeters = new List<string>() { numbersString[2].ToString() };
            }
            else
            {
                while ( delimeterEndIndex > 0 )
                {
                    delimeters.Add(numbersString.Substring(delimeterStartIndex, delimeterEndIndex - delimeterStartIndex));

                    numbersString = numbersString.Substring(delimeterEndIndex + 1);

                    delimeterStartIndex = numbersString.IndexOf('[') + 1;
                    delimeterEndIndex = numbersString.IndexOf(']');
                }
                
            }

            return delimeters;
            
        }

        private string TruncateDelimetersFromString( string numbersString )
        {
            int EndOfDelimetersIndex;
             
            EndOfDelimetersIndex = numbersString.IndexOf('\n')+1;
                
            
            return( numbersString.Substring(EndOfDelimetersIndex) );
        }


        private bool NegitiveNumbersExist(List<int> numbersToAdd)
        {
            return numbersToAdd.Any(n => n < 0);
        }

        

        public int ConvertStringToNumber( string number )
        {
            var numberToAdd = Convert.ToInt32(number);

            return numberToAdd;
        }


        private Boolean  CustomDelimetersExist( string numbersString )
        {
            return ( numbersString.Length > 1 && numbersString.Substring(0,2).Equals("//") );
        }
    }
}
