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
        private string inString;

        public string RegexCharHandler(List<string> origStr, string inString, int thisIndex, char inCharAdd)
        {
            string tmpString;
            long tmpL;
            double tmpD;
            this.inString = inString;

            if (long.TryParse(this.inString, out tmpL))
            {
                tmpL++;
                this.inString = tmpL.ToString();
            }
            else if (double.TryParse(this.inString, out tmpD))
            {
                tmpD++;
                this.inString = tmpD.ToString();
            }
            else if ((Regex.IsMatch(this.inString, @"\D")) && (!this.inString.Equals(NULLSTR, StringComparison.OrdinalIgnoreCase)))
            {
                tmpString = this.inString.Substring((inString.Length - origStr[thisIndex].Length), origStr[thisIndex].Length);
                this.inString = inCharAdd + tmpString;
            }
            else
            {
                this.inString = NULLSTR;
            }
            return this.inString;
        }

        public string RegexDateHandler(DateTime inTempDate)
        {
            DateTime tD = inTempDate.AddDays(1);
            string format = "yyyy-MM-dd";
            this.inString = tD.ToString(format);

            return this.inString;
        }
    }
}
