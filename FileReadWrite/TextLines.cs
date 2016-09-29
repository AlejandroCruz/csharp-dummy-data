/*
 * Console application: FileReadWrite
 * Date: 9/2016
 * Description: Training purpose application to learn I/O process in C#
 *  The application reads lines of text from file in specified dir. path
 *  and displays to console. It deletes special characters and rewrites
 *  the data to new file.
 *  Added delay functions are for end user experience.
 */

namespace FileReadWrite
{
    class TextLines
    {
        static void Main(string[] args)
        {
            string csvFileName = "rawData.csv";
            string csvNewFileName = "newData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            char[] valueDelimiters = { ',' };
            
            string[] textLines = System.IO.File.ReadAllLines(csvPath + csvFileName);
            ProcessLines linesData = new ProcessLines(textLines);
            CreateTextFile newCSV = new CreateTextFile(csvNewFileName);

            // Display original quoted lines
            System.Console.WriteLine("Input from: {0}\n", csvFileName);
            for (int i = 0; i < textLines.Length; i++)
            {
                System.Console.WriteLine(textLines[i]);
            }

            /*
             * UX enhancement:
             * - Deafult constructor takes optional time argument
             * - Method 'addDelay' parameters: inTime, inText, inLoop
             */
            System.Console.WriteLine("\n>>> Processing: Delete quotation");
            UXEnhancements uxEnhance = new UXEnhancements();
            uxEnhance.addDelay(1000, "... ", 1);
            System.Console.WriteLine("\n");

            // Delete characters & display
            string aChar= "\"";
            string[]  processedLines = linesData.deleteChars(textLines, aChar);
            for (int i = 0; i < processedLines.Length; i++)
            {
                System.Console.WriteLine(processedLines[i]);
            }
            System.Console.WriteLine("\nOuput file: {0}\n", csvNewFileName);

            // Split lines into separate objects


            // Show split values from each line
            string[] splittedValues = linesData.splitValues(processedLines, valueDelimiters);
            ///TEST: Confirm split values by display
            System.Console.WriteLine("\nNumber of values in each line: {0}, {1}", splittedValues[0].Length, splittedValues[1].Length);
            uxEnhance.addDelay(1000, "", 1);
            int numberedList = 1;
            for (int i = 0; i < processedLines.Length; i++)
            {
                foreach(string s in splittedValues)
                {
                    System.Console.WriteLine(numberedList++ + ". " + s);
                }
            }

            // Create new file with processed lines
            newCSV.createFile(csvPath, processedLines);

            // Display updated value
            int elementIndex = 1;
            string newStringVal = "00000000";            
            UpdateLineValues updateVal = new UpdateLineValues(elementIndex, newStringVal);
            updateVal.updateUniqueValue(linesData);

            // Wait before exit in debug mode
            uxEnhance.addDelay(1000, "\nExit... ", 1);
        }
    }
}
