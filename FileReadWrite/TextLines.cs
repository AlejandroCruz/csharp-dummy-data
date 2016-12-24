/* Console application: FileReadWrite
 * Description:
 *  Read tabular data from CSV file in specified dir. and display to console.
 *  Delete special characters and rewrite to new file.
 *  Optional delay functions @UXEnhancements are for end user experience.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace FileReadWrite
{
    class TextLines
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // GUI
            UXEnhancements delay = new UXEnhancements(500);
            FileReadWriteGUI inputFromGUI = new FileReadWriteGUI();
            inputFromGUI.CallbackGUI();

            // Display original quoted lines
            string[] rawLines = File.ReadAllLines(inputFromGUI.InputOldFilePath + inputFromGUI.InputOldFileName);
            Console.WriteLine(">>> Input file path: {0}\n", inputFromGUI.InputOldFilePath);
            Console.WriteLine(">>> Raw lines:");
            for (int i = 0; i < rawLines.Length; i++)
            {
                Console.WriteLine(rawLines[i]);
            }
            Console.WriteLine(Environment.NewLine);

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

            // Header edit
            UpdateLine updateHead = new UpdateLine(headList);
            if (inputFromGUI.InputEditHeaders)
            {
                updateHead.ModifySingleLine(inputFromGUI.ElementIndex);
            }
            // Row edit
            UpdateLine updateLine = new UpdateLine(recordList, inputFromGUI.LineAmount);
            if (inputFromGUI.LineAmount < 2)
            {
                updateLine.ModifySingleLine(inputFromGUI.ElementIndex);
            }
            else
            {
                updateLine.ModifyMultiLine(inputFromGUI.ElementIndex);
            }

            // Longest field indexes for column padding
            List<int> longestColumnField = new List<int>();
            longestColumnField = ProcessLines.CompareFields(updateHead, updateLine);

            // Concatenate Values
            string[] dataSet = new string[] {};
            dataSet = ProcessLines.AppendValues(updateHead, updateLine);

            // Write data to new file
            //bool overwrite = true;
            //CreateTextFile objNewTxtFile = new CreateTextFile(newFileName, newFilePath);
            //objNewTxtFile.CreateFile(dataSet, overwrite);

            // Results
            delay.addDelay();
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

            if (inputFromGUI.LineAmount < 2)
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