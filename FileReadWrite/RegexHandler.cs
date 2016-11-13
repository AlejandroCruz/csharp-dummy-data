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
        private string inStr;

        public string RegexCharHandler(List<string> origStr, string inString, int inIndex, char inCharAdd)
        {
            const string NULLSTR = "NULL";
            string tmpString;
            long tmpL;
            double tmpD;
            inStr = inString;

            if (long.TryParse(inStr, out tmpL))
            {
                tmpL++;
                inStr = tmpL.ToString();
            }
            else if (double.TryParse(inStr, out tmpD))
            {
                tmpD++;
                inStr = tmpD.ToString();
            }
            else if ((Regex.IsMatch(inStr, @"\D")) && (!inStr.Equals(NULLSTR, StringComparison.OrdinalIgnoreCase)))
            {
                tmpString = inStr.Substring((inString.Length - origStr[inIndex].Length), origStr[inIndex].Length);
                inStr = inCharAdd + tmpString;
            }
            else
            {
                inStr = "NULL";
            }

            return inStr;
        }

        public string RegexDateHandler(DateTime inTempDate)
        {
            DateTime tD = inTempDate.AddDays(1);
            string format = "yyyy-MM-dd";
            inStr = tD.ToString(format);

            return inStr;
        }
    }
}
