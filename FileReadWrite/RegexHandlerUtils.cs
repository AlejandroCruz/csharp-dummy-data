using System.Linq;
using System.Text;

namespace FileReadWrite
{
    public class RegexHandlerUtils
    {
        public int ToNumber(string prefixStr)
        {
            int number = 0;
            for (int i = 0; i < prefixStr.Length; i++)
            {
                number = number * 26 + (prefixStr[i] - ('A' - 1));
            }

            return number;
        }

        public string ToName(int inNumber)
        {
            StringBuilder strBuild = new StringBuilder();

            while (inNumber-- > 0)
            {
                strBuild.Append( (char)('A' + (inNumber % 26)) );
                inNumber /= 26;
            }

            string input = strBuild.ToString();
            return new string(input.ToCharArray().Reverse().ToArray());
        }
    }
}