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
                    List<string> strList = new List<string>();
                    List<string> strGroups = new List<string>();
                    List<string> strSeparators = new List<string>();

                    // Need chars converted to strings for Regex
                    for (int i = 0; i < inString.Length; i++)
                    {
                        strList.Add(inString[i].ToString());
                    }

                    for (int i = 0; i < strList.Count; i++)
                    {
                        if (Regex.IsMatch(strList[i], @"\D"))
                        {
                            strSeparators.Add(strList[i]);
                        }
                    }

                    strGroups.Add(inString.Substring(0, inString.IndexOf(strSeparators[0]) - 1) );
                    if(strSeparators.Count > 1)
                    {
                        for (int i = 0; i < strSeparators.Count; i++)
                        {
                            strGroups.Add(inString.Substring(strGroups[i].LastIndexOf(strGroups[i]), strSeparators.IndexOf(strSeparators[i+1]) - 1));
                        }
                    }
                    else
                    {
                        strGroups.Add( inString.Substring((strSeparators.IndexOf(strSeparators[0]) + 1), strList.LastIndexOf(strList[0])) );
                    }


                    StringBuilder strBuild = new StringBuilder();
                    for (int i = 0; i < strSeparators.Count; i++)
                    {
                        strBuild.Append(strGroups[i] + strSeparators[i]);
                    }
                    strBuild.Append(strGroups[strGroups.Count - 1]);

                    newString = strBuild.ToString();
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
