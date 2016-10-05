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
            string[] textLines = System.IO.File.ReadAllLines(csvPath + csvFileName);
            char valueDelimiters = ',';

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
            UXEnhancements uxEnhance1 = new UXEnhancements();
            uxEnhance1.addDelay(1000, "... ", 1);
            System.Console.WriteLine("\n");

            // Delete characters & display
            string aChar= "\"";
            string[]  processedLines = linesData.deleteChars(textLines, aChar);
            for (int i = 0; i < processedLines.Length; i++)
            {
                System.Console.WriteLine(processedLines[i]);
            }
            System.Console.WriteLine("\nOuput file: {0}\n", csvNewFileName);

            // Split values from each line
            linesData.splitValues(processedLines, valueDelimiters);
            System.Console.WriteLine(">>> Fetching values");
            uxEnhance1.addDelay(500, ".", 5);
            System.Console.WriteLine("Ready\n");
            UXEnhancements uxEnhance2 = new UXEnhancements();
            uxEnhance2.addDelay();


            // Show numbered list of values
            int numberedList = 0;
            for (int i = 0; i < linesData.TabularRow[0].Length; i++)
            {
                ++numberedList;
                System.Console.WriteLine("{0}. {1} : {2}", numberedList, linesData.TabularRow[0][i], linesData.TabularRow[1][i]);
            }
            System.Console.WriteLine();

            // Create new file with processed lines
            newCSV.createFile(csvPath, processedLines);
/*            
            // Display updated value
            int elementIndex = 1;
            string newStringVal = "00000000";            
            UpdateLineValues updateVal = new UpdateLineValues(elementIndex, newStringVal);
            updateVal.updateUniqueValue(linesData);

            // Wait before exit in debug mode
            uxEnhance.addDelay(1000, "\nExit... ", 1);
*/
        }
    }
}
