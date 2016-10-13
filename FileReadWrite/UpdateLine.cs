using System;

namespace FileReadWrite
{
    class UpdateLine
    {
        public UpdateLine()
        { }

        //public string modifyLine(string inLineStr, int[] indexes)
        //{
        //    string strLine = inLineStr;
        //    int[] indexValue = indexes;
        //    string tmpString;

        //    for (int i = 0; i< strLine.Length; i++)
        //    {
        //        int iA = indexValue[i];

        //        tmpString = incrementDataValue(strLine[iA]);
        //        oldArrayVal[iA] = newArrayVal[i];
        //                        updatedList.Add(oldArrayVal[iA]);
        //    }

        //}


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
