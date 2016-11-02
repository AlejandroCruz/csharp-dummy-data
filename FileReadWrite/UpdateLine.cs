using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private bool multiLine;
        int originUpdateArrLength;
        List<string> strList;
        List<string[]> strListArr;

        public UpdateLine()
        {
            strList = new List<string>();
        }

        public List<string> StrList
        {
            get { return strList; }
        }
        public List<string[]> StrListArr
        {
            get { return strListArr; }
        }

        public void modifySingleLine(List<string> sList, int[] indexes)
        {
            multiLine = false;

            try
            {
                if (indexes.Length > sList.Count)
                {
                    Console.WriteLine("Warning! index count: {0} greater than header elements: {1}", indexes.Length, sList.Count);
                    Array.Resize(ref indexes, sList.Count);
                    Console.WriteLine("\nIndex adjusted to maximum: {0}", indexes.Length);
                }
                else if (indexes.Length == 0)
                {
                    Array.Resize(ref indexes, 1);
                    Console.WriteLine("Index adjusted to minimum: {0}", indexes.Length);
                }
            }
// TODO //
            catch (IndexOutOfRangeException e)
            {
            }

            string tmpString;
            strList = sList;

            for (int i = 0; i < indexes.Length; i++)
            {
                int iA = indexes[i];

                tmpString = incrementDataValue(sList[iA], multiLine);
                strList[iA] = tmpString;
            }
        }

        public void modifyMultiLine(int[] indexes, int totalL)
        {
            multiLine = true;
            string tmpString;
            strListArr = new List<string[]>();

            for (int i = 0; i < totalL; i++)
            {

                for (int j = 0; j < indexes.Length; j++)
                {
                    int iA = indexes[j];

                    tmpString = incrementDataValue(strList[iA], multiLine);
                    strList[iA] = tmpString;
                }
                strListArr.Add(strList.ToArray());
            }
        }

        public string incrementDataValue(string uString, bool multiLine)
        {
            char letter = 'A';
            int charAddCounter = 0;

            int updateArrayLength = uString.Length;
            long tmpLong;
            string uStr = uString;
            string originUpdateArray;
            DateTime tmpDt;

            // Matches any character other than a decimal digit.
            if (System.Text.RegularExpressions.Regex.IsMatch(uStr, @"\D"))
            {
                switch (charAddCounter)
                {
                    case 0:
                        originUpdateArrLength = updateArrayLength;
                        charAddCounter++;
                        uStr = letter + uStr;
                        letter++;
                        break;
                    case 1:
                        originUpdateArray = uStr.Substring((uStr.Length - originUpdateArrLength), originUpdateArrLength);
                        uStr = originUpdateArray;
                        uStr = letter + uStr;
                        letter++;
                        break;
                    default:
                        uStr = letter + uStr;
                        letter++;
                        break;
                }
            }
            // Matches any decimal digit.
            else if (long.TryParse(uStr, out tmpLong))
            {
                tmpLong++;
                uStr = tmpLong.ToString();
            }
            else if (DateTime.TryParse(uStr, out tmpDt))
            {
                DateTime tD = tmpDt.AddDays(1);
                string format = "yyyy-M-d";
                uStr = tD.ToString(format);
            }
            return uStr;
        }

    }
}
