namespace FileReadWrite
{
    class CreateTextFile
    {
        private string nFile;

        // Overloaded constructor
        public CreateTextFile(string inFile)
        {
            nFile = inFile;
        }

        // Create new file and write lines
        public void createFile(string inPath, string[] inLines)
        {
            System.IO.File.WriteAllLines(inPath + nFile, inLines);
        }
    }
}
