using System.Collections.Generic;
using System.Text;

namespace FileReadWrite
{
    class ProcessLines
    {
        private string editLine;
        public List<string> lineList;

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

    } // END Class
}