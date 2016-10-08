using System;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int loopCount;
        private int amountLines;
        private int[] indexArray;
        private string[] oldString;
        private string[] updateArray;
        private string[] incrementedArray;
        private ProcessLines objUpdate;

        public UpdateLineValues()
        { }
        public UpdateLineValues(ProcessLines inProcLine)
        {
            objUpdate = new ProcessLines();
            objUpdate = inProcLine;
        }

        public void updateLine(string[] inStringVal, int[] indexes, int inAmountLines)
        {
            updateArray = inStringVal;
            indexArray = indexes;
            amountLines = inAmountLines;
            loopCount = updateArray.Length;
            oldString = new string[loopCount];
            incrementedArray = new string[updateArray.Length];

            for(int i = 0; i < loopCount; i++)
            {
                int iA = indexArray[i];
                oldString[i] = objUpdate.TabularRow[1][iA];

                updateArray[i] = incrementDataValue(updateArray[i]);
                objUpdate.TabularRow[1][iA] = updateArray[i];
            }

        }

        private string incrementDataValue(string inUpdateStr)
        {
            string uStr = inUpdateStr;
            int tmpInt;
            DateTime tmpDt;

            if(Int32.TryParse(uStr, out tmpInt))
            {
                tmpInt++;
                uStr = Convert.ToString(tmpInt);
            }
            else if(DateTime.TryParse(uStr, out tmpDt))
            {
                DateTime tD = tmpDt.AddDays(1);
                string format = "yyyy-M-d";
                uStr = tD.ToString(format);
            }
            else
            {
                uStr = "AA-" + uStr;
            }
            return uStr;
        }

    }
}
