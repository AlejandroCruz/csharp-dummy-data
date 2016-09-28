namespace FileReadWrite
{
    class ProcessLines
    {
        private string[] editedLines;
        private char[] delimiters;
        private string[] values;

        // Overloaded constructor
        public ProcessLines(string[] inLines)
        {
            editedLines = new string[inLines.Length];
        }

        public string[] TextLines
        {
            get { return editedLines; }
        }

        // Display new lines to console without quotation
        public string[] deleteQuotes(string[] inLines)
        {
            for (int i = 0; i < editedLines.Length; i++)
            {
                editedLines[i] = inLines[i].Replace("\"", string.Empty);
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
                System.Console.WriteLine("\nNumber of values: {0}", values.Length);
                foreach(string s in values)
                {
                    System.Console.WriteLine(s);
                }
            }
            
        }
    }
}
