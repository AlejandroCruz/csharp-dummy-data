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
            // - Constructor takes 0 to 3 values
            // - Values & order: time, message, repeat
            System.Console.WriteLine("\n>>> Processing: Delete quotation");
            UXEnhancements uxEnhance = new UXEnhancements(1000, "... ", 3);
            System.Console.WriteLine("\n");
            // Actual deletion
            string[]  processedLines = linesData.deleteQuotes(textLines);

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
            Task.Delay(1000).Wait(); System.Console.Write("\nExit... ");
            Task.Delay(2000).Wait();
        }
    }
}
