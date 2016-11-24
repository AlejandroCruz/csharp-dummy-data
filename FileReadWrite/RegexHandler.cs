using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FileReadWrite
{
    class RegexHandler
    {
        private const char DEFAULT_LETTER = 'A';
        private const string NULLSTR = "NULL";
        private const string DATE_FORMAT = "yyyy-MM-dd";

        private string newString;
        private List<string> originalStr;
        private DateTime tD;

        public RegexHandler(List<string> inOriginStrList)
        {
            originalStr = inOriginStrList;
        }

        public string RegexCharHandler(string inString, int thisIndex, char inCharAdd)
        {
            if (!Regex.IsMatch(inString, "[a-zA-Z]"))
            {
                ProcessNoLetterSequence(inString);
            }
            // "\D": Matches any character other than a decimal digit
            else if ( (Regex.IsMatch(inString, @"\D")) && (!inString.Equals(NULLSTR, StringComparison.OrdinalIgnoreCase)) )
            {
                ProcessWordPhrase(inString, thisIndex, inCharAdd);
            }
            else
            {
                ProcessUnreadable();
            }

            return newString;
        }

        public string RegexDateHandler(DateTime inTempDate)
        {
            tD = inTempDate.AddDays(1);
            newString = tD.ToString(DATE_FORMAT);

            return newString;
        }

        private void ProcessNoLetterSequence(string noLetterSequence)
        {
            long tmpLong;
            double tmpDecimal;
            string strSequence = noLetterSequence;

            if (long.TryParse(strSequence, out tmpLong))
            {
                tmpLong++;
                newString = tmpLong.ToString();
            }
            else if (double.TryParse(strSequence, out tmpDecimal))
            {
                tmpDecimal++;
                newString = tmpDecimal.ToString();
            }
            else
            {
                // "\d": Matches any decimal digit
                if (Regex.IsMatch(strSequence, @"\d"))
                {
                    ProcessDecimalSequences(strSequence);
                }
                else
                {
                    ProcessUnreadable();
                }
            }
        }

        private void ProcessDecimalSequences(string decimalSequence)
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

        private void ProcessWordPhrase(string wordPhrase, int thisIndex, char inCharAdd)
        {
            string tmpString = wordPhrase.Substring((wordPhrase.Length - originalStr[thisIndex].Length), originalStr[thisIndex].Length);

            if (inCharAdd.Equals('Z'))
            {
                inCharAdd = 'A';
                newString = DEFAULT_LETTER.ToString() + inCharAdd + tmpString;
            }
            else
            {
                newString = inCharAdd + tmpString;
            }
        }

        private void ProcessUnreadable()
        {
            newString = NULLSTR;
        }
    }
}
