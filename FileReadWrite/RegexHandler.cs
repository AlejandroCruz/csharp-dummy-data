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

        private static void ProcessSeparatedDecimalSequences(string dSequence)
        {
            List<int> indexSeparator = new List<int>();
            List<string> strGroups = new List<string>();

            for (int i = 0; i < dSequence.Length; i++)
            {
                if (Regex.IsMatch(dSequence[i].ToString(), @"\D"))
                {
                    indexSeparator.Add(i);
                }
            }

            strGroups.Add(dSequence.Substring(0, indexSeparator[0]));

            if (indexSeparator.Count > 1)
            {
                int strSep;
                int endSep;
                int length;

                for (int i = 0; i < indexSeparator.Count - 1; i++)
                {
                    strSep = indexSeparator[0 + i];
                    endSep = indexSeparator[1 + i];
                    length = endSep - strSep;

                    strGroups.Add(dSequence.Substring((strSep + 1), (length - 1)));
                }

                strGroups.Add( dSequence.Substring((indexSeparator[indexSeparator.Count - 1] + 1), (dSequence.Length - 1) - (indexSeparator[indexSeparator.Count - 1])) );
            }
            else
            {
                strGroups.Add( dSequence.Substring((indexSeparator[0] + 1), (dSequence.Length - 1) - (indexSeparator[0])) );
            }

            // Increment last decimal sequence group
            int tmpStrGroup = int.Parse(strGroups[strGroups.Count - 1]);
            tmpStrGroup++;
            strGroups[strGroups.Count - 1] = tmpStrGroup.ToString();

            StringBuilder strBuild = new StringBuilder();

            for (int i = 0; i < indexSeparator.Count; i++)
            {
                strBuild.Append(strGroups[i] + dSequence[indexSeparator[i]]);
            }
            strBuild.Append(strGroups[strGroups.Count - 1]);

            newString = strBuild.ToString();
        }
    }
}
