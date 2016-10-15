/*
 * Console application: FileReadWrite
 * Date: 9/2016
 * Description: Training purpose application to learn I/O process in C#
 *  The application reads lines of text from file in specified dir. path
 *  and displays to console. It deletes special characters and rewrites
 *  the data to new file.
 *  Added delay functions are for end user experience.
 */

using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class TextLines
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
            List<string> headList = new List<string>();
            List<string> lineList = new List<string>();
            headList = objProcessLine.splitValues(headLine, valueDelimiter);
            lineList = objProcessLine.splitValues(lineLine, valueDelimiter);

            int[] elementIndex = new int[] { };
            UpdateLine objUpdateHead = new UpdateLine();
            UpdateLine objUpdateLine = new UpdateLine();
            objUpdateHead.modifyLine(headList, elementIndex);
            elementIndex = new int[] { 3 };
            objUpdateLine.modifyLine(lineList, elementIndex);

            int totalLines = 10;
            objUpdateLine.multiLine(elementIndex, totalLines);

            Console.WriteLine(">>> Begin");
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
