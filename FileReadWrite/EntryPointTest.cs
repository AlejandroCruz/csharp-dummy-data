using System;

namespace FileReadWrite
{
    class EntryPointTest
    {
        public static void Main(string[] args)
        {
            string csvRawFileName = "rawData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";

            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);

            ProcessLines objProcessHead = new ProcessLines();
            ProcessLines objProcessLine = new ProcessLines();

            string charToDelete = "\"";
            string headLine = objProcessHead.removeChar(rawLines[0], charToDelete);
            string lineLine = objProcessHead.removeChar(rawLines[1], charToDelete);
            Console.WriteLine("Head line: " + headLine);
            Console.WriteLine("Line line: " + lineLine);

        }
    }
}
