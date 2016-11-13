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
        public string RegexCharHandler(List<string> origStr, string inString, int inIndex, char inCharAdd)
        {
            const string NULLSTR = "NULL";
            string tmpString;
            long tmpL;
            double tmpD;
            string charStr = inString;

            if (long.TryParse(charStr, out tmpL))
            {
                tmpL++;
                charStr = tmpL.ToString();
            }
            else if (double.TryParse(charStr, out tmpD))
            {
                tmpD++;
                charStr = tmpD.ToString();
            }
            else if ((Regex.IsMatch(charStr, @"\D")) && (!charStr.Equals(NULLSTR, StringComparison.OrdinalIgnoreCase)))
            {
                tmpString = charStr.Substring((inString.Length - origStr[inIndex].Length), origStr[inIndex].Length);
                charStr = inCharAdd + tmpString;
            }
            else
            {
                charStr = "NULL";
            }

            return charStr;
        }
    }
}
