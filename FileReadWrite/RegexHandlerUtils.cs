using System.Collections.Generic;

namespace FileReadWrite
{
    public class RegexHandlerUtils
    {
        private string outPrefix;
        private char Z = 'Z';

        public string AddPrefixToSequence(string prefixStr)
        {
            List<char> prefixSequence = new List<char>();

            foreach (var item in prefixStr)
            {
                prefixSequence.Add(item);
            }

            if (prefixSequence.Count > 1)
            {
                prefixSequence[0] = 'A';
                char test = prefixSequence[1];
                test++;
                prefixSequence[1] = test;
                outPrefix = prefixSequence[0].ToString() +
                    prefixSequence[1].ToString();
            }
            else
            {
                outPrefix = "A";
            }

            return outPrefix;
        }
    }
}