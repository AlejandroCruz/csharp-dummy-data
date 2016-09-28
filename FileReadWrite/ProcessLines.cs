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

        public string[] TextLines
        {
            get { return editedLines; }
        }
        public string getValue(int index)
        {
            return values[index];
        }
        public void setValue(int index, string newVal)
        {
            values[index] = newVal;
        }

        // Display new lines to console without quotation
        public string[] deleteChars(string[] inLines, string deleteC)
        {
            string c = deleteC;

            for (int i = 0; i < editedLines.Length; i++)
            {
                editedLines[i] = inLines[i].Replace(c, string.Empty);
                System.Console.WriteLine(editedLines[i]);
            }
            return editedLines;
        }

        // Split values for each line
        public void splitValues(string[] inLines, char[] inDelimiters)
        {
            for (int i = 0; i < inLines.Length; i++)
            {
                delimiters = inDelimiters;
                values = inLines[i].Split(delimiters);
                ///TEST
                System.Console.WriteLine("\nNumber of values in each line: {0}", values.Length);
                Task.Delay(1000).Wait();
                int displayIndex = 1;
                foreach (string s in values)
                {
                    System.Console.WriteLine(displayIndex++ + ". " + s);
                }
            }

        }

    }
}