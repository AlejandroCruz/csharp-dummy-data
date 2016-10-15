using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class UpdateLine
    {
        private string[] strLine;
        List<string> strList;
        List<string[]> strListArr;

        public UpdateLine()
        {
            strList = new List<string>();
        }

        public string[] StrLine
        {
            get { return strLine; }
        }
        public List<string> StrList
        {
            get { return strList; }
        }
        public List<string[]> StrListArr
        {
            get { return strListArr; }
        }

        public void modifyLine(List<string> sList, int[] indexes)
        {
            try
            {
                if(indexes.GetLength(0) == 0) { return; }
            }
            catch(IndexOutOfRangeException)
            {
                return;
            }

            string tmpString;
            strList = sList;

            for(int i = 0; i < indexes.Length; i++)
            {
                int iA = indexes[i];

                tmpString = incrementDataValue(sList[iA]);
                strList[iA] = tmpString;
            }
        }

        public void multiLine(int[] indexes, int totalL)
        {
            string tmpString;
            strListArr = new List<string[]>();

            for(int i = 0; i < totalL; i++)
            {

                for (int j = 0; j < indexes.Length; j++)
                {
                    int iA = indexes[j];

                    tmpString = incrementDataValue(strList[iA]);
                    strList[iA] = tmpString;
                }
                strListArr.Add(strList.ToArray());
            }
        }

        public string incrementDataValue(string uString)
        {
            string uStr = uString;
            DateTime tmpDt;

            if(System.Text.RegularExpressions.Regex.IsMatch(uStr, @"\D"))
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
            if (System.Text.RegularExpressions.Regex.IsMatch(uStr, @"\d"))
            {
                long tmpInt = long.Parse(uStr);
                tmpInt++;
                uStr = tmpInt.ToString();
            }
            else if (DateTime.TryParse(uStr, out tmpDt))
            {
                DateTime tD = tmpDt.AddDays(1);
                string format = "yyyy-M-d";
                uStr = tD.ToString(format);
            }
            else
            {
                uStr = "n-" + uStr;
            }
            return uStr;
        }

    }
}
