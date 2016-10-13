using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System;

namespace FileReadWrite
{
    class ProcessLines
    {
        private string headData;
        private string editLine;
        private string[] lineData;
        private string[] editedLines;
        private string[][] processedTabRow;
        private string[] updateLines;
        private string[][] tabularLines;
        private StringBuilder strBuild;

        // Constructors
        public ProcessLines()
        { }
        public ProcessLines(string[] inLines)
        {
            editedLines = inLines;
        }

        // Accessors
        public string[] TextLines
        {
            get { return editedLines; }
        }
        public string[] UpdatedLines
        {
            get { return updateLines; }
        }
        public string[][] ProcessedTabRow
        {
            get { return processedTabRow; }
            set { processedTabRow = value; }
        }

        public string removeChar(string inLine, string removeC)
        {
            editLine = inLine;
            string c = removeC;

            for (int i = 0; i < editLine.Length; i++)
            {
                editLine = inLine.Replace(c, string.Empty);
            }
            return editLine;
        }

        public string[] deleteChars(string[] inLines, string deleteC)
        {
            string c = deleteC;

            for (int i = 0; i < editedLines.Length; i++)
            {
                editedLines[i] = inLines[i].Replace(c, string.Empty);
            }
            return editedLines;
        }

        public void splitValues(string[] inLines, char inDelimiters)
        {
            string[] values;
            char delimiters = inDelimiters;
            processedTabRow = new string[inLines.Length][];

            for (int i = 0; i < processedTabRow.Length; i++)
            {
                values = inLines[i].Split(delimiters);
                processedTabRow[i] = values;
            }
        }

        public string[] appendValues(string [][] inTabularLines)
        {
            tabularLines = inTabularLines;
            int lineCount = tabularLines.Length;
            updateLines = new string[lineCount];

            for (int i = 0; i < lineCount; i++)
            {
                strBuild = new StringBuilder();

                for (int x= 0; x < this.ProcessedTabRow[i].Length; x++)
                {
                    strBuild.Append(this.ProcessedTabRow[i][x] + ",");
                }
                updateLines[i] = strBuild.ToString().Trim(new char[] { ' ', ',' });
                if (i > 0)
                    lineData[i-1] = updateLines[i];
            }
            headData = updateLines[0];
            return updateLines;
        }

    } // END Class
}