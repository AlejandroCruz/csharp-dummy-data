using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private string[] strLine;
        public List<string[]> lineList;

        public UpdateLine()
        { }

        public string[] StrLine
        {
            get { return strLine; }
        }

        public void modifyLine(string[] inLineArr, int[] indexes)
        {
            string tmpString;
            int[] indexValue = indexes;

            strLine = new string[inLineArr.Length];

            for (int i = 0; i < inLineArr.Length; i++)
            {
                strLine[i] = inLineArr[i];
            }

            for(int i = 0; i < indexes.Length; i++)
            {
                int iA = indexes[i];

                tmpString = incrementDataValue(inLineArr[iA]);
                strLine.SetValue(tmpString, iA);
            }

        }

        public void multiLine(string[] inLineArr, int[] indexes, int amountL)
        {
            int[] indexValue = indexes;
            string tmpString;

            strLine = new string[inLineArr.Length];
            lineList = new List<string[]>();

            while(amountL > 0)
            {
                for (int j = 0; j < indexes.Length; j++)
                {
                    int iA = indexes[j];

                    tmpString = incrementDataValue(inLineArr[iA]);
                    strLine.SetValue(tmpString, iA);
                }
                lineList.Add(strLine);
                amountL--;
            }
        }

        public string incrementDataValue(string uString)
        {
            int tmpInt;
            string uStr = uString;
            DateTime tmpDt;

            if (Int32.TryParse(uStr, out tmpInt))
            {
                tmpInt++;
                uStr = Convert.ToString(tmpInt);
            }
            else if (DateTime.TryParse(uStr, out tmpDt))
            {
                DateTime tD = tmpDt.AddDays(1);
                string format = "yyyy-M-d";
                uStr = tD.ToString(format);
            }
            else
            {
                char letter = 'A';
                int charAddCounter = 0;
                int updateArrayLength = 0;
                string originUpdateArray;

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
