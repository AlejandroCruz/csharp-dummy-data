using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private char charAdd = 'A';
        private int thisIndex;
        private int totalOfLines;
        private List<string> originStrList;
        private List<string> strList;
        private List<string[]> strListArr;

        public UpdateLine(List<string> dataList)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = 1;
        }
        public UpdateLine(List<string> dataList, int inTotalOfLines)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = inTotalOfLines;
        }

        public List<string> OriginStrList { get { return originStrList; } }
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
                    Array.Resize(ref indexes, 1);
                    Console.WriteLine("Index adjusted to minimum: {0}", indexes.Length);
                }
            }

            catch (ArgumentOutOfRangeException e)
            { Console.WriteLine("\n>>> System message:\n" + e); }

            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            for (int i = 0; i < indexes.Length; i++)
            {
                thisIndex = indexes[i];
                tmpString = IncrementDataValue(originStrList[thisIndex], thisIndex);
                strList[thisIndex] = tmpString;
            }
            strListArr.Add(strList.ToArray());
        }

        public void ModifyMultiLine(int[] indexes)
        {
            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            try
            {
                for (int i = 0; i < indexes.Length; i++)
                {
                    tmpString = strList[indexes[i]];
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Array element out of range surfaced at: #{0}", thisIndex);
                Console.WriteLine("\n>>> System message:\n" + e);
                Console.WriteLine("\n>>> Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            for (int i = 0; i < totalOfLines; i++)
            {
                int lineCount = i;

                if (lineCount > 0)
                {
                    for (int j = 0; j < indexes.Length; j++)
                    {
                        thisIndex = indexes[j];
                        tmpString = IncrementDataValue(strList[thisIndex], thisIndex);
                        strList[thisIndex] = tmpString;
                    }
                    strListArr.Add(strList.ToArray());
                }
                else
                {
                    strListArr.Add(strList.ToArray());
                }
                if (i > 0) charAdd++;
            }
        }

        private string IncrementDataValue(string inStringList, int thisIndex)
        {
            const string NULLSTR = "NULL";
            string newStrList = inStringList;
            DateTime tmpDt;

            if ( (Regex.IsMatch(newStrList, @"\w")) && (!DateTime.TryParse(newStrList, out tmpDt)) )
            {
                newStrList = RegexHandler.RegexCharHandler(newStrList, thisIndex, charAdd, originStrList);
            }
            else if (DateTime.TryParse(newStrList, out tmpDt))
            {
                newStrList = RegexHandler.RegexDateHandler(tmpDt);
            }
            else
            {
                newStrList = NULLSTR;
            }
            return newStrList;
        }
    }
}