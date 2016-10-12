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

namespace FileReadWrite
{
    class TextLines
    {
        static void Main(string[] args)
        {
            bool overwrite = false;
            char valueDelimiter = ',';
            string csvRawFileName = "rawData.csv";
            string csvProcessedFileName = "processedData.csv";
            string csvUpdatedFileName = "updatedData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            string charToDelete = "\"";
            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);
            string[] processedLines;

            ProcessLines objProcessLines;
            CreateTextFile processedCSV;

            // Display original quoted lines
            Console.WriteLine("Input from: {0}\n", csvRawFileName);
            for (int i = 0; i < rawLines.Length; i++)
            {
                Console.WriteLine(rawLines[i]);
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(">>> Processing: Delete quotation");

            /*
             * UX enhancement:
             * - Deafult constructor takes optional time argument
             * - Method 'addDelay' parameters: inTime, inText, inLoop
             */
            UXEnhancements uxEnhance1 = new UXEnhancements();
            uxEnhance1.addDelay(100, ".", 3);

            Console.WriteLine("Complete\n");
            Console.WriteLine(Environment.NewLine);

            // Delete characters & display data lines
            objProcessLines = new ProcessLines(rawLines);
            processedLines = objProcessLines.deleteChars(rawLines, charToDelete);
            for (int i = 0; i < processedLines.Length; i++)
            {
                Console.WriteLine(processedLines[i]);
            }
            Console.WriteLine("\nOuput file: {0}", csvProcessedFileName);

            // Create file with processed lines
            processedCSV = new CreateTextFile(csvProcessedFileName);
            processedCSV.createFile(csvPath, processedLines, overwrite);

            // Split values from each line
            objProcessLines.splitValues(processedLines, valueDelimiter);

            Console.WriteLine(">>> Fetching values");
            uxEnhance1.addDelay(100, ".", 6);
            Console.WriteLine("Ready\n");

            UXEnhancements uxEnhance2 = new UXEnhancements();
            uxEnhance2.addDelay(); // Deafult: 2 seconds

            // Show numbered list of values in column format
            int numberedList = 0;
            for (int i = 0; i < objProcessLines.ProcessedTabRow[0].Length; i++)
            {
                Console.WriteLine("{0}. {1} : {2}", numberedList, objProcessLines.ProcessedTabRow[0][i], objProcessLines.ProcessedTabRow[1][i]);
                numberedList++;
            }
            Console.WriteLine(Environment.NewLine);

            // Update value (TransactionNumber:50322311 | 12345678)
            int amountOfLines = 2;
            string[] newLineVal = { "Business", "10000000", "2016-10-07", "90" };
            int[][] elementIndex = new int[2][];
            string[][] tabularLines;
            elementIndex[0] = new int[] {};
            elementIndex[1] = new int[] { 0, 1, 2, 7 };
            UpdateLineValues updateLineVal = new UpdateLineValues(objProcessLines);
            tabularLines = updateLineVal.updateLine(newLineVal, elementIndex, amountOfLines);

            // Concatenate updated values into a line(string) of data
            //string[] updatedLine = objProcessLines.appendValues();
            //Console.Write("\n>>> Creating new data line");
            //uxEnhance1.addDelay(300, ".", 9);
            //Console.WriteLine();
            //for(int i = 1; i < updatedLine.Length; i++)
            //{
            //    Console.WriteLine("\nUpdated data line:\n{0}", updatedLine[i]);
            //}

            // Create one or multiple unique lines & write to new file
            Console.WriteLine("Value in 'Head': {0}", tabularLines[0][0]);
            for (int i = 1; i < tabularLines.Length; i++)
            {
                foreach(string s in tabularLines[i])
                Console.WriteLine("Value in 'Line': {0}", s);
            }


            //UpdateFileLines fileLine = new UpdateFileLines();
            //fileLine.appendLine(updatedLine);
            //overwrite = true;
            //processedCSV = new CreateTextFile(csvUpdatedFileName);
            //processedCSV.createFile(csvPath, updatedLines, overwrite);

            //
            // Keep the console window open in debug mode.
            //
            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}
