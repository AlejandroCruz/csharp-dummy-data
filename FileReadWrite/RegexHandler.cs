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
        private static char nLetter = 'A';

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
                    ProcessDecimalSequences(inString);
                }
            }
            else if ( (Regex.IsMatch(newString, @"\D")) && (!newString.Equals(NULLSTR, StringComparison.OrdinalIgnoreCase)) )
            {
                tmpString = newString.Substring((inString.Length - origStr[thisIndex].Length), origStr[thisIndex].Length);
                ProcessWordPhrase(tmpString, inCharAdd);
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

        private static void ProcessDecimalSequences(string decimalSequence)
        {
            List<int> indexOfSeparator = new List<int>();
            List<string> strGroups = new List<string>();

            for (int i = 0; i < decimalSequence.Length; i++)
            {
                if (Regex.IsMatch(decimalSequence[i].ToString(), @"\D"))
                {
                    indexOfSeparator.Add(i);
                }
            }

            strGroups.Add(decimalSequence.Substring(0, indexOfSeparator[0]));

            if (indexOfSeparator.Count > 1)
            {
                int startS;
                int endS;
                int lengthS;
                int indexS = indexOfSeparator.Count - 1;

                for (int i = 0; i < indexS; i++)
                {
                    startS = indexOfSeparator[0 + i];
                    endS = indexOfSeparator[1 + i];
                    lengthS = endS - startS;

                    strGroups.Add( decimalSequence.Substring((startS + 1), (lengthS - 1)) );
                }

                strGroups.Add( decimalSequence.Substring((indexOfSeparator[indexS] + 1), (decimalSequence.Length - 1) - (indexOfSeparator[indexS])) );
            }
            else
            {
                strGroups.Add( decimalSequence.Substring((indexOfSeparator[0] + 1), (decimalSequence.Length - 1) - (indexOfSeparator[0])) );
            }

            // Increment last sequence group
            int tmpStrGroup = int.Parse(strGroups[strGroups.Count - 1]);
            tmpStrGroup++;
            strGroups[strGroups.Count - 1] = tmpStrGroup.ToString();

            StringBuilder strBuild = new StringBuilder();

            for (int i = 0; i < indexOfSeparator.Count; i++)
            {
                strBuild.Append(strGroups[i] + decimalSequence[indexOfSeparator[i]]);
            }
            strBuild.Append(strGroups[strGroups.Count - 1]);

            newString = strBuild.ToString();
        }

        private static void ProcessWordPhrase(string strPhrase, char letterAdd)
        {
            if (letterAdd.Equals('Z'))
            {
                letterAdd = 'A';
                newString = nLetter.ToString() + letterAdd + strPhrase;
            }
            else
            {
                newString = letterAdd + strPhrase;
            }

        }
    }
}
