using System;
using System.Collections.Generic;
using System.Text;

namespace FileReadWrite
{
    class ProcessLines
    {
        //private int[] countForColumnPadding;

        //public int[] CountForColumnPadding
        //{
        //    get { return countForColumnPadding; }
        //}

        public string RemoveString(string inLine, string rmvStr)
        {
            string editLine = null;

            for (int i = 0; i < inLine.Length; i++)
            { editLine = inLine.Replace(rmvStr, string.Empty); }

            return editLine;
        }

        public List<string> SplitValues(string inLine, char inDelimiter)
        {
            string[] values = inLine.Split(inDelimiter);
            List<string> lineList = new List<string>();

            for(int i = 0; i < values.Length; i++)
            { lineList.Add(values[i]); }

            return lineList;
        }

        public string[] AppendValues(UpdateLine inHeader, UpdateLine inRecord)
        {
            //countForColumnPadding = new int[inHeader.StrList.Count];
            string[] lineStrArr = new string[1 + inRecord.StrListArr.Count];
            StringBuilder strBuild = new StringBuilder();

            foreach (string s in inHeader.StrList)
            {
                strBuild.Append(s + ",");
            }
            lineStrArr[0] = strBuild.ToString().Trim(new char[] { ' ', ',' });

            for (int i = 0; i < inRecord.StrListArr.Count; i++)
            {
                strBuild = new StringBuilder();

                foreach (string s in inRecord.StrListArr[i])
                {
                    //int sCounter = 0;
                    strBuild.Append(s + ",");
                    //countForColumnPadding[sCounter] = (countForColumnPadding[sCounter] > s.ToString().Length) ? s.ToString().Length : countForColumnPadding };
                }
                lineStrArr[i + 1] = strBuild.ToString().Trim(new char[] { ' ', ',' });
            }
            return lineStrArr;
        }

        public List<int> CompareFields(UpdateLine inHeader, UpdateLine inRecord)
        {
            int countStrListArr = (inRecord.StrListArr.Count - 1);
            List<int> lengthIndexes = new List<int>(inHeader.StrList.Count);

            for (int i = 0; i < inHeader.StrList.Count; i++)
            {
                int j = inHeader.StrList[i].Length > inRecord.StrListArr[countStrListArr][i].Length ? inHeader.StrList[i].Length : inRecord.StrListArr[countStrListArr][i].Length;
                lengthIndexes.Add(j);
            }
            return lengthIndexes;
        }
    }
}