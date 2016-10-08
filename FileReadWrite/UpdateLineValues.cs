using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int[] indexArray;
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
        }

        public void updateLine(bool inTrigger, int inAmountLines)
        {
            bool incrementTrigger = inTrigger;
            int amountLines = inAmountLines;
            int loopCount = updateArray.Length;
            string[] oldString = new string[loopCount];
            string[] incrementedArray = new string[updateArray.Length];

            for(int i = 0; i < loopCount; i++)
            {
                int iA = indexArray[i];
                oldString[i] = objUpdate.TabularRow[1][iA];

                if (incrementTrigger)
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
