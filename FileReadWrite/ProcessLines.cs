using System.Threading.Tasks;

namespace FileReadWrite
{
    class ProcessLines
    {
        private string[] editedLines;
        private char[] delimiters;
        private string[] values;

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
            get { return editedLines; }    // All lines
        }
        public string[] getValues()
        {
            return values;                 // All values in line
        }
        public string getValues(int index)
        {
            return values[index];          // Single value within line
        }
        public void setValue(int index, string newVal)
        {
            values[index] = newVal;
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

        // Split values for each line
        public string[] splitValues(string[] inLines, char[] inDelimiters)
        {
            for (int i = 0; i < inLines.Length; i++)
            {
                delimiters = inDelimiters;
                values = inLines[i].Split(delimiters);
            }
            return values;

        }

    }
}