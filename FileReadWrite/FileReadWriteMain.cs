using System;
using System.Collections.Generic;
using System.IO;

namespace FileReadWrite
{
    class FileReadWriteMain
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // Console splash
            Console.SetWindowSize(145, 30);
            Console.SetWindowPosition(0, 0);
            Console.WriteLine("Console program for producing generic tabular data.");
            Console.WriteLine("\nSelect file to read from or create new:");
            Console.Write(">>> Press any key to continue...");
            Console.ReadKey(true);

            // GUI read data
            FileReadGUI inputReadForm = new FileReadGUI();

            // Display original quoted lines
            string[] rawLines = File.ReadAllLines(inputReadForm.OldFilePath + inputReadForm.OldFileName);
            Console.WriteLine(">>> Input file: {0}\n", inputReadForm.OldFileName);
            Console.WriteLine(">>> Raw lines:");
            for (int i = 0; i < rawLines.Length; i++)
            {
                Console.WriteLine(rawLines[i]);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(">>> Press any key to continue...\n");
            Console.ReadKey(true);

            // Remove quotation
            string strToRemove = "\"";
            string headLine = ProcessLines.RemoveString(rawLines[0], strToRemove);
            string recordLine = ProcessLines.RemoveString(rawLines[1], strToRemove);

            // Split values
            char valueDelimiter = ',';
            List<string> headList = new List<string>();
            List<string> recordList = new List<string>();
            headList = ProcessLines.SplitValues(headLine, valueDelimiter);
            recordList = ProcessLines.SplitValues(recordLine, valueDelimiter);

            // GUI edit and write data file
            FileWriteGUI inputWriteForm = new FileWriteGUI();
            inputWriteForm.CallbackGUI();

            // Header edit
            UpdateLine updateHead = new UpdateLine(headList);
            if (inputWriteForm.InputEditHeaders)
            {
                updateHead.ModifySingleLine(inputWriteForm.ElementIndex);
            }
            // Row edit
            UpdateLine updateLine = new UpdateLine(recordList, inputWriteForm.LineAmount);
            if (inputWriteForm.LineAmount < 2)
            {
                updateLine.ModifySingleLine(inputWriteForm.ElementIndex);
            }
            else
            {
                updateLine.ModifyMultiLine(inputWriteForm.ElementIndex);
            }

            // Longest field indexes for column padding
            List<int> longestColumnField = new List<int>();
            longestColumnField = ProcessLines.CompareFields(updateHead, updateLine);

            // Concatenate Values
            string[] dataSet = new string[] { };
            dataSet = ProcessLines.AppendValues(updateHead, updateLine);

            // Write data to new file
            bool overwrite = true;
            CreateTextFile objNewTxtFile = new CreateTextFile(inputWriteForm.NewFilePath, inputWriteForm.NewFileName);
            objNewTxtFile.CreateFile(dataSet, overwrite);

            // Results
            Console.WriteLine("\n>>> Begin unique tabular data:\n");
            int counter = 0;
            int totalStrLength = 0;
            int rowDivider = 0;
            foreach (string s in updateHead.StrList)
            {
                totalStrLength += s.Length;
            }

            for (int i = 0; i < longestColumnField.Count; i++)
            {
                // Padding: 4 = amount of characters padding the column
                rowDivider += int.Parse(longestColumnField[i].ToString()) + 4;
            }

            foreach (string s in updateHead.StrList)
            {
                // Padding: "| "
                Console.Write("| {0," + longestColumnField[counter] + "} |", s);
                counter++;
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine(new String('-', rowDivider));

            if (inputWriteForm.LineAmount < 2)
            {
                counter = 0;

                foreach (string s in updateLine.StrList)
                {
                    Console.Write("| {0," + longestColumnField[counter] + "} |", s);
                    counter++;
                }
                Console.Write(Environment.NewLine);
            }
            else
            {
                int count = updateLine.StrListArr.Count;

                for (int i = 0; i < count; i++)
                {
                    counter = 0;

                    foreach (string s in updateLine.StrListArr[i])
                    {
                        Console.Write("| {0," + longestColumnField[counter] + "} |", s);
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
