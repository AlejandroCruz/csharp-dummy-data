using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int index;
        private string oldString;
        private string newString;

        public UpdateLineValues(int selectedIndex, string userProvidedString)
        {
            index = selectedIndex;
            newString = userProvidedString;
        }

        // Update
        public void updateUniqueValue(ProcessLines inLinesData)
        {
            oldString = inLinesData.getValue(index);
            inLinesData.setValue(index, newString);

            System.Console.WriteLine();
            System.Console.WriteLine("\n>>> Processing: Update value");
            Task.Delay(2000).Wait();
            System.Console.WriteLine();
            System.Console.WriteLine("\nOld string value \"{0}\" updated to \"{1}\"", oldString, inLinesData.getValue(index));
        }
    }
}
