/*
 * Console application: FileReadWrite
 * Date: 9/2016 - 11/2016
 * Description:
 *  Read lines of text from file in specified dir. path and display to console.
 *  Delete special characters and rewrite the data to new file.
 *  Optional delay functions are for end user experience.
 */

using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class TextLines
    {
        public static void Main(string[] args)
        {
            string csvRawFileName = "rawDataTest.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);

            string charToDelete = "\"";
            ProcessLines objProcessLine = new ProcessLines();
            string headLine = objProcessLine.removeChar(rawLines[0], charToDelete);
            string lineLine = objProcessLine.removeChar(rawLines[1], charToDelete);

            char valueDelimiter = ',';
            List<string> headList = new List<string>();
            List<string> lineList = new List<string>();
            headList = objProcessLine.splitValues(headLine, valueDelimiter);
            lineList = objProcessLine.splitValues(lineLine, valueDelimiter);

            int totalLines = 0;
            int[] elementIndex = new int[] { }; // Defaults to elementIndex[0] (no elements)
            UpdateLine objUpdateHead = new UpdateLine(totalLines);
            UpdateLine objUpdateLine = new UpdateLine(totalLines = 10);
            //elementIndex = new int[] { 0,1,2,3,4,5,6 };
            objUpdateHead.modifySingleLine(headList, elementIndex);
            elementIndex = new int[] { 0, 1, 3 };
            objUpdateLine.modifySingleLine(lineList, elementIndex);

            objUpdateLine.modifyMultiLine(elementIndex);

            Console.WriteLine(">>> Begin");
            foreach (string s in objUpdateHead.StrList)
                Console.Write("{0}, ", s);
            Console.Write(Environment.NewLine);
            int count = objUpdateLine.StrListArr.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (string s in objUpdateLine.StrListArr[i])
                    Console.Write("{0}, ", s);
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}
