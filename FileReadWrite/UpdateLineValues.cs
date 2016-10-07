using System.Threading.Tasks;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int[] indexArray;
        private string[] oldString;
        private string[] updateArray;
        private ProcessLines objUpdate;

        public UpdateLineValues()
        { }
        public UpdateLineValues(ProcessLines inProcLine, int[] indexes, string[] inUpdateArray)
        {
            objUpdate = new ProcessLines();
            objUpdate = inProcLine;
            indexArray = indexes;
            updateArray = inUpdateArray;
            updateLine();
        }

        public void updateLine()
        {
            int loopCount = updateArray.Length;
            oldString = new string[loopCount];

            for(int i = 0; i < loopCount; i++)
            {
                int iA = indexArray[i];
                oldString[i] = objUpdate.TabularRow[1][iA];
                objUpdate.TabularRow[1][iA] = updateArray[i];
            }
        }
    } // END Class
}
