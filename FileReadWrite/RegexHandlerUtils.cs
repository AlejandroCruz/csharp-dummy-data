using System;
using System.Collections.Generic;
using System.Text;

namespace FileReadWrite
{
    public class RegexHandlerUtils
    {
        private string outPrefix;

        public string AddPrefixToSequence(string prefixStr)
        {
            char validateZ = 'Z';
            List<char> prefixSequence = new List<char>();

            foreach (var item in prefixStr)
            {
                prefixSequence.Add(item);
            }

            for (int i = 0; i < prefixSequence.Count; i++)
            {
                if (prefixSequence[i].Equals(validateZ))
                {
                    if (i == 4)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        prefixSequence[i] = 'A';
                        prefixSequence.Add('A');
                    }
                }
                else
                {
                    prefixSequence[i]++;
                    outPrefix = prefixSequence[i].ToString();
                }
            }

            StringBuilder strBuild = new StringBuilder();
            foreach (var item in prefixSequence)
            {
                strBuild.Append(item);
            }

            return outPrefix = strBuild.ToString();
        }
    }
}
//if (prefixSequence.Count > 1)
//            {
//                for (int i = 0; i<prefixSequence.Count; i++)
//                {
//                    StringBuilder strBuild = new StringBuilder();

//                    if (prefixSequence[i + 1].Equals(validateZ))
//                    {
//                        prefixSequence[i + 1] = 'A';
//                        char test = prefixSequence[i + 2]++;
//                    }

//                    foreach (var item in prefixSequence)
//                    {
//                        strBuild.Append(item);
//                    }

//                    outPrefix = strBuild.ToString();
//                }
//            }