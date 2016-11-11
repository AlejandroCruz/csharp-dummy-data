using System.Collections.Generic;
using System.Text;

namespace FileReadWrite
{
    class ProcessLines
    {
        private int countForColumnPadding = 0;

        public int CountForColumnPadding
        {
            get { return countForColumnPadding; }
        }

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
            string[] lineStrArr = new string[1 + inRecord.StrListArr.Count];
            StringBuilder strBuild = new StringBuilder();

            foreach (string s in inHeader.StrList)
            {
                countForColumnPadding = (countForColumnPadding > s.ToString().Length) ? s.ToString().Length : countForColumnPadding;
                strBuild.Append(s + ",");
            }
            lineStrArr[0] = strBuild.ToString().Trim(new char[] { ' ', ',' });

            for (int i = 0; i < inRecord.StrListArr.Count; i++)
            {
                strBuild = new StringBuilder();

                foreach (string s in inRecord.StrListArr[i])
                {
                    strBuild.Append(s + ",");
                }
                lineStrArr[i + 1] = strBuild.ToString().Trim(new char[] { ' ', ',' });
            }
            return lineStrArr;
        }
    }
}