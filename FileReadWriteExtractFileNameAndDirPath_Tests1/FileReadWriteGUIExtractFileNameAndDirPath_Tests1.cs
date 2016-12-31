using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReadWrite.FileReadWriteGUI_Test
{
    [TestClass()]
    public class ExtractFileNameAndDirPathTest
    {
        string txtPath = "valid";
        string expected = "false";
        string[] actual = new string[]{};

        [TestMethod()]
        public void ExtractFileNameAndDirPath_Test1()
        {
            FileReadWriteGUI obj = new FileReadWriteGUI();
            actual = obj.ExtractFileNameAndDirPath(txtPath);
            Assert.AreEqual(expected, actual[1]);
        }
    }
}