using System;

namespace FileReadWrite
{
    class UpdateLineValues
    {
        private char letter = 'A';
        private int amountLines;
        private int charAddCounter = 0;
        private int updateArrayLength = 0;
        private string originUpdateArray;
        private int[][] indexArray;
        private string[] oldString;
        private string[] updateArray;
        private string[][] updatedTabRow;
        private ProcessLines objUpdate;

        public UpdateLineValues(ProcessLines inProcLine)
        {
            objUpdate = new ProcessLines();
            objUpdate = inProcLine;
        }

        public string[][] UpdatedTabRow
        {
            get { return updatedTabRow; }
        }

        public string[][] updateLine(string[] inLineVal, int[][] indexes, int inAmountLines)
        {
            updateArray = inLineVal;
            indexArray = indexes;
            amountLines = inAmountLines;
            oldString = new string[indexArray.Length];

            int z = (indexArray[0].Length == 0) ? 1 : 0; // "Header" line-data empty?

            if (amountLines == 1)
            {
                for (int i = 0; i < updateArray.Length; i++)
                {
                    int iA = indexArray[z][i];
                    oldString[1] = objUpdate.ProcessedTabRow[z][iA];

                    if(z==1)
                        updateArray[i] = incrementDataValue(updateArray[i]);
                    objUpdate.ProcessedTabRow[z][iA] = updateArray[i];
                }
                return objUpdate.ProcessedTabRow;
            }
            else
            {
                updatedTabRow = new string[amountLines][];
                updatedTabRow = objUpdate.ProcessedTabRow;

                for(int x = 0; x < amountLines; x++)
                {
                    updatedTabRow[x] = new string[updateArray.Length];

                    for (int i = 0; i < updateArray.Length; i++)
                    {
                        updateArray[i] = incrementDataValue(updateArray[i]);
                        updatedTabRow[x][i] = updateArray[i];
                    }
                }
                return updatedTabRow;
            }
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
                switch (charAddCounter)
                {
                    case 0:
                        updateArrayLength = uStr.Length;
                        charAddCounter++;
                        break;
                    case 1:
                        originUpdateArray = uStr.Substring((uStr.Length - updateArrayLength), updateArrayLength);
                        uStr = originUpdateArray;
                        break;
                    default:
                        break;
                }
                uStr = letter + uStr;
                letter++;
            }
            return uStr;
        }

    }
}
