using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private char letter = 'A';
        private int totalOfLines;
        private List<string> originStrList;
        private List<string> strList;
        private  List<string[]> strListArr;

        public UpdateLine(List<string> dataList, int inTotalOfLines)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = inTotalOfLines;
        }
// TODO //
        public List<string> StrList { get { return strList; } }
        public List<string[]> StrListArr { get { return strListArr; } }
        public List<string> OriginStrList {
            get { return originStrList; }
            set { originStrList = value; }
        }

        public void modifySingleLine(int[] indexes)
        {
            try
            {
                if (indexes.Length > originStrList.Count)
                {
                    Console.WriteLine("Warning! index count: {0} greater than header elements: {1}", indexes.Length, originStrList.Count);
                    Array.Resize(ref indexes, originStrList.Count);
                    Console.WriteLine("\nIndex adjusted to maximum: {0}", indexes.Length);
                }
                else if (indexes.Length == 0)
                {
                    Console.WriteLine("Index empty. No value modified: {0}", indexes.Length);
                    //Array.Resize(ref indexes, 1);
                    //Console.WriteLine("Index adjusted to minimum: {0}", indexes.Length);
                }
            }
// TODO //
            catch (IndexOutOfRangeException)
            {
            }

            string tmpString;
            strList = new List<string>(originStrList);

            for (int i = 0; i < indexes.Length; i++)
            {
                int iA = indexes[i];

                tmpString = incrementDataValue(originStrList[iA], iA);
                strList[iA] = tmpString;
            }
        }

        public void modifyMultiLine(int[] indexes)
        {
            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            for (int i = 0; i < totalOfLines; i++)
            {

                for (int j = 0; j < indexes.Length; j++)
                {
                    int iA = indexes[j];

                    tmpString = incrementDataValue(strList[iA], iA);
                    strList[iA] = tmpString;
                }
                strListArr.Add(strList.ToArray());
                letter++;
            }
        }

        public string incrementDataValue(string uString, int thisIndex)
        {
            long tmpLong;
            string uStr = uString;
            string tmpString;
            DateTime tmpDt;

            // Matches any character other than a decimal digit.
            if (System.Text.RegularExpressions.Regex.IsMatch(uStr, @"\D"))
            {
                if (uString.Length > originStrList[thisIndex].Length)
                {
                    tmpString = uStr.Substring((uString.Length - originStrList[thisIndex].Length), originStrList[thisIndex].Length);
                    uStr = letter + tmpString;
                }
                else
                {
                    uStr = letter + uString;
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
