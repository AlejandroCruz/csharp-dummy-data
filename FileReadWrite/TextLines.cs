using System.Threading.Tasks;

namespace FileReadWrite
{
    class TextLines
    {
        static void Main(string[] args)
        {
            // Read each line of the file into a string array
            string csvFileName = "rawData.csv";
            string csvNewFileName = "newData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            string[] textLines = System.IO.File.ReadAllLines(csvPath + csvFileName);
            ProcessLines rawData = new ProcessLines(textLines);
            CreateTextFile newCSV = new CreateTextFile(csvNewFileName);

            // Display original quoted lines
            System.Console.WriteLine("Input from: {0}\n", csvFileName);
            for (int i = 0; i < textLines.Length; i++)
            {
                System.Console.WriteLine(textLines[i]);
            }

            // Pure nonesense... but kind of cool
            System.Console.WriteLine("\n>>> Processing: Delete quotation");
            Task.Delay(1500).Wait(); System.Console.Write("... ");
            Task.Delay(1500).Wait(); System.Console.Write("... ");
            Task.Delay(1500).Wait(); System.Console.Write("...");
            Task.Delay(1500).Wait(); System.Console.WriteLine("\n");

            rawData.deleteQuotes(textLines);

            System.Console.WriteLine("\nOuput file: {0}\n", csvNewFileName);

            // Create new file and write lines
            string[] processedLines = rawData.TextLines;
            newCSV.createFile(csvPath, processedLines);

            // Wait before exit in debug mode
            Task.Delay(1000).Wait(); System.Console.Write("\nExit... ");
            Task.Delay(2000).Wait();
        }
    }
}
