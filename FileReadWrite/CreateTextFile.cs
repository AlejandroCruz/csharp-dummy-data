namespace FileReadWrite
{
    class CreateTextFile
    {
        private string newFile;

        public CreateTextFile(string inFile)
        {
            newFile = inFile;
        }

        public void createFile(string inPath, string[] inLines, bool inOverwrite)
        {
            if(inOverwrite == false)
                System.IO.File.AppendAllLines(inPath + newFile, inLines);
            else
                System.IO.File.WriteAllLines(inPath + newFile, inLines);
        }
    }
}
