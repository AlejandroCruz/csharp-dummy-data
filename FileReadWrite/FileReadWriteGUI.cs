using System.Windows.Forms;

namespace FileReadWrite
{
    internal class FileReadWriteGUI : Form
    {
        protected const string PATH_WATERMARK = "C:\\";
        protected string fileSource;

        protected string[] ExtractFileNameAndDirPath(string sourcePath)
        {
            int position = sourcePath.LastIndexOf('\\');
            string[] fileNameAndDirPath = new string[2];

            fileNameAndDirPath[0] = sourcePath.Substring(position + 1);
            fileNameAndDirPath[1] = sourcePath.Substring(0, (sourcePath.Length - fileNameAndDirPath[0].Length));

            return fileNameAndDirPath;
        }

    }
}
