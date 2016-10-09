using System;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private int amountLines;
        private int[] indexArray;
        private string[] oldString;
        private string[] updateArray;
        private string[] incrementedArr;
        private string[][] tabRows;
        private ProcessLines objUpdate;

        public UpdateLineValues(ProcessLines inProcLine)
        {
            objUpdate = new ProcessLines();
            objUpdate = inProcLine;
        }

        public string[][] TabRow
        {
            get { return tabRows; }
        }

        public string[][] updateLine(string[] inStringVal, int[] indexes, int inAmountLines)
        {
            updateArray = inStringVal;
            indexArray = indexes;
            amountLines = inAmountLines;
            oldString = new string[indexArray.Length];
            incrementedArr = new string[updateArray.Length];
            int iA;

            if (amountLines == 1)
            {
                iA = indexArray[1];
                oldString[1] = objUpdate.TabularRow[1][iA];

                string incrementedStr = incrementDataValue(updateArray[1]);
                objUpdate.TabularRow[1][iA] = incrementedStr;

                return null;
            }
            else
            {
                tabRows = new string[amountLines][];

                for(int x = 0; x < amountLines; x++)
                {
                    tabRows[x] = new string[updateArray.Length];

                    for (int i = 0; i < updateArray.Length; i++)
                    {
                        incrementedArr[i] = incrementDataValue(updateArray[i]);
                        tabRows[x][i] = incrementedArr[i];
                    }
                }
                return tabRows;
            } // END else
        }

        private string incrementDataValue(string inUpdateStr)
        {
            int tmpInt;
            string uStr = inUpdateStr;
            DateTime tmpDt;

            if (Int32.TryParse(uStr, out tmpInt))
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
