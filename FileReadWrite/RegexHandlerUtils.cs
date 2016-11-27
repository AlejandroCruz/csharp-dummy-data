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

            if (prefixSequence.Count > 1)
            {
                for (int i = 0; i < prefixSequence.Count; i++)
                {
                    StringBuilder strBuild = new StringBuilder();

                    if (prefixSequence[i + 1].Equals(validateZ))
                    {
                        prefixSequence[i + 1] = 'A';
                        char test = prefixSequence[i + 2]++;
                    }

                    foreach (var item in prefixSequence)
                    {
                        strBuild.Append(item);
                    }

                    outPrefix = strBuild.ToString();
                }
            }
            else
            {
                prefixSequence[0]++;
                outPrefix = prefixSequence[0].ToString();
            }

            return outPrefix;
        }
    }
}