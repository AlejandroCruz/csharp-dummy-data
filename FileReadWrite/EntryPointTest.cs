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

            ProcessLines objProcessLine = new ProcessLines();

            string charToDelete = "\"";
            string headLine = objProcessLine.removeChar(rawLines[0], charToDelete);
            string lineLine = objProcessLine.removeChar(rawLines[1], charToDelete);
            string[] headArr = new string[rawLines[0].Length];
            string[] lineArr = new string[rawLines[1].Length];
            headArr = objProcessLine.splitValues(headLine, valueDelimiter);
            lineArr = objProcessLine.splitValues(lineLine, valueDelimiter);

            int[] elementIndex = new int[] { 0, 7 };
            UpdateLine objUpdateLine = new UpdateLine();
            objUpdateLine.modifyLine(lineArr, elementIndex);
            int count = objUpdateLine.StrLine.Length;
            for (int i = 0; i < count; i++)
                Console.WriteLine("{0}. {1}", (i+1), objUpdateLine.StrLine[i]);

            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}
