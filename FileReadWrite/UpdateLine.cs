using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;

namespace FileReadWrite
{
    class UpdateLine
    {
        private char letter = 'A';
        private int iA; // Current element index
        private int lineCount;
        private int totalOfLines;
        private List<string> originStrList;
        private List<string> strList;
        private List<string[]> strListArr;

        public UpdateLine(List<string> dataList, int inTotalOfLines)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = inTotalOfLines;
        }

        public List<string> StrList { get { return strList; } }
        public List<string[]> StrListArr { get { return strListArr; } }

        public void ModifySingleLine(int[] indexes)
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
                    //Array.Resize(ref indexes, 1);
                    //Console.WriteLine("Index adjusted to minimum: {0}", indexes.Length);
                }
            }
// TODO //
            catch (ArgumentOutOfRangeException e)
            { Console.WriteLine("\n>>> System message:\n" + e); }

            string tmpString;
            strList = new List<string>(originStrList);

            for (int i = 0; i < indexes.Length; i++)
            {
                iA = indexes[i];
                tmpString = IncrementDataValue(originStrList[iA], iA);
                strList[iA] = tmpString;
            }
        }

        public void ModifyMultiLine(int[] indexes)
        {
            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            try
            {
                for (int i = 0; i < indexes.Length; i++)
                { tmpString = strList[indexes[i]]; }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Array element out of range: #{0}", iA);
                Console.WriteLine("\n>>> System message:\n" + e);
                Console.WriteLine("\n>>> Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            for (int i = 0; i < totalOfLines; i++)
            {
                lineCount = i;

                for (int j = 0; j < indexes.Length; j++)
                {
                    iA = indexes[j];
                    tmpString = IncrementDataValue(strList[iA], iA);
                    strList[iA] = tmpString;
                }
                strListArr.Add(strList.ToArray());
                if (i > 0) letter++;
            }
        }

        public string IncrementDataValue(string uString, int thisIndex)
        {
            long tmpL;
            double tmpD;
            string uStr = uString;
            string tmpString;

            DateTime tmpDt;

            // Match any character other than a decimal digit: @"\D"
            if ( (lineCount > 0) && (Regex.IsMatch(uStr, @"\w")) && (!DateTime.TryParse(uStr, out tmpDt)) )
            {
                if (long.TryParse(uStr, out tmpL))
                {
                    tmpL++;
                    uStr = tmpL.ToString();
                }
                else if (double.TryParse(uStr, out tmpD))
                {
                    tmpD++;
                    uStr = tmpD.ToString();
                }
                else if (Regex.IsMatch(uStr, @"\D"))
                {
                    tmpString = uStr.Substring((uString.Length - originStrList[thisIndex].Length), originStrList[thisIndex].Length);
                    uStr = letter + tmpString;
                }
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