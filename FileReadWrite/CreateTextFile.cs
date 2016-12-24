namespace FileReadWrite
{
    class CreateTextFile
    {
        private string fileName;
        private string filePath;

        public CreateTextFile(string inFile, string inPath)
        {
            fileName = inFile;
            filePath = inPath;
        }

        public void CreateFile(string[] inDataSet, bool inOverwrite)
        {
            if (inOverwrite)
            {
                System.IO.File.WriteAllLines(filePath, inDataSet);
            }
            else
            {
                System.IO.File.AppendAllLines(filePath, inDataSet);
            }
        }
    }
}