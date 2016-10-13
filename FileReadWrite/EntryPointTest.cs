using System;
using System.Collections.Generic;

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
            UpdateLine objUpdateHead = new UpdateLine();
            UpdateLine objUpdateLine = new UpdateLine();
            objUpdateHead.modifyLine(headArr, elementIndex);
            objUpdateLine.modifyLine(lineArr, elementIndex);

            int lineAmount = 2;
            elementIndex = new int[] { 0, 7 };
            objUpdateLine.multiLine(lineArr, elementIndex, lineAmount);
            int count = objUpdateLine.lineList.Count;
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("Multi line: {0}", objUpdateLine.lineList[i]);
            }

            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}
