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
        public void createFile(string inPath, string[] inLines, bool inOverwrite)
        {
            if(inOverwrite == false)
                System.IO.File.AppendAllLines(inPath + nFile, inLines);
            else
                System.IO.File.WriteAllLines(inPath + nFile, inLines);
        }
    }
}
