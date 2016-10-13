using System;

namespace FileReadWrite
{
    class EntryPointTest
    {
        public static void Main(string[] args)
        {
            string csvRawFileName = "rawData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            char valueDelimiter = ',';

            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);

            ProcessLines objProcessHead = new ProcessLines();
            ProcessLines objProcessLine = new ProcessLines();

            string charToDelete = "\"";
            string headLine = objProcessHead.removeChar(rawLines[0], charToDelete);
            string lineLine = objProcessHead.removeChar(rawLines[1], charToDelete);
            string[] headArr = new string[rawLines[0].Length];
            string[] lineArr = new string[rawLines[1].Length];
            headArr = objProcessHead.splitValues(headLine, valueDelimiter);
            lineArr = objProcessHead.splitValues(lineLine, valueDelimiter);

            UpdateLine objUpdateLine = new UpdateLine();
            lineLine = objUpdateLine.incrementDataValue(lineLine);
            Console.WriteLine("\nUpdated Line object: {0}", lineLine);
        }
    }
}
