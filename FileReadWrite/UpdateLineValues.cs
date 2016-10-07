using System.Threading.Tasks;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int index;
        private string oldString;
        private string newString;
        private ProcessLines objUpdate;

        public UpdateLineValues(ProcessLines inProcLine, int selectedIndex, string userProvidedString)
        {
            objUpdate = new ProcessLines();
            objUpdate = inProcLine;
            index = selectedIndex;
            newString = userProvidedString;
            updateLine();
        }

        public void updateLine()
        {
            oldString = objUpdate.TabularRow[1][index];
            objUpdate.TabularRow[1][index] = newString;
        }
    }
}
