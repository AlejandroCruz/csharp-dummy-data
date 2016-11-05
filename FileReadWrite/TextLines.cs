/*
 * Console application: FileReadWrite
 * Date: 9/2016 - 11/2016
 * Description:
 *  Read tabular data from CSV file in specified dir. and display to console.
 *  Delete special characters (mainly quotation "") and rewrite to new file.
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
            string csvRawFileName = "rawData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);

            // Display original quoted lines
            Console.WriteLine(">>> Input file: {0}\n", csvRawFileName);
            Console.WriteLine(">>> Raw lines:");
            for (int i = 0; i < rawLines.Length; i++)
            {
                Console.WriteLine(rawLines[i]);
            } Console.WriteLine(Environment.NewLine);

            // Remove quotation
            ProcessLines objProcessLine = new ProcessLines();
            string strToRemove = "\"";
            string headLine = objProcessLine.RemoveString(rawLines[0], strToRemove);
            string recordLine = objProcessLine.RemoveString(rawLines[1], strToRemove);

            // Split values
            char valueDelimiter = ',';
            List<string> headList = new List<string>();
            List<string> recordList = new List<string>();
            headList = objProcessLine.SplitValues(headLine, valueDelimiter);
            recordList = objProcessLine.SplitValues(recordLine, valueDelimiter);


            // Table header edit
            int totalLines = 0;
            int[] elementIndex = new int[] { }; // Defaults to elementIndex[0] (no elements)
            UpdateLine objUpdateHead = new UpdateLine(headList, totalLines);
            objUpdateHead.ModifySingleLine(elementIndex);

            // Table record edit
            totalLines = 10;
            elementIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            UpdateLine objUpdateLine = new UpdateLine(recordList, totalLines);
            if (totalLines <= 1)
            { objUpdateLine.ModifySingleLine(elementIndex); }
            else
            { objUpdateLine.ModifyMultiLine(elementIndex); }

            // Results
            Console.WriteLine(">>> Begin unique tabular data:\n");
            foreach (string s in objUpdateHead.StrList)
            { Console.Write("| {0} |", s); }
            Console.Write(Environment.NewLine);
            if (totalLines < 2)
            {
                foreach (string s in objUpdateLine.StrList)
                { Console.Write("| {0} |", s); }
                Console.Write(Environment.NewLine);
            }
            else
            {
                int count = objUpdateLine.StrListArr.Count;
                for (int i = 0; i < count; i++)
                {
                    foreach (string s in objUpdateLine.StrListArr[i])
                    { Console.Write("| {0} |", s); }
                    Console.Write(Environment.NewLine);
                }
            }

            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}