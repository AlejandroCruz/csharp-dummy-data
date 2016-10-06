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
            string csvRawFileName = "rawData.csv";
            string csvProcessedFileName = "processedData.csv";
            string csvUpdatedFileName = "updatedData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);
            string[] processedLines;
            string charToDelete = "\"";
            char valueDelimiters = ',';

            ProcessLines objProcessLines = new ProcessLines(rawLines);
            CreateTextFile newCSV = new CreateTextFile(csvProcessedFileName);

            // Display original quoted lines
            System.Console.WriteLine("Input from: {0}\n", csvRawFileName);
            for (int i = 0; i < rawLines.Length; i++)
            {
                System.Console.WriteLine(rawLines[i]);
            }

            /*
             * UX enhancement:
             * - Deafult constructor takes optional time argument
             * - Method 'addDelay' parameters: inTime, inText, inLoop
             */
            System.Console.WriteLine("\n>>> Processing: Delete quotation");
            UXEnhancements uxEnhance1 = new UXEnhancements();
            uxEnhance1.addDelay(1000, "... ", 1);
            System.Console.WriteLine("\n");

            // Delete characters & display data lines
            processedLines = objProcessLines.deleteChars(rawLines, charToDelete);
            for (int i = 0; i < processedLines.Length; i++)
            {
                System.Console.WriteLine(processedLines[i]);
            }
            System.Console.WriteLine("\nOuput file: {0}\n", csvProcessedFileName);

            // Create new file with processed lines
            newCSV.createFile(csvPath, processedLines);

            // Split values from each line
            objProcessLines.splitValues(processedLines, valueDelimiters);
            System.Console.WriteLine(">>> Fetching values");
            uxEnhance1.addDelay(500, ".", 5);
            System.Console.WriteLine("Ready\n");
            UXEnhancements uxEnhance2 = new UXEnhancements();
            uxEnhance2.addDelay();

            // Show numbered list of values in column format
            int numberedList = 0;
            for (int i = 0; i < objProcessLines.TabularRow[0].Length; i++)
            {
                ++numberedList;
                System.Console.WriteLine("{0}. {1} : {2}", numberedList, objProcessLines.TabularRow[0][i], objProcessLines.TabularRow[1][i]);
            }
            System.Console.WriteLine();

            // Display updated value (TransactionNumber:50322311)
            int elementIndex = 1;
            string newStringVal = "00000000";            
            UpdateLineValues updateVal = new UpdateLineValues(elementIndex, newStringVal);
            updateVal.updateLine(objProcessLines);

            // Create new line with updated value and write to new file
            objProcessLines.connectValues();

            // Keep the console window open in debug mode.
            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}
