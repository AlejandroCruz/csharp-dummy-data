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

            UpdateLine objUpdateHead = new UpdateLine();
            int[] elementIndex = new int[] { };
            objUpdateHead.modifySingleLine(headList, elementIndex);

            UpdateLine objUpdateLine = new UpdateLine();
            elementIndex = new int[] { 0 };
            objUpdateLine.modifySingleLine(lineList, elementIndex);

            int totalLines = 10;
            objUpdateLine.modifyMultiLine(elementIndex, totalLines);

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
