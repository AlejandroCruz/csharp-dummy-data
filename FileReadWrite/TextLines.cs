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
            string oldFilePath = @"C:\Users\FileReadWrite\";
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
            int[] elementIndex = new int[] { };
            UpdateLine objUpdateHead = new UpdateLine(headList);
            objUpdateHead.ModifySingleLine(elementIndex);

            // Row edit
            int totalLines = 10;
            elementIndex = new int[] { 0,1,2,3,4,5,6,7,8 };
            UpdateLine objUpdateLine = new UpdateLine(recordList, totalLines);
            if (totalLines < 2)
            { objUpdateLine.ModifySingleLine(elementIndex); }
            else
            { objUpdateLine.ModifyMultiLine(elementIndex); }

            // Longest field indexes for column padding
            List<int> lenghtStrArr = new List<int>();
            ProcessLines objPostProcess = new ProcessLines();
            lenghtStrArr = objPostProcess.CompareFields(objUpdateHead, objUpdateLine);

            // Concatenate Values
            string[] dataSet = new string[] { };
            dataSet = objPostProcess.AppendValues(objUpdateHead, objUpdateLine);

            // Write data to new file
            bool overwrite = true;
            CreateTextFile objNewTxtFile = new CreateTextFile(newFileName, newFilePath);
            objNewTxtFile.CreateFile(dataSet, overwrite);

            // Results
            Console.WriteLine(">>> Begin unique tabular data:\n");
            int counter = 0;
            int totalStrLength = 0;
            int rowDivider = 0;
            foreach (string s in objUpdateHead.StrList)
            { totalStrLength += s.Length; }

            for (int i = 0; i < lenghtStrArr.Count; i++)
            {
                // Padding: 4 = amount of characters padding the column
                rowDivider += int.Parse(lenghtStrArr[i].ToString()) + 4;
            }

            foreach (string s in objUpdateHead.StrList)
            {
                // Padding: "| "
                Console.Write("| {0," + lenghtStrArr[counter] + "} |", s);
                counter++;
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine(new String('-', rowDivider));

            if (totalLines < 2)
            {
                counter = 0;

                foreach (string s in objUpdateLine.StrList)
                {
                    Console.Write("| {0," + lenghtStrArr[counter] + "} |", s);
                    counter++;
                }
                Console.Write(Environment.NewLine);
            }
            else
            {
                int count = objUpdateLine.StrListArr.Count;

                for (int i = 0; i < count; i++)
                {
                    counter = 0;

                    foreach (string s in objUpdateLine.StrListArr[i])
                    {
                        Console.Write("| {0," + lenghtStrArr[counter] + "} |", s);
                        counter++;
                    }
                    Console.Write(Environment.NewLine);
                }
            }

            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}