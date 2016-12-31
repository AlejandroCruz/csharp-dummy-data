using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite.FileReadWriteGUI_Test
{
    [TestClass()]
    public class ExtractFileNameAndDirPathTest
    {
        string txtPath = "ale";
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