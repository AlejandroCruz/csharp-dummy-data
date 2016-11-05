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

        public void CreateFile(UpdateLine header, UpdateLine recordSet, bool inOverwrite)
        {
            if (inOverwrite)
            {
                System.IO.File.AppendAllLines(filePath + fileName, header.StrList);
                System.IO.File.AppendAllLines(filePath + fileName, recordSet.StrList);
            }
            else
            {
                System.IO.File.WriteAllLines(filePath + fileName, header.StrList);
                System.IO.File.AppendAllLines(filePath + fileName, recordSet.StrList);
            }
        }

    }
}
