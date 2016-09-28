using System.Threading.Tasks;

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

            // User experience enhancement: add delay time and message.
            // - Constructor takes optional time
            // - Method 'addDelay' parameters: inTime, inText, inLoop
            System.Console.WriteLine("\n>>> Processing: Delete quotation");
            UXEnhancements uxEnhance = new UXEnhancements();
            uxEnhance.addDelay(2000, "... ", 3);
            System.Console.WriteLine("\n");

            // Delete characters
            string aChar= "\"";
            string[]  processedLines = linesData.deleteChars(textLines, aChar);
            System.Console.WriteLine("\nOuput file: {0}\n", csvNewFileName);

            // Show split values from each line
            linesData.splitValues(processedLines, valueDelimiters);

            // Create new file and write lines
            newCSV.createFile(csvPath, processedLines);

            // Display updated value
            int elementIndex = 1;
            string updateString = "00000000";            
            UpdateLineValues updateVal = new UpdateLineValues(elementIndex, updateString);
            updateVal.updateUniqueValue(linesData);

            // Wait before exit in debug mode
            uxEnhance.addDelay(1000, "\nExit... ", 1);
        }
    }
}
