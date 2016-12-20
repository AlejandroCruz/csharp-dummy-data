using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private int strListIndex;
        private int totalOfLines;
        private List<string> originStrList;
        private List<string> strList;
        private List<string[]> strListArr;
        private RegexHandler rgxObj;

        public UpdateLine(List<string> dataList)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = 1;
        }
        public UpdateLine(List<string> dataList, int inTotalOfLines)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = inTotalOfLines;
            rgxObj = new RegexHandler(originStrList);
        }

        public List<string> OriginStrList { get { return originStrList; } }
        public List<string> StrList { get { return strList; } }
        public List<string[]> StrListArr { get { return strListArr; } }

        public void ModifySingleLine(List<int> indexes)
        {
            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            for (int i = 0; i < indexes.Count; i++)
            {
                strListIndex = indexes[i];
                tmpString = IncrementDataValue(originStrList[strListIndex], strListIndex);
                strList[strListIndex] = tmpString;
            }
            strListArr.Add(strList.ToArray());
        }

        public void ModifyMultiLine(List<int> elementInd)
        {
            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            try
            {
                for (int i = 0; i < elementInd.Count; i++)
                {
                    tmpString = strList[elementInd[i]];
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Array element out of range surfaced at: #{0}", strListIndex);
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
                    for (int j = 0; j < elementInd.Count; j++)
                    {
                        strListIndex = elementInd[j];
                        tmpString = IncrementDataValue(strList[strListIndex], strListIndex);
                        strList[strListIndex] = tmpString;
                    }
                    strListArr.Add(strList.ToArray());
                }
                else
                {
                    strListArr.Add(strList.ToArray());
                }
            }
        }

        private string IncrementDataValue(string inStringList, int elementListIndex)
        {
            string newStrList = inStringList;
            DateTime tmpDt;

            if (!DateTime.TryParse(inStringList, out tmpDt))
            {
                newStrList = rgxObj.RegexCharHandler(newStrList, elementListIndex);
            }
            else if (DateTime.TryParse(inStringList, out tmpDt))
            {
                newStrList = rgxObj.RegexDateHandler(tmpDt);
            }

            return newStrList;
        }
    }
}