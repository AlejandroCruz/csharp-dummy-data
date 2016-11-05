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

        public void CreateFile(UpdateLine inHeader, UpdateLine inRecord, bool inOverwrite)
        {
            if (inOverwrite)
            {
                System.IO.File.AppendAllLines(filePath + fileName, inHeader.StrList);
                System.IO.File.AppendAllLines(filePath + fileName, inRecord.StrList);
            }
            else
            {
                System.IO.File.WriteAllLines(filePath + fileName, inHeader.StrList);
                System.IO.File.AppendAllLines(filePath + fileName, inRecord.StrList);
            }
        }

    }
}
