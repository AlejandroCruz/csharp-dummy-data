using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FileReadWrite
{
    class RegexHandler
    {
        private const string NULLSTR = "NULL";
        private static string newString;

        public static string RegexCharHandler(string inString, int thisIndex, char inCharAdd, List<string> origStr)
        {
            string tmpString;
            long tmpLong;
            double tmpDecimal;
            newString = inString;

            if (!Regex.IsMatch(inString, "[a-zA-Z]"))
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
                else
                {
                    ProcessSeparatedDecimalSequences(inString);
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

        private static void ProcessSeparatedDecimalSequences(string decimalSequence)
        {
            string dSequence = decimalSequence;

            List<int> indexSeparator = new List<int>();
            List<string> strList = new List<string>();
            List<string> strGroups = new List<string>();
            List<string> strSeparators = new List<string>();

            // Need chars converted to strings for Regex
            for (int i = 0; i < dSequence.Length; i++)
            {
                strList.Add(dSequence[i].ToString());

                if (Regex.IsMatch(strList[i], @"\D"))
                {
                    strSeparators.Add(strList[i]);
                    indexSeparator.Add(i);
                }
            }

            strGroups.Add(dSequence.Substring(0, dSequence.IndexOf(strSeparators[0])));

            if (strSeparators.Count > 1)
            {
                int strSep;
                int endSep;
                int length;

                for (int i = 0; i < strSeparators.Count - 1; i++)
                {
                    strSep = indexSeparator[0 + i];
                    endSep = indexSeparator[1 + i];
                    length = endSep - strSep;

                    strGroups.Add(dSequence.Substring((strSep + 1), (length - 1)));
                }

                strGroups.Add(dSequence.Substring((indexSeparator[indexSeparator.Count - 1] + 1), (dSequence.Length - 1) - (indexSeparator[indexSeparator.Count - 1])));
            }
            else
            {
                strGroups.Add(dSequence.Substring((dSequence.IndexOf(strSeparators[0]) + 1), (dSequence.Length - 1) - dSequence.IndexOf(strSeparators[0])));
            }

            int tmpStrGroup = int.Parse(strGroups[strGroups.Count - 1]);
            tmpStrGroup++;
            strGroups[strGroups.Count - 1] = tmpStrGroup.ToString();

            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < strSeparators.Count; i++)
            {
                strBuild.Append(strGroups[i] + strSeparators[i]);
            }
            strBuild.Append(strGroups[strGroups.Count - 1]);

            newString = strBuild.ToString();
        }
    }
}
