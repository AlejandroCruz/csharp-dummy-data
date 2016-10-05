using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class ProcessLines
    {
        private string[] editedLines;
        private string[][] tabularRow;

        // Constructors
        public ProcessLines()
        { }
        public ProcessLines(string[] inLines)
        {
            editedLines = new string[inLines.Length];
        }

        // Accessors
        public string[] TextLines
        {
            get { return editedLines; }
        }
        public string[][] TabularRow
        {
            get { return tabularRow; }
        }

        // Delete quotation
        public string[] deleteChars(string[] inLines, string deleteC)
        {
            string c = deleteC;

            for (int i = 0; i < editedLines.Length; i++)
            {
                editedLines[i] = inLines[i].Replace(c, string.Empty);
            }
            return editedLines;
        }

        // Split values for field-lines
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

    } // END Class
}