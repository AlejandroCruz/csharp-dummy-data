using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System;

namespace FileReadWrite
{
    class ProcessLines
    {
        private string[] editedLines;
        private string[][] tabularRow;
        private string[] updateLines;
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
        public string[][] TabularRow
        {
            get { return tabularRow; }
            set { tabularRow = value; }
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
            tabularRow = new string[inLines.Length][];

            for (int i = 0; i < tabularRow.Length; i++)
            {
                values = inLines[i].Split(delimiters);
                tabularRow[i] = values;
            }
        }

        public string[] appendValues()
        {
            int lineCount = this.TabularRow.Length;
            updateLines = new string[lineCount];

            for (int i = 0; i < lineCount; i++)
            {
                strBuild = new StringBuilder();

                for (int x= 0; x < this.TabularRow[i].Length; x++)
                {
                    strBuild.Append(this.TabularRow[i][x] + ",");
                }
                updateLines[i] = strBuild.ToString().Trim(new char[] { ' ', ',' });
            }
            return updateLines;
        }

        //public void appendLine(int inAmountLines)
        //{
        //    int amountLines = inAmountLines;

        //}

    } // END Class
}