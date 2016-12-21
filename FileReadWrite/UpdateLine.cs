using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private int listIndex;
        private int totalOfLines;
        private List<string> originStrList;
        private List<string> strList;
        private List<string[]> strListArr;
        private RegexHandler rgxObj;

        public UpdateLine(List<string> dataList)
        {
            originStrList = new List<string>(dataList);
            totalOfLines = 1;
            rgxObj = new RegexHandler(originStrList);
            strList = new List<string>(originStrList);
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

        public void ModifySingleLine(List<int> elementInd)
        {
            string tmpString;
            strList = new List<string>(originStrList);
            strListArr = new List<string[]>();

            if (totalOfLines > 0)
            {
                for (int i = 0; i < elementInd.Count; i++)
                {
                    listIndex = elementInd[i];
                    tmpString = IncrementDataValue(originStrList[listIndex], listIndex);
                    strList[listIndex] = tmpString;
                }
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
                Console.WriteLine("Array element out of range surfaced at: #{0}", listIndex);
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
                        listIndex = elementInd[j];
                        tmpString = IncrementDataValue(strList[listIndex], listIndex);
                        strList[listIndex] = tmpString;
                    }
                    strListArr.Add(strList.ToArray());
                }
                else
                {
                    strListArr.Add(strList.ToArray());
                }
            }
        }

        private string IncrementDataValue(string inCharSequence, int elementListIndex)
        {
            string newCharSequence = inCharSequence;
            DateTime tmpDt;

            if (!DateTime.TryParse(inCharSequence, out tmpDt))
            {
                newCharSequence = rgxObj.RegexCharHandler(newCharSequence, elementListIndex);
            }
            else if (DateTime.TryParse(inCharSequence, out tmpDt))
            {
                newCharSequence = rgxObj.RegexDateHandler(tmpDt);
            }

            return newCharSequence;
        }
    }
}