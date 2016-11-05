using System.Collections.Generic;
using System.Text;

namespace FileReadWrite
{
    class ProcessLines
    {
        private string editLine;
        public List<string> lineList;
        public List<string[]> lineListArr;

        public ProcessLines()
        { }

        public string RemoveString(string inLine, string rmvStr)
        {
            string rmvS = rmvStr;

            for (int i = 0; i < inLine.Length; i++)
            { editLine = inLine.Replace(rmvS, string.Empty); }
            return editLine;
        }

        public List<string> SplitValues(string inLine, char inDelimiter)
        {
            string[] values;
            lineList = new List<string>();

            values = inLine.Split(inDelimiter);

            for(int i = 0; i < values.Length; i++)
            {
                lineList.Add(values[i]);
            }
            return lineList;
        }

        public string[] AppendValues(UpdateLine inHeader, UpdateLine inRecord)
        {
            int headCount = 1;
            int lineCount = inRecord.StrListArr.Count;
            string[] lineListArr = new string[headCount+lineCount];

            StringBuilder strBuildHead = new StringBuilder();

            foreach (string s in inHeader.StrList)
            {
                strBuildHead.Append(s + ",");
            }
            lineListArr[0] = strBuildHead.ToString().Trim(new char[] { ' ', ',' });

            StringBuilder strBuildRecord;

            for (int i = 0; i < inRecord.StrListArr.Count; i++)
            {
                strBuildRecord = new StringBuilder();

                foreach (string s in inRecord.StrListArr[i])
                {
                    strBuildRecord.Append(s + ",");
                }
                lineListArr[i+headCount] = strBuildRecord.ToString().Trim(new char[] { ' ', ',' });
            }
            return lineListArr;

        }

    } // END Class
}