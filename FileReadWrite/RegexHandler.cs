/* Console application: FileReadWrite
 * Description:
 *  Handle the modification of strings when character, special character,
 *   decimal, or unrecognized value.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FileReadWrite
{
    class RegexHandler
    {
        const string NULLSTR = "NULL";
        private static string newString;

        public static string RegexCharHandler(string inString, int thisIndex, char inCharAdd, List<string> origStr)
        {
            bool newStringHasLetter = true;
            bool newStringHasNumber = true;
            string tmpString;
            long tmpLong;
            double tmpDecimal;
            newString = inString;

            foreach (var item in newString)
            {
                newStringHasLetter = Char.IsLetter(item);
                newStringHasNumber = Char.IsNumber(item);
            }

            if (!newStringHasLetter)
            {
                if (long.TryParse(newString, out tmpLong))
                {
                    tmpLong++;
                    newString = tmpLong.ToString();
                }
                else if (double.TryParse(newString, out tmpDecimal))
                {
                    tmpDecimal++;
                    newString = tmpDecimal.ToString();
                }
            }
            else if ( (Regex.IsMatch(newString, @"\D")) && (!newString.Equals(NULLSTR, StringComparison.OrdinalIgnoreCase)) )
            {
                tmpString = newString.Substring((inString.Length - origStr[thisIndex].Length), origStr[thisIndex].Length);
                newString = inCharAdd + tmpString;
            }
            else
            {
                newString = NULLSTR;
            }
            return newString;
        }

        public static string RegexDateHandler(DateTime inTempDate)
        {
            DateTime tD = inTempDate.AddDays(1);
            string format = "yyyy-MM-dd";
            newString = tD.ToString(format);

            return newString;
        }
    }
}
