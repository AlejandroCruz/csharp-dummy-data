namespace FileReadWrite
{
    class ProcessLines
    {
        private string[] editedLines;

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
        public void deleteQuotes(string[] inLines)
        {
            for (int i = 0; i < editedLines.Length; i++)
            {
                editedLines[i] = inLines[i].Replace("\"", string.Empty);
                System.Console.WriteLine(editedLines[i]);
            }
        }
    }
}
