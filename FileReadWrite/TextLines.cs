/* Console application: FileReadWrite
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
            string csvRawFile = "rawData.csv";
            string newFileName = "newData.csv";
            string oldFilePath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            string newFilePath = oldFilePath;
            string[] rawLines = System.IO.File.ReadAllLines(oldFilePath + csvRawFile);

            // Display original quoted lines
            Console.WriteLine(">>> Input file: {0}\n", csvRawFile);
            Console.WriteLine(">>> Raw lines:");
            for (int i = 0; i < rawLines.Length; i++)
            { Console.WriteLine(rawLines[i]); }
            Console.WriteLine(Environment.NewLine);

            // Remove quotation
            ProcessLines objPreProcess = new ProcessLines();
            string strToRemove = "\"";
            string headLine = objPreProcess.RemoveString(rawLines[0], strToRemove);
            string recordLine = objPreProcess.RemoveString(rawLines[1], strToRemove);

            // Split values
            char valueDelimiter = ',';
            List<string> headList = new List<string>();
            List<string> recordList = new List<string>();
            headList = objPreProcess.SplitValues(headLine, valueDelimiter);
            recordList = objPreProcess.SplitValues(recordLine, valueDelimiter);

            // Header edit
            int totalLines = 0;
            int[] elementIndex = new int[] { }; // Defaults to elementIndex[0] (no elements)
            UpdateLine objUpdateHead = new UpdateLine(headList, totalLines);
            objUpdateHead.ModifySingleLine(elementIndex);

            // Record edit
            totalLines = 20;
            elementIndex = new int[] { 0,1,2,3,4,5,6,7,8,9,11 };
            UpdateLine objUpdateLine = new UpdateLine(recordList, totalLines);
            if (totalLines < 2)
            { objUpdateLine.ModifySingleLine(elementIndex); }
            else
            { objUpdateLine.ModifyMultiLine(elementIndex); }

            // Concatenate Values
            ProcessLines objPostProcess = new ProcessLines();
            string[] dataSet = new string[] { };
            dataSet = objPostProcess.AppendValues(objUpdateHead, objUpdateLine);

            // Write data to new file
            bool overwrite = true;
            CreateTextFile objNewTxtFile = new CreateTextFile(newFileName, newFilePath);
            objNewTxtFile.CreateFile(dataSet, overwrite);

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