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
                    int[] groupIndex;
                    int groupCounter = 0;

                    List<string> inStrList = new List<string>();
                    List<string> strGroup = new List<string>();
                    List<string[]> strGroupsArr = new List<string[]>();
                    List<string> strSeparators = new List<string>();

                    for(int i = 0; i < inString.Length; i++)
                    {
                        inStrList.Add(inString[i].ToString());
                    }

                    for(int i = (inString.Length - 1); i >= 0; i--)
                    {
                        if (Regex.IsMatch(inStrList[i], "[0-9]"))
                        {
                            strGroup.Add(inStrList[i]);
                        }
                        else
                        {
                            strSeparators.Add(inStrList[i]);
                            groupIndex = new int[] { groupCounter };
                            groupCounter++;
                        }
                    }

                    string group1 = 
                    strGroupsArr.Add(strGroup[i].ToString());


                    StringBuilder strBuild = new StringBuilder();

                    for(int i = 0; i < strGroupsArr.Count; i++)
                    {

                        foreach (var item in strGroupsArr[i])
                        {
                            strBuild.Append(item);
                        }
                        if((i+1) < strGroupsArr.Count)
                        {
                            strBuild.Append(strSeparators[i]);
                        }
                    }
                    newString = strBuild.ToString();

                    //char lastNumbFound = inString[inString.Length - 1];
                    //string lNF = lastNumbFound.ToString();

                    //for (int i = 0; i < inString.Length; i++)
                    //{
                    //    string lNF = lastNumbFound.ToString();
                    //    if (Regex.IsMatch(lNF, @"\d"))
                    //    {
                    //        aString.Add(lNF);
                    //    }
                    //    else
                    //    {
                    //        //newString = newString.Insert(newString.Length, "0");
                    //        aString.Add("0");
                    //    }
                    //}

                    //if (lastNumbFound == '9')
                    //{
                    //    lastNumbFound = '0';
                    //    newString = newString.Insert(newString.Length, char.ToString(lastNumbFound));
                    //    lastNumbFound++;
                    //}
                    //else
                    //{
                    //    lastNumbFound++;
                    //    tmpString = newString.Remove(inString.Length - 1, 1);
                    //    newString = tmpString.Insert(tmpString.Length, char.ToString(lastNumbFound));
                    //}
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
