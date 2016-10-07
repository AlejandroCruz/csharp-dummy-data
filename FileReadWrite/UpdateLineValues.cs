using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int[] indexArray;
        private string[] oldString;
        private string[] updateArray;
        private string[] incrementedArray;
        private ProcessLines objUpdate;

        public UpdateLineValues()
        { }
        public UpdateLineValues(ProcessLines inProcLine, int[] indexes, string[] inUpdateArray)
        {
            objUpdate = new ProcessLines();
            objUpdate = inProcLine;
            indexArray = indexes;
            updateArray = inUpdateArray;
        }

        public void updateLine(bool inTrigger)
        {
            bool incrementTrigger = inTrigger;
            int loopCount = updateArray.Length;
            oldString = new string[loopCount];
            incrementedArray = new string[updateArray.Length];

            for(int i = 0; i < loopCount; i++)
            {
                int iA = indexArray[i];
                oldString[i] = objUpdate.TabularRow[1][iA];

                if (incrementTrigger)
                    updateArray = incrementDataValue(updateArray);

                objUpdate.TabularRow[1][iA] = updateArray[i];
            }
        }

        protected string[] incrementDataValue(string[] inUpdateArray)
        {
            string[] localUpdateArray = inUpdateArray;
            int localTempInt;
            for(int i = 0; i < localUpdateArray.Length; i++)
            {
                if (localUpdateArray[i].Any(x => !char.IsLetter(x)))
                    localUpdateArray[i] += "*ABC*";
                else
                {
                    localTempInt = Convert.ToInt32(localUpdateArray[i], 10);
                    localTempInt++;
                    localUpdateArray[i] = Convert.ToString(localTempInt);
                }
            }
            return localUpdateArray;
        }

    }
}
