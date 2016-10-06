using System.Threading.Tasks;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int index;
        private string oldString;
        private string newString;
        private ProcessLines objUpdate;

        public UpdateLineValues(int selectedIndex, string userProvidedString)
        {
            index = selectedIndex;
            newString = userProvidedString;
            objUpdate = new ProcessLines();
        }

        public void updateLine(ProcessLines thisProcLine)
        {
            objUpdate = thisProcLine;
            oldString = objUpdate.TabularRow[1][index];
            objUpdate.TabularRow[1][index] = newString;

            System.Console.WriteLine("\nValue of 'oldString' is {0}", oldString);
            System.Console.WriteLine("\nUpdated value of {0} is {1}", objUpdate.TabularRow[0][index], objUpdate.TabularRow[1][index]);
        }
    }
}
